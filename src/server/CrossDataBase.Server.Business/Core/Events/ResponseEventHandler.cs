using CrossDataBase.Server.Business.Abstraction.Core.Events.Models;

namespace CrossDataBase.Server.Business.Core.Events;
public class ResponseEventHandler
{
    public event EventHandler<ResponseEventArgs> Response;

    protected virtual void OnEvent(ResponseEventArgs e)
    {
        var handler = Response;
        handler?.Invoke(this, e);
    }
}
