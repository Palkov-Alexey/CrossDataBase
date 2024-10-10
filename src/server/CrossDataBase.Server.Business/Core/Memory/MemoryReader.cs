using CrossDataBase.Server.Business.Abstraction.Core.Memory;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Memory;

namespace CrossDataBase.Server.Business.Core.Memory;
internal class MemoryReader(IDbReader dbReader) : IMemoryReader
{
    public Task<IReadOnlyList<object>> GetByProcessIdAsync(Guid processId)
    {
        return dbReader.GetAsync(processId);
    }
}
