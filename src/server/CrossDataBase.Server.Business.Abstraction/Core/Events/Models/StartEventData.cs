namespace CrossDataBase.Server.Business.Abstraction.Core.Events.Models;
public class StartEventData : EventArgs
{
    public long ProcessId { get; set; }
}
