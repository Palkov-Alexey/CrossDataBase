using CrossDataBase.Server.Enum;

namespace CrossDataBase.Server.DataAccess.Abstraction.Core.Nodes.Models;

public class NodeDbModel
{
    public int Id { get; set; }
    public NodeType Type { get; set; }
    public int PosX { get; set; }
    public int PosY { get; set; }
    public string Data { get; set; }
}