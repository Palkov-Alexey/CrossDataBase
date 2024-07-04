using CrossDataBase.Server.Business.Abstraction.Nodes.Models;

namespace CrossDataBase.Server.Business.Nodes.Models;
public class ScriptOutputModel : INodeData
{
    public object ScriptResult { get; set; }
}
