using CrossDataBase.Server.Business.Abstraction.Core.NodeContext;
using CrossDataBase.Server.Business.Abstraction.Core.Results;
using CrossDataBase.Server.Business.Abstraction.Nodes.Models;
using CrossDataBase.Server.Business.Core.Attributes;
using CrossDataBase.Server.Business.Core.Nodes;
using CrossDataBase.Server.Business.Nodes.Models;
using CrossDataBase.Server.Enum;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Nodes;

[InjectAsSingleton(typeof(ScriptNode))]
[Node(NodeType.Script)]
public class ScriptNode() : Node<Dictionary<string, INodeData>, ScriptDataModel, ScriptOutputModel>
{
    protected override async Task<ExecutionResult> OnExecuteAsync(NodeExecutionContext context, ScriptDataModel data, Dictionary<string, INodeData> input = null)
    {
        if (input == null)
        {
            throw new ArgumentNullException(nameof(input));
        }

        var server = (ServerModel)input["Server"];

        return Done(new ScriptOutputModel());
    }
}
