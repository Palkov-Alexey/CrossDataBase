namespace CrossDataBase.Server.DataAccess.Abstraction.Core.Memory.Models;
public class ProcessHistoryDbModel
{
    public long Id { get; set; }

    public long ProcessId { get; set; }

    public int Status { get; set; }

    public string Data { get; set; }
}
