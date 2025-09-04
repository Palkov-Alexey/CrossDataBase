using CrossDataBase.Server.Business.Abstraction.Nodes.Models;
using CrossDataBase.Server.Business.Core.Attributes;

namespace CrossDataBase.Server.Business.Nodes.Models;
public class ScriptOutputModel : INodeData
{
    [NodeProperty("Result")]
    public object ScriptResult { get; set; }
}
