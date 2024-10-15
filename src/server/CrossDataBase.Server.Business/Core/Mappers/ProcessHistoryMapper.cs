using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory.Models;
using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessHistory.Models;
using Newtonsoft.Json;

namespace CrossDataBase.Server.Business.Core.Mappers;
internal static class ProcessHistoryMapper
{
    internal static ProcessHistoryModel Map(this ProcessHistoryDbModel dbModel) =>
        dbModel == null
            ? null
            : new ProcessHistoryModel
            {
                Id = dbModel.Id,
                ProcessId = dbModel.ProcessId,
                Status = dbModel.Status,
                Data = JsonConvert.DeserializeObject<ProcessHistoryDataModel>(dbModel.Data)
            };

    internal static ProcessHistoryDbModel Map(this ProcessHistoryModel model) =>
        model == null
            ? null
            : new ProcessHistoryDbModel
            {
                Id = model.Id,
                ProcessId = model.ProcessId,
                Status = model.Status,
                Data = JsonConvert.SerializeObject(model.Data)
            };
}
