namespace CrossDataBase.Server.DataAccess.Abstraction.Core.SQLite.Models;
public class ProcessNodeConnectorsDbModel
{
    public long Id { get; set; }

    public long FromNodeId { get; set; }

    public string FromNodePoint { get; set; }

    public long ToNodeId { get; set; }

    public string ToNodePoint { get; set; }
}
