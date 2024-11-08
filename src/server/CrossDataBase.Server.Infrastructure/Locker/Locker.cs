using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using CrossDataBase.Server.Infrastructure.Abstractions.Locker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace CrossDataBase.Server.Infrastructure.Locker;

[InjectAsSingleton(typeof(ILocker))]
internal class Locker(
    ILogger<Locker> logger) : ILocker
{
    public async Task LockRunAsync(string lockKey, Func<Task> method)
    {
        try
        {
            Monitor.Enter(lockKey);

            logger.LogInformation($"log task key = {lockKey}");

            await method.Invoke();
        }
        catch (Exception ex)
        {
            logger.LogError(exception: ex, message: null);
        }
        finally
        {
            Monitor.Exit(lockKey);
        }
    }

    public async Task<T> LockRunAsync<T>(string lockKey, Func<Task<T>> method)
    {
        try
        {
            Monitor.Enter(lockKey);
            var result = await method.Invoke();
            return result;
        }
        catch (Exception ex)
        {
            logger.LogError(exception: ex, message: null);
            return default;
        }
        finally
        {
            Monitor.Exit(lockKey);
        }
    }
}
