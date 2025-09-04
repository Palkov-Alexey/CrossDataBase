using CrossDataBase.Server.Business.Abstraction.Core.NodeContext;

namespace CrossDataBase.Server.Business.Abstraction.Core.Results;
public class ExecutionResult : INodeResult
{
    public virtual Task ExecuteAsync(IServiceProvider serviceProvider, NodeExecutionContext context)
    {
        Execute(serviceProvider, context);
        return Task.CompletedTask;
    }

    protected virtual void Execute(IServiceProvider serviceProvider, NodeExecutionContext context) { }
}
