using CrossDataBase.Server.Business.Abstraction.Core.Events.Models;

namespace CrossDataBase.Server.Business.Core.Events;
public class RequestEventHandler
{
    public event EventHandler<RequestEventArgs> Request;

    protected virtual void OnEvent(RequestEventArgs e)
    {
        var handler = Request;
        handler?.Invoke(this, e);
    }
}