using System.Configuration;

namespace CrossDataBase.Server.DataAccess.Core.NewFolder;
internal class CoreInfrastructureBase
{
    protected readonly string ConnectionString = ConfigurationManager.ConnectionStrings["SQLite"].ConnectionString;
    protected readonly string MemoryConnectionString = ConfigurationManager.ConnectionStrings["SQLiteMemory"].ConnectionString;
}
