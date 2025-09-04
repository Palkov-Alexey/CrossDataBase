using CrossDataBase.Server.Business.Abstraction.Nodes.Models;

namespace CrossDataBase.Server.Business.Nodes.Models;
public class ScriptDataModel : INodeData
{
    public string ScriptText { get; set; }
}
