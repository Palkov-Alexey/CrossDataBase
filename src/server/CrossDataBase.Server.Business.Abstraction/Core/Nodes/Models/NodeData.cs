using CrossDataBase.Server.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossDataBase.Server.Business.Abstraction.Core.Nodes.Models;
public class NodeData
{
    public NodeType Type { get; set; }
    public string Name => Type.ToString();
    public object Outcomes { get; set; }
    public object[] InputProperty { get; set; }
    public object[] DataProperty { get; set; }
    public object[] OutputProperty { get; set; }
}
