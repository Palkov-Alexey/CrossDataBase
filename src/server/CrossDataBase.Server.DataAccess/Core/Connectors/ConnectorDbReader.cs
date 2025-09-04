using CrossDataBase.Server.DataAccess.Abstraction.Core.Connectors;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Connectors.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.DataAccess.Core.Connectors;

[InjectAsSingleton]
internal class ConnectorDbReader(IMemoryExecutor executor,
    ISqlScriptReader scriptReader) : IConnectorDbReader
{
    public Task<ConnectorDbModel> GetAsync(int processId, int nodeId)
    {
        var sql = scriptReader.Get(this, Scripts.Get);
        var queryObject = new QueryObject(sql, new { ProcessId = processId, NodeId = nodeId });
        
        return executor.FirstOrDefaultAsync<ConnectorDbModel>(queryObject);
    }
    
    public Task<IReadOnlyCollection<ConnectorDbModel>> GetAsync(int processId)
    {
        var sql = scriptReader.Get(this, Scripts.GetList);
        var queryObject = new QueryObject(sql, new { ProcessId = processId });
        
        return executor.QueryAsync<ConnectorDbModel>(queryObject);
    }
}