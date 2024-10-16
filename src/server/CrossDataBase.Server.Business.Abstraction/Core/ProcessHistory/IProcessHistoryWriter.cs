using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory.Models;

namespace CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory;
public interface IProcessHistoryWriter
{
    Task<long> InsertAsync(ProcessHistoryModel model);
}
