using CrossDataBase.Server.DataAccess.Abstraction.Core.Memory;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.DataAccess.Core.Memory;

[InjectAsSingleton(typeof(IDbWriter))]
internal class DbWriter : IDbWriter
{
    private readonly IMemoryExecutor executor;
    private readonly ISqlScriptReader scriptReader;

    public DbWriter(IMemoryExecutor executor,
                    ISqlScriptReader scriptReader)
    {
        this.executor = executor;
        this.scriptReader = scriptReader;
        _ = Init();
    }

    private async Task Init()
    {
        var sql = scriptReader.Get(this, Scripts.Init);
        var queryObject = new QueryObject(sql);
        await executor.ExecuteAsync(queryObject);
    }
}
