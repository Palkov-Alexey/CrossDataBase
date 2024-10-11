

namespace CrossDataBase.Server.Business.Abstraction.Core.Memory;
public interface IMemoryReader
{
    Task<object> GetAsync(long id);
}
