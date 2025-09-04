using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Abstraction.Core.Nodes.Models;
using CrossDataBase.Server.Business.Core.Attributes;
using CrossDataBase.Server.Enum;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using System.Reflection;

namespace CrossDataBase.Server.Business.Core.Nodes;

[InjectAsSingleton]
internal class NodeService(INodeResolver nodeResolver) : INodeService
{
    public IReadOnlyCollection<NodeInfoModel> GetNodeInfo()
    {
        var nodeData = nodeResolver.Resolve();

        return nodeData.Select(x => new NodeInfoModel
        {
            Type = x.GetType().GetCustomAttribute<NodeAttribute>().Name,
            Inputs = x.GetInputProperties()?.Select(f => f.Name).ToArray() ?? [],
            Outputs = x.GetOutputProperties()?.Select(f => f.Name).ToArray() ?? []
        }).ToList();
    }

    public object GetNode(NodeType type)
    {
        var nodeData = nodeResolver.Resolve(type);

        return null;
    }
}
