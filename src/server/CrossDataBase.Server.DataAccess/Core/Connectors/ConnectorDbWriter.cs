using CrossDataBase.Server.DataAccess.Abstraction.Core.Connectors;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Connectors.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.DataAccess.Core.Connectors;

[InjectAsSingleton]
internal class ConnectorDbWriter(IMemoryExecutor executor,
    ISqlScriptReader scriptReader) : IConnectorDbWriter
{
    public Task<int> InsertAsync(int processId, ConnectorDbModel model)
    {
        var sql = scriptReader.Get(this, Scripts.Insert);
        var queryObject = new QueryObject(sql, new
        {
            ProcessId = processId,
            model.FromNode,
            model.From,
            model.ToNode,
            model.To
        });

        return executor.FirstOrDefaultAsync<int>(queryObject);
    }
    
    public Task UpdateAsync(int processId, ConnectorDbModel model)
    {
        var sql = scriptReader.Get(this, Scripts.Update);
        var queryObject = new QueryObject(sql, new
        {
            ProcessId = processId,
            model.Id,
            model.FromNode,
            model.From,
            model.ToNode,
            model.To
        });

        return executor.ExecuteAsync(queryObject);
    }
    
    public Task DeleteAsync(int processId, int connectorId)
    {
        var sql = scriptReader.Get(this, Scripts.Delete);
        var queryObject = new QueryObject(sql, new
        {
            ProcessId = processId,
            ConnectorId = connectorId
        });

        return executor.ExecuteAsync(queryObject);
    }
}