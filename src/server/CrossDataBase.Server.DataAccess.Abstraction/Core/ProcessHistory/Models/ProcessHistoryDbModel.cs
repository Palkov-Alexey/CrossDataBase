using CrossDataBase.Server.Enum;

namespace CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessHistory.Models;
public class ProcessHistoryDbModel
{
    public long Id { get; set; }

    public long ProcessId { get; set; }

    public StatusType Status { get; set; }

    public string Data { get; set; }
}
