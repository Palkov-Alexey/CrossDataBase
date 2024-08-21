using CrossDataBase.Server.DataAccess.Abstraction.Infrastructure;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using Dapper;
using Microsoft.Data.Sqlite;
using System.Configuration;

namespace CrossDataBase.Server.DataAccess.Infrastructure;
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

    public void Init()
    {
        connection.Execute("""
            CREATE TABLE "process_history" (
            	"id"	INTEGER,
            	"process_id"	TEXT NOT NULL,
            	"status"	INTEGER NOT NULL,
            	"node_id"	TEXT NOT NULL,
            	"data"	TEXT NOT NULL,
            	PRIMARY KEY("id")
            );

            CREATE INDEX "ix__process_history__process_id" ON "process_history" (
            	"process_id"
            );
            """);
    }
}
