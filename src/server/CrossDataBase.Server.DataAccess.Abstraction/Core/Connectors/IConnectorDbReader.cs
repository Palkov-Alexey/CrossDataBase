using CrossDataBase.Server.DataAccess.Abstraction.Core.Connectors.Models;

namespace CrossDataBase.Server.DataAccess.Abstraction.Core.Connectors;

public interface IConnectorDbReader
{
    Task<ConnectorDbModel> GetAsync(int processId, int nodeId);
    Task<IReadOnlyCollection<ConnectorDbModel>> GetAsync(int processId);
}