namespace CrossDataBase.Server.Business.Abstraction.Core.Events.Models;
public class ResponseEventData : EventArgs
{
    public long HistoryId { get; set; }
    public long ProcessId { get; set; }
    public long NextNodeId { get; set; }
    public string NodeKey { get; set; }
}
