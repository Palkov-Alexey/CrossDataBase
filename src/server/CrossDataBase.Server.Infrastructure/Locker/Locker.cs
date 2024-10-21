using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using CrossDataBase.Server.Infrastructure.Abstractions.Locker;

namespace CrossDataBase.Server.Infrastructure.Locker;

[InjectAsSingleton(typeof(ILocker))]
internal class Locker : ILocker
{
    public async Task LockRunAsync(object lockKey, Func<Task> method)
    {
        try
        {
            Monitor.Enter(lockKey);
            await method.Invoke();
        }
        finally
        {
            Monitor.Exit(lockKey);
        }
    }

    public async Task<T> LockRunAsync<T>(object lockKey, Func<Task<T>> method)
    {
        try
        {
            Monitor.Enter(lockKey);
            var result = await method.Invoke();
            return result;
        }
        finally
        {
            Monitor.Exit(lockKey);
        }
    }
}
