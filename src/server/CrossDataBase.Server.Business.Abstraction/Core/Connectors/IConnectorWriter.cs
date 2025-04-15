using CrossDataBase.Server.Business.Abstraction.Core.Connectors.Models;

namespace CrossDataBase.Server.Business.Abstraction.Core.Connectors;

public interface IConnectorWriter
{
    Task<int> CreateAsync(int processId, ConnectorModel model);
    Task UpdateAsync(int processId, ConnectorModel model);
    Task DeleteAsync(int processId, int nodeId);
}