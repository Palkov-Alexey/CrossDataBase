using CrossDataBase.Server.Business.Abstraction.Core.ProcessData.Models;

namespace CrossDataBase.Server.Business.Abstraction.Core.ProcessData;
public interface IProcessDataReader
{
    Task<ProcessModel> GetAsync(long id);
}
