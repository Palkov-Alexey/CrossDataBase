using CrossDataBase.Server.DataAccess.Abstraction.Core.Memory.Models;

namespace CrossDataBase.Server.DataAccess.Abstraction.Core.Memory;

public interface IDbReader
{
    Task<ProcessHistoryDbModel> GetAsync(long id);
}
