using CrossDataBase.Server.Business.Abstraction.Nodes.Models;
using CrossDataBase.Server.Enum;

namespace CrossDataBase.Server.Business.Core.DataBase;
internal abstract class CoreExecutorBase
{
    protected abstract SQLServerType DbType { get; }

    protected abstract Task<object> QueryAsync(ServerModel server, string query);
}
