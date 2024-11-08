using CrossDataBase.Server.Business.Abstraction.Core.NodeContext;
using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessData;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessHistory.Models;
using CrossDataBase.Server.Business.Abstraction.Nodes.Models;
using CrossDataBase.Server.Business.Core.Attributes;
using CrossDataBase.Server.Enum;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CrossDataBase.Server.Business.Abstraction.Core.Engine;

[InjectAsSingleton(typeof(IEngineService))]
internal class EngineService(IProcessHistoryReader historyReader,
    IProcessHistoryWriter historyWriter,
    IProcessDataReader processDataReader,
    IServiceProvider serviceProvider) : IEngineService
{
    public async Task RunAsync(long processId)
    {
        var process = await processDataReader.GetAsync(processId);
        var historyId = await historyWriter.InsertAsync(new()
        {
            ProcessId = processId,
            Status = StatusType.InProcess,
            Data = new ProcessHistoryDataModel
            {
                NodeHistories = process.Data.Nodes.Select(x => new NodeHistoryModel { Node = x, Status = StatusType.Wait }).ToList(),
            }
        });

        var connectors = process.Data.Connectors;
        var nodes = process.Data.Nodes
            .Where(n => n.Fields.Inputs.Count == 0
                        || connectors.All(c => c.ToNode != n.Id))
            .ToArray();
        var isStart = true;

        while (nodes.Length > 0)
        {
            Dictionary<long, Dictionary<string, INodeData>> inputs = null;

            if (isStart)
            {
                isStart = false;
            }
            else
            {
                var history = await historyReader.GetAsync(historyId);
                var historyNodes = history.Data.NodeHistories;
                var currentNodeIds = nodes.Select(n => n.Id);

                var previewNodeDict = connectors
                    .Where(c => currentNodeIds.Contains(c.ToNode))
                    .GroupBy(c => c.FromNode)
                    .ToDictionary(c => c.Key, c => c.Select(x => new { x.ToNode, x.To }).ToArray());

                var previewNodes = historyNodes.Where(n => previewNodeDict.ContainsKey(n.Node.Id)).ToArray();

                inputs = previewNodes.SelectMany(p =>
                {
                    INodeData data = p.Result;
                    var conn = previewNodeDict[p.Node.Id]
                        .GroupBy(x => x.ToNode, c => c.To);
                    return conn
                    .Select(c => new KeyValuePair<long, Dictionary<string, INodeData>>(c.Key,
                        c.Select(x => new KeyValuePair<string, INodeData>(x, data))
                        .ToDictionary(x => x.Key, x => x.Value)));
                })
                .ToDictionary(x => x.Key, x => x.Value);
            }

            var tasks = nodes.Select(x =>
            {
                var node = GetComponent(x.Type);
                var context = new NodeExecutionContext
                {
                    ProcessId = processId,
                    HistoryId = historyId,
                    NodeId = x.Id,
                    CurrentNode = node,
                    Inputs = inputs.GetValueOrDefault(x.Id, null),
                    Data = x.Data
                };

                return StartNodeAsync(context);
            });

            await Task.WhenAll(tasks);

            var nextNodesIds = connectors
                .Where(c => nodes.Any(n => c.FromNode == n.Id)).Select(c => c.ToNode)
                .Distinct()
                .ToArray();

            nodes = nextNodesIds.Length == 0
                ? []
                : process.Data.Nodes
                    .Where(n => nextNodesIds.Contains(n.Id))
                    .ToArray();
        }
    }

    /*public async Task StartAsync(long processId, long historyId)
    {
        var process = await processDataReader.GetAsync(processId);

        var connectors = process.Data.Connectors;

        var startNodes = process.Data.Nodes
            .Where(n => n.Fields.Inputs.Count == 0
                        || connectors.All(c => c.ToNode != n.Id))
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
                Inputs = null,
                Data = x.Data
            };
            return StartNodeAsync(context);
        });

        await Task.WhenAll(tasks);
    }*/

    private async Task StartNodeAsync(NodeExecutionContext context)
    {
        var node = context.CurrentNode;

        try
        {
            var result = await node.ExecuteAsync(context, context.Data, context.Inputs);
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
