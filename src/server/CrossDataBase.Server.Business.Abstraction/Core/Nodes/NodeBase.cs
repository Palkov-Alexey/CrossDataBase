using CrossDataBase.Server.Business.Abstraction.Core.Results;

namespace CrossDataBase.Server.Business.Abstraction.Core.Nodes;
public abstract class NodeBase
{
    public abstract string Key { get; }
    public async Task<NodeResult> ExecuteAsync() => await OnExecuteAsync();

    public virtual Task<NodeResult> OnExecuteAsync() => Task.FromResult(Execute());
    public virtual NodeResult Execute() => Noop();

    protected NoopResult Noop() => new();
}
