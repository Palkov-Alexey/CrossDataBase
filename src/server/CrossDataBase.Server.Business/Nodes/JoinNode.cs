using CrossDataBase.Server.Business.Core.Attributes;
using CrossDataBase.Server.Business.Core.Nodes;
using CrossDataBase.Server.Business.Nodes.Models;
using CrossDataBase.Server.Enum;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Nodes;

[InjectAsSingleton(typeof(JoinNode))]
[Node(NodeType.Join)]
public class JoinNode : Node<JoinInputModel, JoinDataModel, JoinOutputModel>
{
}
