namespace CrossDataBase.Server.Business.Core.Events;
public class MultipleEvent<T>
{
    private Dictionary<string, object> data = [];

    public MultipleEvent(T events)
    {

    }
}
