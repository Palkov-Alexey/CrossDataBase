using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory.Models;
using CrossDataBase.Server.Business.Abstraction.Nodes.Models;
using CrossDataBase.Server.Business.Core.Mappers;
using CrossDataBase.Server.DataAccess.Abstraction.Core.ProcessHistory;
using CrossDataBase.Server.Enum;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using CrossDataBase.Server.Infrastructure.Abstractions.Locker;
using Newtonsoft.Json;

namespace CrossDataBase.Server.Business.Core.ProcessHistory;

[InjectAsSingleton(typeof(IProcessHistoryWriter))]
internal class ProcessHistoryWriter(IProcessHistoryDbWriter dbWriter,
    IProcessHistoryReader processHistoryReader,
    ILocker locker) : IProcessHistoryWriter
{
    public Task<long> InsertAsync(ProcessHistoryModel model)
    {
        var dbModel = model.Map();

        return dbWriter.InsertAsync(dbModel);
    }

    public async Task UpdateAsync(long historyId, long nodeId, StatusType status, INodeData result)
    {
        await locker.LockRunAsync($"Update.{historyId}",
            async () =>
            {
                var history = await processHistoryReader.GetAsync(historyId);
                var nodeHistories = history.Data.NodeHistories.ToList();
                var nodeIndex = nodeHistories.FindIndex(x => x.Node.Id == nodeId);
                nodeHistories[nodeIndex].Result = result;
                nodeHistories[nodeIndex].Status = status;

                var data = JsonConvert.SerializeObject(new ProcessHistoryDataModel { NodeHistories = nodeHistories });
                await dbWriter.UpdateDataAsync(historyId, data);
            });
    }
}
