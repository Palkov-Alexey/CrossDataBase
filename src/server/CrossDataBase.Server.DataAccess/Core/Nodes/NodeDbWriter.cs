using CrossDataBase.Server.DataAccess.Abstraction.Core.Nodes;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Nodes.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.DataAccess.Core.Nodes;

[InjectAsSingleton]
internal class NodeDbWriter(IMemoryExecutor executor,
    ISqlScriptReader scriptReader) : INodeDbWriter
{
    public Task<int> InsertAsync(int processId, NodeDbModel model)
    {
        var sql = scriptReader.Get(this, Scripts.Insert);
        var queryObject = new QueryObject(sql, new
        {
            ProcessId = processId,
            model.Type,
            model.PosX,
            model.PosY,
            model.Data
        });

        return executor.FirstOrDefaultAsync<int>(queryObject);
    }
    
    public Task UpdateAsync(int processId, NodeDbModel model)
    {
        var sql = scriptReader.Get(this, Scripts.Delete);
        var queryObject = new QueryObject(sql, new
        {
            ProcessId = processId,
            model.Id,
            model.Type,
            model.PosX,
            model.PosY,
            model.Data
        });

        return executor.ExecuteAsync(queryObject);
    }
    
    public Task DeleteAsync(int processId, int nodeId)
    {
        var sql = scriptReader.Get(this, Scripts.Update);
        var queryObject = new QueryObject(sql, new
        {
            ProcessId = processId,
            NodeId = nodeId
        });

        return executor.ExecuteAsync(queryObject);
    }
}