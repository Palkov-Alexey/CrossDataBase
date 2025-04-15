using CrossDataBase.Server.Business.Abstraction.Core.Nodes.Models;

namespace CrossDataBase.Server.Business.Abstraction.Core.Nodes;

public interface INodeReader
{
    Task<NodeModel> GetAsync(int processId, int nodeId);
    Task<IReadOnlyCollection<NodeModel>> GetAsync(int processId);
}