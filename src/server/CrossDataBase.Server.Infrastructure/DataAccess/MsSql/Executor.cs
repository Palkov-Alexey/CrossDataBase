using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.MsSql;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using Dapper;
using Microsoft.Data.SqlClient;

namespace CrossDataBase.Server.Infrastructure.DataAccess.MsSql;
[InjectAsSingleton(typeof(IExecutor))]
internal class Executor : IExecutor
{
    public async Task<IEnumerable<dynamic>> QueryAsync(string connectionString, string query)
    {
        var serverConnection = new SqlConnection(connectionString);
        await serverConnection.OpenAsync();
        var result = await serverConnection.QueryAsync(query);
        await serverConnection.CloseAsync();

        return result;
    }
}
