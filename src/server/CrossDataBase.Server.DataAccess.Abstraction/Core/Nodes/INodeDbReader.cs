using CrossDataBase.Server.DataAccess.Abstraction.Core.Nodes.Models;

namespace CrossDataBase.Server.DataAccess.Abstraction.Core.Nodes;

public interface INodeDbReader
{
    Task<NodeDbModel> GetAsync(int processId, int nodeId);
    Task<IReadOnlyCollection<NodeDbModel>> GetAsync(int processId);
}