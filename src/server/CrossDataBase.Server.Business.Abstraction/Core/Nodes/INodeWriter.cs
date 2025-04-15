using CrossDataBase.Server.Business.Abstraction.Core.Nodes.Models;

namespace CrossDataBase.Server.Business.Abstraction.Core.Nodes;

public interface INodeWriter
{
    Task<int> CreateAsync(int processId, NodeModel model);
    Task UpdateAsync(int processId, NodeModel model);
    Task DeleteAsync(int processId, int nodeId);
}