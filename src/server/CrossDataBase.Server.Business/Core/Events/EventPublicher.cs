using CrossDataBase.Server.Business.Abstraction.Core.Events.Models;

namespace CrossDataBase.Server.Business.Core.Events;
internal class EventPublisher
{
    private readonly ProcessEventWrapper processEventWrapper;
    public EventPublisher(ProcessHandlerWrapper processHandler)
    {
        processEventWrapper = new ProcessEventWrapper();
        processEventWrapper.Event += processHandler.HandleAsync;
    }

    public Task PublishProcessEventAsync(ResponseEventArgs args, CancellationToken token)
    {
        return processEventWrapper.Notify(args, token);
    }
}
