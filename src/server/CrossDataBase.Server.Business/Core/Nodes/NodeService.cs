using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Enum;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.Nodes;

[InjectAsSingleton]
internal class NodeService(INodeResolver nodeResolver) : INodeService
{
    public object GetNode(NodeType type)
    {
        var nodeData = nodeResolver.Resolve(type);


    }
}
