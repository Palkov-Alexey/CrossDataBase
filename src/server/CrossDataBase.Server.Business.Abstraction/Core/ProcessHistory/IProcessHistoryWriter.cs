using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory.Models;
using CrossDataBase.Server.Enum;

namespace CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory;
public interface IProcessHistoryWriter
{
    Task<long> InsertAsync(ProcessHistoryModel model);
    Task UpdateAsync(long historyId, long nodeId, StatusType status, object result);
}
