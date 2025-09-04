using CrossDataBase.Server.Business.Abstraction.Nodes.Models;
using CrossDataBase.Server.Business.Core.Attributes;

namespace CrossDataBase.Server.Business.Nodes.Models;

public class JoinOutputModel : INodeData
{
    [NodeProperty("Result")]
    public object Result { get; set; }
}
