using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using System.Configuration;

namespace CrossDataBase.Server.Infrastructure.DataAccess.SQLite;
[InjectAsSingleton(typeof(ISQLiteExecutor))]
internal class SQLiteExecutor : ExecutorBase, ISQLiteExecutor
{
    protected override string ConnectionString => ConfigurationManager.ConnectionStrings["SQLite"].ConnectionString;
}
