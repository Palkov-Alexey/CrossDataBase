using CrossDataBase.Server.Business.Abstraction.Core.NodeContext;

namespace CrossDataBase.Server.Business.Abstraction.Core.Results;
public class NoopResult : ExecutionResult
{
    protected override void Execute(IServiceProvider serviceProvider, NodeExecutionContext context)
    {
    }
}
