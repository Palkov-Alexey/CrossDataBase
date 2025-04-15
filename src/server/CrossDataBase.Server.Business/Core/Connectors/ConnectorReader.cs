using CrossDataBase.Server.Business.Abstraction.Core.Connectors;
using CrossDataBase.Server.Business.Abstraction.Core.Connectors.Models;
using CrossDataBase.Server.Business.Core.Mappers;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Connectors;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.Connectors;

[InjectAsSingleton]
internal class ConnectorReader(IConnectorDbReader connectorDbReader) : IConnectorReader
{
    public async Task<ConnectorModel> GetAsync(int processId, int nodeId)
    {
        var result = await connectorDbReader.GetAsync(processId, nodeId);
        return result.Map();
    }

    public async Task<IReadOnlyCollection<ConnectorModel>> GetAsync(int processId)
    {
        var result = await connectorDbReader.GetAsync(processId);
        return result.Map();
    }
}