using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory.Models;
using CrossDataBase.Server.Business.Core.Mappers;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Memory;

namespace CrossDataBase.Server.Business.Core.ProcessHistory;
internal class ProcessHistoryReader(IProcessHistoryDbReader dbReader) : IProcessHistoryReader
{
    public async Task<ProcessHistoryModel> GetAsync(long id)
    {
        var dbModel = await dbReader.GetAsync(id);
        return dbModel.Map();
    }
}
