namespace CrossDataBase.Server.Business.Abstraction.Core.Connectors.Models;

public class ConnectorModel
{
    public int Id { get; set; }

    public int FromNode { get; set; }

    public string From { get; set; }

    public int ToNode { get; set; }

    public string To { get; set; }
}