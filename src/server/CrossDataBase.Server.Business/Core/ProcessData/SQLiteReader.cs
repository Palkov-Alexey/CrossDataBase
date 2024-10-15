using CrossDataBase.Server.Business.Abstraction.Core.ProcessData;
using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessData;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.ProcessData;

[InjectAsSingleton(typeof(ISQLiteReader))]
internal class SQLiteReader(IDbReader dbReader) : ISQLiteReader
{
    public Task<object> GetAsync(long id)
    {
        return dbReader.GetAsync(id);
    }
}
