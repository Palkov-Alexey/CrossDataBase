using CrossDataBase.Server.Business.Abstraction.Core.Events.Models;

namespace CrossDataBase.Server.Business.Core.Events;
internal class EventPublisher
{
    private readonly EventWrapper<ResponseEventData> processEventWrapper;
    public EventPublisher(ProcessHandlerWrapper processHandler)
    {
        processEventWrapper = new EventWrapper<ResponseEventData>();
        processEventWrapper.Event += processHandler.HandleAsync;
    }

    public Task PublishProcessEventAsync(ResponseEventData Data, CancellationToken token)
    {
        return processEventWrapper.Notify(Data, token);
    }
}
