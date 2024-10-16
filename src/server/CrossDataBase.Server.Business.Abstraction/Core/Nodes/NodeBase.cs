using CrossDataBase.Server.Business.Abstraction.Core.Results;

namespace CrossDataBase.Server.Business.Abstraction.Core.Nodes;
public abstract class NodeBase
{
    public async Task<NodeResult> ExecuteAsync() => await OnExecuteAsync();

    public virtual Task<NodeResult> OnExecuteAsync() => Task.FromResult(Execute());
    public virtual Task<NodeResult> OnPreviewAsync() => Task.FromResult(Preview());
    public virtual NodeResult Execute() => Noop();
    public virtual NodeResult Preview() => Noop();

    protected static NoopResult Noop() => new();
}
