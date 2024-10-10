using CrossDataBase.Server.Business.Abstraction.Core.Events.Models;

namespace CrossDataBase.Server.Business.Core.Events;
internal class EventWrapper<TEventArgs>
{
    public event AsyncEventHandler<TEventArgs> Event;

    public async Task Notify(TEventArgs Data, CancellationToken token)
    {
        await Event.InvokeAsync(this, Data, token);
    }
}
