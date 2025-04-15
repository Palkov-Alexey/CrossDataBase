using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Abstraction.Core.Nodes.Models;
using CrossDataBase.Server.Business.Core.Mappers;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Nodes;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.Nodes;

[InjectAsSingleton]
public class NodeReader(INodeDbReader nodeDbReader) : INodeReader
{
    public async Task<NodeModel> GetAsync(int processId, int nodeId)
    {
        var result = await nodeDbReader.GetAsync(processId, nodeId);
        return result.Map();
    }
    
    public async Task<IReadOnlyCollection<NodeModel>> GetAsync(int processId)
    {
        var result = await nodeDbReader.GetAsync(processId);
        return result.Map();
    }
}