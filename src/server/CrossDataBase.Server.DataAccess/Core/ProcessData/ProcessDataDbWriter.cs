using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessData;
using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessData.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.DataAccess.Core.ProcessData;

[InjectAsSingleton(typeof(IProcessDataDbWriter))]
internal class ProcessDataDbWriter(ISQLiteExecutor executor,
                ISqlScriptReader scriptReader) : IProcessDataDbWriter
{
    public Task InsertAsync(ProcessDbModel dbModel)
    {
        var sql = scriptReader.Get(this, Scripts.Insert);
        var queryObject = new QueryObject(sql, new { dbModel.Name, dbModel.Data });

        return executor.QueryAsync<long>(queryObject);
    }
}
