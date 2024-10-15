using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory.Models;

namespace CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory;
public interface IProcessHistoryReader
{
    Task<ProcessHistoryModel> GetAsync(long id);
}
