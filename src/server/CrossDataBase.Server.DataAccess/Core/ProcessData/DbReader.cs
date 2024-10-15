﻿using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessData;
using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessData.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.SQLite;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.DataAccess.Core.ProcessData;

[InjectAsSingleton(typeof(IDbReader))]
internal class DbReader(ISQLiteExecutor executor,
                ISqlScriptReader scriptReader) : IDbReader
{
    public Task<ProcessDbModel> GetAsync(long id)
    {
        var sql = scriptReader.Get(this, Scripts.Get);
        var queryObject = new QueryObject(sql, new { Id = processId });

        return executor.FirstOrDefaultAsync<ProcessDbModel>(queryObject);
    }
}
