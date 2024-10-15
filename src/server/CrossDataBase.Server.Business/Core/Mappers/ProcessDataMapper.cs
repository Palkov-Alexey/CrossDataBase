using CrossDataBase.Server.Business.Abstraction.Core.ProcessData.Models;
using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessData.Models;
using Newtonsoft.Json;

namespace CrossDataBase.Server.Business.Core.Mappers;
internal static class ProcessDataMapper
{
    internal static ProcessModel Map(this ProcessDbModel dbModel) =>
        dbModel == null
            ? null
            : new ProcessModel
            {
                Id = dbModel.Id,
                Name = dbModel.Name,
                Data = JsonConvert.DeserializeObject<ProcessDataModel>(dbModel.Data)
            };

    internal static ProcessDbModel Map(this ProcessModel model) =>
        model == null
            ? null
            : new ProcessDbModel
            {
                Id = model.Id,
                Name = model.Name,
                Data = JsonConvert.SerializeObject(model.Data)
            };
}
