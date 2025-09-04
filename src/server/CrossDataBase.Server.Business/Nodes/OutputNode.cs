using CrossDataBase.Server.Business.Abstraction.Nodes.Models;
using CrossDataBase.Server.Business.Core.Attributes;
using CrossDataBase.Server.Business.Core.Nodes;
using CrossDataBase.Server.Business.Nodes.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Nodes;

[Node(Enum.NodeType.Output)]
[InjectAsSingleton(typeof(OutputNode))]
public class OutputNode : Node<OutputInputModel>
{
}
