using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessData;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory;
using CrossDataBase.Server.Business.Core.Attributes;
using CrossDataBase.Server.Business.Core.ProcessData;
using CrossDataBase.Server.Enum;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CrossDataBase.Server.Business.Abstraction.Core.Engine;

[InjectAsSingleton(typeof(IEngineService))]
internal class EngineService(IProcessHistoryReader historyReader,
    IProcessHistoryWriter historyWriter,
    IProcessDataReader processDataReader,
    IServiceProvider serviceProvider) : IEngineService
{
    public async Task StartAsync(long processId, long historyId)
    {
        var process = await processDataReader.GetAsync(processId);

        var connectors = process.Data.Connectors;

        var startNodes = process.Data.Nodes
            .Where(n => n.Fields.Inputs.Count == 0
                        || connectors.All(c => c.ToNode != n.Id))
            .ToArray();

        var nodes = startNodes
            .GroupBy(x => x.Type)
            .Select(x => GetComponent(x.Key))
            .ToArray();
    }

    private NodeBase GetComponent(NodeType type)
    {
        var node = type.ToString();

        return serviceProvider.GetServices(typeof(NodeBase))
            .Cast<NodeBase>()
            .Where(x => string.Equals(x.GetType().GetCustomAttribute<NodeAttribute>()?.Name, node))
            .FirstOrDefault();
    }
}
