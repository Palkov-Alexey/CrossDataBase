using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessData.Models;

namespace CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessData;

public interface IProcessDataDbReader
{
    Task<ProcessDbModel> GetAsync(long id);
}
