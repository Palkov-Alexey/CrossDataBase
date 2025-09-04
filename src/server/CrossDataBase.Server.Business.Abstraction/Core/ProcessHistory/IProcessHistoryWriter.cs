using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory.Models;
using CrossDataBase.Server.Business.Abstraction.Nodes.Models;
using CrossDataBase.Server.Enum;

namespace CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory;
public interface IProcessHistoryWriter
{
    Task<long> InsertAsync(ProcessHistoryModel model);
    Task ReconnectAsync();
    Task UpdateAsync(long historyId, long nodeId, StatusType status, INodeData result);
}
