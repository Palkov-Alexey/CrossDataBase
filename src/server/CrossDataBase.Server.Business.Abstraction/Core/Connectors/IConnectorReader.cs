using CrossDataBase.Server.Business.Abstraction.Core.Connectors.Models;

namespace CrossDataBase.Server.Business.Abstraction.Core.Connectors;

public interface IConnectorReader
{
    Task<ConnectorModel> GetAsync(int processId, int nodeId);
    Task<IReadOnlyCollection<ConnectorModel>> GetAsync(int processId);
}