using CrossDataBase.Server.DataAccess.Abstraction.Core.Memory;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Memory.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.DataAccess.Core.Memory;

[InjectAsSingleton(typeof(IDbReader))]
internal class DbReader(IMemoryExecutor executor,
    ISqlScriptReader scriptReader) : IDbReader
{
    public Task<ProcessHistoryDbModel> GetAsync(long id)
    {
        var sql = scriptReader.Get(this, Scripts.GetByProcessId);
        var queryObject = new QueryObject(sql, new { Id = id });

        return executor.FirstOrDefaultAsync<ProcessHistoryDbModel>(queryObject);
    }
}
