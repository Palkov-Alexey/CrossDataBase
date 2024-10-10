

namespace CrossDataBase.Server.Business.Abstraction.Core.Memory;
public interface IMemoryReader
{
    Task<IReadOnlyList<object>> GetByProcessIdAsync(Guid processId);
}
