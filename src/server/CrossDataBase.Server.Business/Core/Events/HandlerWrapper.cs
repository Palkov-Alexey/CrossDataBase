using CrossDataBase.Server.Business.Abstraction.Core.Events.Models;
using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessData;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory.Models;
using CrossDataBase.Server.Business.Core.Attributes;
using CrossDataBase.Server.Enum;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CrossDataBase.Server.Business.Core.Events;

[InjectAsSingleton(typeof(HandlerWrapper))]
internal class HandlerWrapper(
    IProcessHistoryReader historyReader,
    IProcessHistoryWriter historyWriter,
    IProcessDataReader processDataReader,
    IServiceProvider serviceProvider)
{
    public async Task HandleAsync(object sender, ResponseEventData Data, CancellationToken token)
    {
        try
        {
            Monitor.Enter(Data.ProcessId);
            var processHistoryTask = historyReader.GetAsync(Data.HistoryId);
            var processTask = processDataReader.GetAsync(Data.ProcessId);

            await Task.WhenAll(processHistoryTask, processTask);
        }
        finally
        {
            Monitor.Exit(Data.ProcessId);
        }
    }

    public async Task HandleAsync(object sender, StartEventData Data, CancellationToken token)
    {
        try
        {
            Monitor.Enter(Data.ProcessId);
            var historyTask = historyWriter.InsertAsync(new()
            {
                ProcessId = Data.ProcessId,
                Status = StatusType.InProcess,
                Data = new ProcessHistoryDataModel()
            });
            var processTask = processDataReader.GetAsync(Data.ProcessId);

            await Task.WhenAll(historyTask, processTask);

            var process = processTask.Result;
            var connectors = process.Data.Connectors;

            var historyId = historyTask.Result;

            var startNodes = process.Data.Nodes
                .Where(n => n.Fields.Inputs.Count == 0
                            || connectors.All(c => c.ToNode != n.Id))
                .ToArray();
        }
        finally
        {
            Monitor.Exit(Data.ProcessId);
        }
    }

    private IReadOnlyCollection<NodeBase> GetComponent(NodeType type)
    {
        var node = type.ToString();

        return serviceProvider.GetServices(typeof(NodeBase))
            .Cast<NodeBase>()
            .Where(x => string.Equals(x.GetType().GetCustomAttribute<NodeAttribute>()?.Name, node))
            .ToArray();
    }
}
