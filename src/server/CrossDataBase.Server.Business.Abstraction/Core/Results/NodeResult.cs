namespace CrossDataBase.Server.Business.Abstraction.Core.Results;
public class NodeResult : INodeResult
{
    public virtual Task ExecuteAsync(IServiceProvider serviceProvider)
    {
        Execute(serviceProvider);
        return Task.CompletedTask;
    }

    protected virtual void Execute(IServiceProvider serviceProvider) { }
}
