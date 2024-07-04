using CrossDataBase.Server.Business.Abstraction.Nodes.Models;

namespace CrossDataBase.Server.Business.Nodes.Models;
public class JoinInputModel : INodeData
{
    public ScriptOutputModel ScriptResult1 { get; set; }

    public ScriptOutputModel ScriptResult2 { get; set; }
}
