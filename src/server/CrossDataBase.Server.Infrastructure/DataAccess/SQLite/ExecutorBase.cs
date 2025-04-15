using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;
using Dapper;
using Microsoft.Data.Sqlite;

namespace CrossDataBase.Server.Infrastructure.DataAccess.SQLite;
internal abstract class ExecutorBase
{
    protected abstract string ConnectionString { get; }

    public async Task ExecuteAsync(QueryObject query)
    {
        await using var connection = new SqliteConnection(ConnectionString);
        await connection.OpenAsync();
        await connection.ExecuteAsync(query.Sql, query.QueryParams);
        await connection.CloseAsync();
    }

    public async Task<IReadOnlyCollection<T>> QueryAsync<T>(QueryObject query)
    {
        await using var connection = new SqliteConnection(ConnectionString);
        await connection.OpenAsync();
        var result = await connection.QueryAsync<T>(query.Sql, query.QueryParams);
        await connection.CloseAsync();
        
        return result.ToList();
    }

    public async Task<T> FirstOrDefaultAsync<T>(QueryObject query)
    {
        await using var connection = new SqliteConnection(ConnectionString);
        await connection.OpenAsync();
        var result = await connection.QueryAsync<T>(query.Sql, query.QueryParams);
        await connection.CloseAsync();

        return result.FirstOrDefault();
    }
}
