using CrossDataBase.Server.Business.Abstraction.Core.NodeContext;
using CrossDataBase.Server.Business.Abstraction.Core.Results;
using CrossDataBase.Server.Business.Core.ProcessHistory;
using CrossDataBase.Server.Enum;
using Microsoft.Extensions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.Results;
internal class OutcomeResult : ExecutionResult
{
    private INodeResult Output { get; }

    public OutcomeResult(INodeResult output)
    {
        Output = output;
    }

    public override async Task ExecuteAsync(IServiceProvider serviceProvider, NodeExecutionContext context)
    {
        var processHistoryWriter = serviceProvider.GetRequiredService<ProcessHistoryWriter>();

        await processHistoryWriter.UpdateAsync(context.HistoryId, context.NodeId, StatusType.Success, Output);
        
    }
}
