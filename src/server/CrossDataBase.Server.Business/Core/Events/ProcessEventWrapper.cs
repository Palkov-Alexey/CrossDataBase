using CrossDataBase.Server.Business.Abstraction.Core.Events.Models;

namespace CrossDataBase.Server.Business.Core.Events;
internal class ProcessEventWrapper
{
    public event AsyncEventHandler<ResponseEventArgs> Event;

    public async Task Notify(ResponseEventArgs args, CancellationToken token)
    {
        await Event.InvokeAsync(this, args, token);
    }
}
