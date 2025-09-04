using CrossDataBase.Server.Business.Abstraction.Core.NodeContext;

namespace CrossDataBase.Server.Business.Abstraction.Core.Results;
public interface INodeResult
{
    Task ExecuteAsync(IServiceProvider serviceProvider, NodeExecutionContext context);
}
