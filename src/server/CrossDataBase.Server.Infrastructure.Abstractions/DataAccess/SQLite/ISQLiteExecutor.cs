using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;

namespace CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
public interface ISQLiteExecutor
{
    Task ExecuteAsync(QueryObject query);

    Task<T> FirstOrDefaultAsync<T>(QueryObject query);
}
