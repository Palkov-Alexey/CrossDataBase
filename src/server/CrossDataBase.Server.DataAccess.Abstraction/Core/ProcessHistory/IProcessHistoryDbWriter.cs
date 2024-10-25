using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessHistory.Models;

namespace CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessHistory;

public interface IProcessHistoryDbWriter
{
    Task<long> InsertAsync(ProcessHistoryDbModel model);
    Task UpdateDataAsync(long id, string data);
}
