using CrossDataBase.Server.Business.Abstraction.Core.Nodes;
using CrossDataBase.Server.Business.Abstraction.Core.ProcessData.Models;
using CrossDataBase.Server.Business.Abstraction.Nodes.Models;

namespace CrossDataBase.Server.Business.Abstraction.Core.NodeContext;
public class NodeExecutionContext
{
    public long ProcessId { get; set; }
    public long HistoryId { get; set; }
    public long NodeId { get; set; }
    public NodeBase CurrentNode { get; set; }
    public INodeData Data { get; set; }
    public Dictionary<string, INodeData> Inputs { get; set; }
}
