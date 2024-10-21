namespace CrossDataBase.Server.Infrastructure.Abstractions.Locker;
public interface ILocker
{
    Task LockRunAsync(object lockKey, Func<Task> method);

    Task<T> LockRunAsync<T>(object lockKey, Func<Task<T>> method);
}
