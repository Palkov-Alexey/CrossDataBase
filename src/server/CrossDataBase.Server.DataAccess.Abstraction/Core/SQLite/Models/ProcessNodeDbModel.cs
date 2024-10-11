using CrossDataBase.Server.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossDataBase.Server.DataAccess.Abstraction.Core.SQLite.Models;
public class ProcessNodeDbModel
{
    public long Id { get; set; }

    public long ProcessId { get; set; }

    public NodeType Type { get; set; }

    public string Data { get; set; }
}
