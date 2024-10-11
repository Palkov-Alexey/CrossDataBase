using CrossDataBase.Server.Business.Abstraction.Core.Memory;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Memory;

namespace CrossDataBase.Server.Business.Core.Memory;
internal class MemoryReader(IDbReader dbReader) : IMemoryReader
{
    public Task<object> GetAsync(long id)
    {
        return dbReader.GetAsync(id);
    }
}
