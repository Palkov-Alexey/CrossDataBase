using CrossDataBase.Server.Business.Abstraction.Core.ProcessData;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessData.Models;
using CrossDataBase.Server.Business.Core.Mappers;
using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessData;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.ProcessData;

[InjectAsSingleton(typeof(IProcessDataReader))]
internal class ProcessDataReader(IProcessDataDbReader dbReader) : IProcessDataReader
{
    public async Task<ProcessModel> GetAsync(long id)
    {

        var dbModel = await dbReader.GetAsync(id);
        return dbModel.Map();
    }
}
