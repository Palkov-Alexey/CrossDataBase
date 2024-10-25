using CrossDataBase.Server.Business.Abstraction.Core.NodeContext;
using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessData;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory;
using CrossDataBase.Server.Business.Abstraction.Core.Results;
using CrossDataBase.Server.Business.Core.Attributes;
using CrossDataBase.Server.Business.Core.ProcessData;
using CrossDataBase.Server.Business.Nodes;
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

        var nodeTypes = startNodes
            .Select(x => x.Type)
            .Distinct()
            .ToArray();

        var tasks = startNodes.Select(x =>
        {
            var node = GetComponent(x.Type);
            var context = new NodeExecutionContext
            {
                ProcessId = processId,
                HistoryId = historyId,
                NodeId = x.Id,
                CurrentNode = node,
                Input = null,
                Data = x.Data
            };
            return StartNodeAsync(context);
        });

        await Task.WhenAll(tasks);
    }

    private async Task StartNodeAsync(NodeExecutionContext context)
    {
        var node = context.CurrentNode;

        try
        {
            var result = await node.ExecuteAsync(context, context.Data, context.Input);
            await result.ExecuteAsync(serviceProvider, context);
        }
        finally { }
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
