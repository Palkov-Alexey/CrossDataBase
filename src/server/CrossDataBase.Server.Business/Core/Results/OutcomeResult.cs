using CrossDataBase.Server.Business.Abstraction.Core.NodeContext;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory.Models;
using CrossDataBase.Server.Business.Abstraction.Core.Results;
using CrossDataBase.Server.Business.Core.Events;
using CrossDataBase.Server.Business.Core.ProcessHistory;
using CrossDataBase.Server.Enum;
using Microsoft.Extensions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.Results;
internal class OutcomeResult : ExecutionResult
{
    private object Output { get; }

    public OutcomeResult(object output)
    {
        Output = output;
    }

    public override async Task ExecuteAsync(IServiceProvider serviceProvider, NodeExecutionContext context)
    {
        var eventPublisher = serviceProvider.GetRequiredService<EventPublisher>();
        var processHistoryWriter = serviceProvider.GetRequiredService<ProcessHistoryWriter>();

        await processHistoryWriter.UpdateAsync(context.HistoryId, context.NodeId, StatusType.Success, Output);
        
    }
}
