namespace CrossDataBase.Server.Infrastructure.Abstractions.Locker;
public interface ILocker
{
    Task LockRunAsync(string lockKey, Func<Task> method);

    Task<T> LockRunAsync<T>(string lockKey, Func<Task<T>> method);
}
