using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory.Models;
using CrossDataBase.Server.Business.Core.Mappers;
using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessHistory;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.ProcessHistory;

[InjectAsSingleton(typeof(IProcessHistoryWriter))]
internal class ProcessHistoryWriter(IProcessHistoryDbWriter dbWriter) : IProcessHistoryWriter
{
    public Task<long> InsertAsync(ProcessHistoryModel model)
    {
        var dbModel = model.Map();

        return dbWriter.InsertAsync(dbModel);
    }
}
