using CrossDataBase.Server.Business.Abstraction.Core.Nodes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossDataBase.Server.Business.Abstraction.Core.Nodes;
public interface INodeService
{
    IReadOnlyCollection<NodeInfoModel> GetNodeInfo();
}
