using System.Configuration;

namespace CrossDataBase.Server.DataAccess.Infrastructure;
internal abstract class ExecutorBase
{
    protected abstract string ConnectionString { get; }
}
