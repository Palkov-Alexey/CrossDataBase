using CrossDataBase.Server.Business.Abstraction.Core.Results;

namespace CrossDataBase.Server.Business.Abstraction.Core.Nodes;
public abstract class NodeBase
{
    public Task<NodeResult> ExecuteAsync() => OnExecuteAsync();
    public virtual Task<NodeResult> OnExecuteAsync() => Task.FromResult(OnExecute());;
    public virtual NodeResult OnExecute() => Noop();

    protected static NoopResult Noop() => new();
}
