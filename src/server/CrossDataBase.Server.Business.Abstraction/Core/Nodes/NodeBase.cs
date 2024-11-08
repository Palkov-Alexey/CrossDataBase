using CrossDataBase.Server.Business.Abstraction.Core.NodeContext;
using CrossDataBase.Server.Business.Abstraction.Core.Results;
using CrossDataBase.Server.Business.Abstraction.Nodes.Models;

namespace CrossDataBase.Server.Business.Abstraction.Core.Nodes;
public abstract class NodeBase
{
    public Task<ExecutionResult> ExecuteAsync(NodeExecutionContext context, INodeData data, Dictionary<string, INodeData> input = null) => OnExecuteAsync(context, data, input);
    public virtual Task<ExecutionResult> OnExecuteAsync(NodeExecutionContext context, INodeData data, Dictionary<string, INodeData> input = null) => Task.FromResult(OnExecute(context, data, input));
    public virtual ExecutionResult OnExecute(NodeExecutionContext context, INodeData data, Dictionary<string, INodeData> input = null) => Noop();

    protected static NoopResult Noop() => new();
}
