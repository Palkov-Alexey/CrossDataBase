namespace CrossDataBase.Server.Business.Core.Events;
public class Event<T>
{
    public event EventHandler<T> _Event;
}
