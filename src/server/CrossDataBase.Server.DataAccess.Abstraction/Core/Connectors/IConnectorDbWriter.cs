using CrossDataBase.Server.DataAccess.Abstraction.Core.Connectors.Models;

namespace CrossDataBase.Server.DataAccess.Abstraction.Core.Connectors;

public interface IConnectorDbWriter
{
    Task<int> InsertAsync(int processId, ConnectorDbModel model);
    Task UpdateAsync(int processId, ConnectorDbModel model);
    Task DeleteAsync(int processId, int connectorId);
}