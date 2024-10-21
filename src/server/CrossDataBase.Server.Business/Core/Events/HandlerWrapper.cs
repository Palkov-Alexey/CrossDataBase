using CrossDataBase.Server.Business.Abstraction.Core.Engine;
using CrossDataBase.Server.Business.Abstraction.Core.Events.Models;
using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessData;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory.Models;
using CrossDataBase.Server.Business.Core.Attributes;
using CrossDataBase.Server.Enum;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using CrossDataBase.Server.Infrastructure.Abstractions.Locker;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CrossDataBase.Server.Business.Core.Events;

[InjectAsSingleton(typeof(HandlerWrapper))]
internal class HandlerWrapper(
    IProcessHistoryReader historyReader,
    IProcessHistoryWriter historyWriter,
    IProcessDataReader processDataReader,
    IEngineService engineService,
    ILocker locker)
{
    public async Task HandleAsync(object sender, ResponseEventData data, CancellationToken token)
    {
        await locker.LockRunAsync(new { data.ProcessId, data.HistoryId, data.NextNodeId },
            async () =>
            {
                var processHistoryTask = historyReader.GetAsync(data.HistoryId);
                var processTask = processDataReader.GetAsync(data.ProcessId);

                await Task.WhenAll(processHistoryTask, processTask);
            });
    }

    public async Task HandleAsync(object sender, StartEventData data, CancellationToken token)
    {
        var historyId = await historyWriter.InsertAsync(new()
        {
            ProcessId = data.ProcessId,
            Status = StatusType.InProcess,
            Data = new ProcessHistoryDataModel()
        });

        await locker.LockRunAsync(new { data.ProcessId, historyId },
            async () => await engineService.StartAsync(data.ProcessId, historyId));
    }

    
}
