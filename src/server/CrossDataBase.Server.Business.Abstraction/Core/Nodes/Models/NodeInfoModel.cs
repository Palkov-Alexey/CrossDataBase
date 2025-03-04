using CrossDataBase.Server.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossDataBase.Server.Business.Abstraction.Core.Nodes.Models;

public class NodeInfoModel
{
    public string Name => Type.ToString();
    public NodeType Type { get; set; }
    public string[] Inputs { get; set; }
    public string[] Outputs { get; set; }
}
