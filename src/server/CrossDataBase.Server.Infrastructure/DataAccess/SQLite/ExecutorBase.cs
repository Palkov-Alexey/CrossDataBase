using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CrossDataBase.Server.Infrastructure.DataAccess.SQLite;
internal abstract class ExecutorBase
{
    protected abstract string ConnectionString { get; }

    public async Task ExecuteAsync(QueryObject query)
    {
        using var connection = new SqliteConnection(ConnectionString);
        await connection.OpenAsync();
        await connection.ExecuteAsync(query.Sql, query.QueryParams);
        await connection.CloseAsync();
        connection.Dispose();
    }

    public async Task<IReadOnlyList<T>> QueryAsync<T>(QueryObject query)
    {
        using var connection = new SqliteConnection(ConnectionString);
        await connection.OpenAsync();
        var result = await connection.QueryAsync<T>(query.Sql, query.QueryParams);
        await connection.CloseAsync();
        connection.Dispose();
        
        return result.ToList();
    }

    public async Task<T> FirstOrDefaultAsync<T>(QueryObject query)
    {
        using var connection = new SqliteConnection(ConnectionString);
        await connection.OpenAsync();
        var result = await connection.QueryAsync<T>(query.Sql, query.QueryParams);
        await connection.CloseAsync();
        connection.Dispose();

        return result.FirstOrDefault();
    }
}
