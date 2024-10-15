using CrossDataBase.Server.Business.Abstraction.Core.Events.Models;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessData;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.Events;

[InjectAsSingleton(typeof(HandlerWrapper))]
internal class HandlerWrapper(
    IProcessHistoryReader memoryReader,
    IProcessDataReader processDataReader)
{
    public async Task HandleAsync(object sender, ResponseEventData Data, CancellationToken token)
    {
        try
        {
            Monitor.Enter(Data.ProcessId);
            var processHistoryTask = memoryReader.GetAsync(Data.HistoryId);
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
            var processHistoryTask = memoryReader.GetAsync(Data.ProcessId);
            var processTask = processDataReader.GetAsync(Data.ProcessId);

            await Task.WhenAll(processHistoryTask, processTask);
        }
        finally
        {
            Monitor.Exit(Data.ProcessId);
        }
    }
}
