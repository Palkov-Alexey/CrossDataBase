using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessHistory.Models;

namespace CrossDataBase.Server.DataAccess.Abstraction.Core.Memory;

public interface IProcessHistoryDbReader
{
    Task<ProcessHistoryDbModel> GetAsync(long id);
}
