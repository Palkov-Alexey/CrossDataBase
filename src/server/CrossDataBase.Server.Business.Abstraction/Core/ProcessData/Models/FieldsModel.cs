namespace CrossDataBase.Server.Business.Abstraction.Core.ProcessData.Models;

public class FieldsModel
{
    public IReadOnlyCollection<string> Inputs { get; set; } = [];

    public IReadOnlyCollection<string> Outputs { get; set; } = [];
}
