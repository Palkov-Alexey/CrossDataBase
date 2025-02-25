using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Core.Attributes;
using CrossDataBase.Server.Enum;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace CrossDataBase.Server.Business.Core.Nodes;

[InjectAsSingleton]
public class NodeResolver(IServiceProvider serviceProvider) : INodeResolver
{
    private static readonly Dictionary<NodeType, Type> NodeTypes;

    static NodeResolver()
    {
        NodeTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(x => x.GetTypes())
            .Where(x => !x.IsInterface && !x.IsAbstract && x.IsAssignableTo(typeof(NodeBase)))
            .Select(x => RuntimeHelpers.GetUninitializedObject(x) as NodeBase)
            .Where(x => x is not null)
            .ToDictionary(x => x.GetType().GetCustomAttribute<NodeAttribute>().Name, x => x.GetType());
    }

    public NodeBase Resolve(NodeType type)
    {
        return serviceProvider.GetService(NodeTypes[type]) is not NodeBase node ? null : node;
    }
}
