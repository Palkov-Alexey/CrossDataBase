using CrossDataBase.Server.Business.Abstraction.Core.Connectors;
using CrossDataBase.Server.Business.Abstraction.Core.Connectors.Models;
using CrossDataBase.Server.Business.Core.Mappers;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Connectors;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.Connectors;

[InjectAsSingleton]
internal class ConnectorWriter(IConnectorDbWriter dbWriter) : IConnectorWriter
{
    public Task<int> CreateAsync(int processId, ConnectorModel model) => dbWriter.InsertAsync(processId, model.Map());

    public Task UpdateAsync(int processId, ConnectorModel model) => dbWriter.UpdateAsync(processId, model.Map());

    public Task DeleteAsync(int processId, int nodeId) => dbWriter.DeleteAsync(processId, nodeId);
}