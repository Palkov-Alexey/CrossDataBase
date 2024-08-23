using System.Configuration;

namespace CrossDataBase.Server.Infrastructure.DataAccess.SQLite;
//[InjectAsSingleton(typeof(IMemoryExecutor))]
internal class SQLiteExecutor : ExecutorBase
{
    protected override string ConnectionString => ConfigurationManager.ConnectionStrings["SQLite"].ConnectionString;

    public SQLiteExecutor()
    {
    }
}
