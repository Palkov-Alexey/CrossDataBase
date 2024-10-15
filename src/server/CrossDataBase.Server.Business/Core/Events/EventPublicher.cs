using CrossDataBase.Server.Business.Abstraction.Core.Events.Models;

namespace CrossDataBase.Server.Business.Core.Events;
internal class EventPublisher
{
    private readonly EventWrapper<ResponseEventData> processEventWrapper;
    private readonly EventWrapper<StartEventData> startEventWrapper;

    public EventPublisher(HandlerWrapper processHandler)
    {
        processEventWrapper = new EventWrapper<ResponseEventData>();
        processEventWrapper.Event += processHandler.HandleAsync;

        startEventWrapper = new EventWrapper<StartEventData>();
        startEventWrapper.Event += processHandler.HandleAsync;
    }

    public Task PublishProcessEventAsync(ResponseEventData Data, CancellationToken token)
    {
        return processEventWrapper.Notify(Data, token);
    }

    public Task PublishStartEventAsync(StartEventData Data, CancellationToken token)
    {
        return startEventWrapper.Notify(Data, token);
    }
}
