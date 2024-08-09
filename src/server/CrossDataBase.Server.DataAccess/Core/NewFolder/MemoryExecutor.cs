using Dapper;
using Microsoft.Data.Sqlite;

namespace CrossDataBase.Server.DataAccess.Core.NewFolder;
internal class MemoryExecutor : CoreInfrastructureBase
{
    private readonly SqliteConnection connection;

    public MemoryExecutor()
    {
        connection = new SqliteConnection(MemoryConnectionString);
        connection.Open();
    }

    internal async void InitAsync()
    {
        await connection.ExecuteAsync("""

            """);
    }
}
