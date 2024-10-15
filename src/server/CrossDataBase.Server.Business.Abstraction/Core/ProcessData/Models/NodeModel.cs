namespace CrossDataBase.Server.Business.Abstraction.Core.ProcessData.Models;

public class NodeModel
{
    public long Id { get; set; }

    public string Name { get; set; }

    public long PosX { get; set; }

    public long PosY { get; set; }

    public FieldsModel Fields { get; set; }
}
