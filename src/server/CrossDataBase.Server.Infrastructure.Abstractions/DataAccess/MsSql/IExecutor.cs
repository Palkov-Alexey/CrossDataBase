
namespace CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.MsSql;
public interface IExecutor
{
    Task<IEnumerable<dynamic>> QueryAsync(string connectionString, string query);
}
