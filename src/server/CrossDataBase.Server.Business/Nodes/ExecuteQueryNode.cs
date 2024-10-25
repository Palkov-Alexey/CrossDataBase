using CrossDataBase.Server.Business.Core.Attributes;
using CrossDataBase.Server.Business.Core.Nodes;
using CrossDataBase.Server.Enum;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Nodes;

[InjectAsSingleton(typeof(ExecuteQueryNode))]
[Node(NodeType.ExecuteQuery)]
internal class ExecuteQueryNode : Node
{

}
