using CrossDataBase.Server.Business.Abstraction.Core.ProcessData.Models;
using CrossDataBase.Server.Enum;

namespace CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory.Models;
public class ProcessHistoryModel
{
    public long Id { get; set; }

    public long ProcessId { get; set; }

    public StatusType Status { get; set; }

    public ProcessHistoryDataModel Data { get; set; }
}

public class ProcessHistoryDataModel
{
    public IReadOnlyCollection<NodeHistoryModel> NodeHistories { get; set; } = [];
}

public class NodeHistoryModel
{
    public NodeModel Node { get; set; }

    public StatusType Status { get; set; }

    public object Data { get; set; }

    public object ExceptionData { get; set; }
}
