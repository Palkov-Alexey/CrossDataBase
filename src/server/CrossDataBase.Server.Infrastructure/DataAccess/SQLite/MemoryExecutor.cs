using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using Microsoft.Data.Sqlite;
using System.Configuration;

namespace CrossDataBase.Server.Infrastructure.DataAccess.SQLite;
[InjectAsSingleton(typeof(IMemoryExecutor))]
internal class MemoryExecutor : ExecutorBase, IMemoryExecutor
{
    protected override string ConnectionString => ConfigurationManager.ConnectionStrings["SQLiteMemory"].ConnectionString;

    private readonly SqliteConnection connection;

    public MemoryExecutor()
    {
        connection = new SqliteConnection(ConnectionString);
        connection.Open();
    }
}
