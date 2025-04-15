using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Abstraction.Core.Nodes.Models;
using CrossDataBase.Server.Business.Core.Mappers;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Nodes;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;

namespace CrossDataBase.Server.Business.Core.Nodes;

[InjectAsSingleton]
internal class NodeWriter(INodeDbWriter dbWriter) : INodeWriter
{
    public Task<int> CreateAsync(int processId, NodeModel model) => dbWriter.InsertAsync(processId, model.Map());

    public Task UpdateAsync(int processId, NodeModel model) => dbWriter.UpdateAsync(processId, model.Map());

    public Task DeleteAsync(int processId, int nodeId) => dbWriter.DeleteAsync(processId, nodeId);
}