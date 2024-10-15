using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory.Models;

namespace CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory;
public interface IProcessHistoryWriter
{
    Task InsertAsync(ProcessHistoryModel model);
}
