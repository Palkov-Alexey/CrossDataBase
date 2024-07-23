namespace CrossDataBase.Server.Business.Abstraction.Core.Events.Models;
public class RequestEventArgs : EventArgs
{
    public string Guid { get; set; }
    public string NodeKey { get; set; }
}
