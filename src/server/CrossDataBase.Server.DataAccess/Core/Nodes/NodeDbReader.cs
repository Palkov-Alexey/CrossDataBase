using CrossDataBase.Server.DataAccess.Abstraction.Core.Nodes;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Nodes.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.DataAccess.Core.Nodes;

[InjectAsSingleton]
internal class NodeDbReader(IMemoryExecutor executor,
    ISqlScriptReader scriptReader) : INodeDbReader
{
    public Task<NodeDbModel> GetAsync(int processId, int nodeId)
    {
        var sql = scriptReader.Get(this, Scripts.GetList);
        var queryObject = new QueryObject(sql, new { ProcessId = processId, NodeId = nodeId });
        
        return executor.FirstOrDefaultAsync<NodeDbModel>(queryObject);
    }
    
    public Task<IReadOnlyCollection<NodeDbModel>> GetAsync(int processId)
    {
        var sql = scriptReader.Get(this, Scripts.GetList);
        var queryObject = new QueryObject(sql, new { ProcessId = processId });
        
        return executor.QueryAsync<NodeDbModel>(queryObject);
    }
}