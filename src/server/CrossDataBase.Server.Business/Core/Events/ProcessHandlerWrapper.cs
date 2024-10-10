using CrossDataBase.Server.Business.Abstraction.Core.Events.Models;
using CrossDataBase.Server.Business.Abstraction.Core.Memory;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.Events;

[InjectAsSingleton(typeof(ProcessHandlerWrapper))]
internal class ProcessHandlerWrapper(IMemoryReader memoryReader)
{
    public async Task HandleAsync(object sender, ResponseEventData Data, CancellationToken token)
    {
        var processHistoryList = await memoryReader.GetByProcessIdAsync(Data.Guid);
    }
}
