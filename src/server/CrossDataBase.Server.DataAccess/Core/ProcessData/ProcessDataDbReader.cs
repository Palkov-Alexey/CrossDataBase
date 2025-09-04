using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessData;
using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessData.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.DataAccess.Core.ProcessData;

[InjectAsSingleton]
internal class ProcessDataDbReader(IMemoryExecutor executor,
                ISqlScriptReader scriptReader) : IProcessDataDbReader
{
    public Task<ProcessDbModel> GetAsync(int id)
    {
        var sql = scriptReader.Get(this, Scripts.Get);
        var queryObject = new QueryObject(sql, new { Id = id });

        return executor.FirstOrDefaultAsync<ProcessDbModel>(queryObject);
    }
}
