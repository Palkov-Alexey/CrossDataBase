using CrossDataBase.Server.DataAccess.Abstraction.Core.Nodes.Models;

namespace CrossDataBase.Server.DataAccess.Abstraction.Core.Nodes;

public interface INodeDbWriter
{
    Task<int> InsertAsync(int processId, NodeDbModel model);
    Task InsertAsync(int processId, IReadOnlyCollection<NodeDbModel> models);
    Task UpdateAsync(int processId, NodeDbModel model);
    Task DeleteAsync(int processId, int nodeId);
}