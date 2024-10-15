namespace CrossDataBase.Server.Business.Abstraction.Core.ProcessData.Models;

public class ConnectorModel
{
    public long Id { get; set; }

    public long FromNode { get; set; }

    public string From { get; set; }

    public long ToNode { get; set; }

    public string To { get; set; }
}
