using CrossDataBase.Server.Business.Abstraction.Core.Events.Models;

namespace CrossDataBase.Server.Business.Core.Events;
internal class EventReader
{
    private readonly Event<ResponseEventArgs> _event;

    public EventReader()
    {
        _event = new Event<ResponseEventArgs>();
        _event._Event += Test;
    }
    private void Test(object sender, ResponseEventArgs e)
    {

    }
}
