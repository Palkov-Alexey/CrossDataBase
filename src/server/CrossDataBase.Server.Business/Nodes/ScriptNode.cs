using CrossDataBase.Server.Business.Abstraction.Nodes.Models;
using CrossDataBase.Server.Business.Core.Attributes;
using CrossDataBase.Server.Business.Core.Nodes;
using CrossDataBase.Server.Business.Nodes.Models;
using CrossDataBase.Server.Enum;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Nodes;

[InjectAsSingleton(typeof(ScriptNode))]
[Node(NodeType.Script)]
public class ScriptNode : Node<ServerModel, ScriptDataModel, ScriptOutputModel>
{
    public override string Key => throw new NotImplementedException();
}
