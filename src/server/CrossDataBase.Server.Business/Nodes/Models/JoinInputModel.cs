using CrossDataBase.Server.Business.Abstraction.Nodes.Models;
using CrossDataBase.Server.Business.Core.Attributes;

namespace CrossDataBase.Server.Business.Nodes.Models;
public class JoinInputModel : INodeData
{
    [NodeProperty("Sql1")]
    public ScriptOutputModel Sql1 { get; set; }

    [NodeProperty("Sql2")]
    public ScriptOutputModel Sql2 { get; set; }
}
