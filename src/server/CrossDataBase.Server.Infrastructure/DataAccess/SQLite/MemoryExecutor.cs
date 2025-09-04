using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using Microsoft.Data.Sqlite;
using System.Configuration;

namespace CrossDataBase.Server.Infrastructure.DataAccess.SQLite;
[InjectAsSingleton(typeof(IMemoryExecutor))]
internal class MemoryExecutor : ExecutorBase, IMemoryExecutor
{
#if DEBUG
    // Для разработки используем локальную БД
    protected override string ConnectionString => ConfigurationManager.ConnectionStrings["SQLite"].ConnectionString;
#else
    protected override string ConnectionString =>  ConfigurationManager.ConnectionStrings["SQLiteMemory"].ConnectionString;
#endif

    private readonly SqliteConnection connection;

    public MemoryExecutor()
    {

        connection = new SqliteConnection(ConnectionString);
    }

    public void OpenConnection()
    {
        connection.Open();
    }

    public async Task ReconnectAsync()
    {
        await connection.CloseAsync();
        await connection.OpenAsync();
    }
}
