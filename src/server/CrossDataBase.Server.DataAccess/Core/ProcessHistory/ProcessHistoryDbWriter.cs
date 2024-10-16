using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessHistory;
using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessHistory.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.DataAccess.Core.ProcessHistory;

[InjectAsSingleton(typeof(IProcessHistoryDbWriter))]
internal class ProcessHistoryDbWriter : IProcessHistoryDbWriter
{
    private readonly IMemoryExecutor executor;
    private readonly ISqlScriptReader scriptReader;

    public ProcessHistoryDbWriter(IMemoryExecutor executor,
                    ISqlScriptReader scriptReader)
    {
        this.executor = executor;
        this.scriptReader = scriptReader;

        _ = Init();
    }

    public Task<long> InsertAsync(ProcessHistoryDbModel model)
    {
        var sql = scriptReader.Get(this, Scripts.Insert);
        var queryObject = new QueryObject(sql,
            new { model.ProcessId, model.Status, model.Data });

        return executor.FirstOrDefaultAsync<long>(queryObject);
    }

    private async Task Init()
    {
        var sql = scriptReader.Get(this, Scripts.Init);
        var queryObject = new QueryObject(sql);

        await executor.ExecuteAsync(queryObject);
    }
}
