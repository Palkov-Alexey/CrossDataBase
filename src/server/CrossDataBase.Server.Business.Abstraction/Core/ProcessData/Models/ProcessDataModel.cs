namespace CrossDataBase.Server.Business.Abstraction.Core.ProcessData.Models;

public class ProcessDataModel
{
    public IReadOnlyCollection<NodeModel> Nodes { get; set; } = [];

    public IReadOnlyCollection<ConnectorModel> Connectors { get; set; } = [];
}
