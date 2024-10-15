namespace CrossDataBase.Server.Business.Abstraction.Core.ProcessData.Models;
public class ProcessModel
{
    public long Id { get; set; }

    public string Name { get; set; }

    public IReadOnlyCollection<NodeModel> Nodes { get; set; } = [];

    public IReadOnlyCollection<ConnectorModel> Connectors { get; set; } = [];
}
