using CrossDataBase.Server.DataAccess.Abstraction.Core.Memory;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.DataAccess.Core.Memory;

[InjectAsSingleton(typeof(IDbReader))]
internal class DbReader(IMemoryExecutor executor,
    ISqlScriptReader scriptReader) : IDbReader
{
    public Task<IReadOnlyList<object>> GetAsync(Guid processId)
    {
        var sql = scriptReader.Get(this, Scripts.GetByProcessId);
        var queryObject = new QueryObject(sql, new { ProcessId = processId.ToString() });

        return executor.QueryAsync<object>(queryObject);
    }
}
