using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessData.Models;

namespace CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessData;

public interface IProcessDataDbWriter
{
    Task<int> InsertAsync(ProcessDbModel dbModel);
}
