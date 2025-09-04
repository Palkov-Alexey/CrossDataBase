using CrossDataBase.Server.Enum;

namespace CrossDataBase.Server.Models;

public class Node
{
    public int Id { get; set; }

    public string Name { get; set; }

    /// <summary>
    /// Node type enum
    /// </summary>
    public NodeType Type { get; set; }

    public int PosX { get; set; }

    public int PosY { get; set; }

    public object Data { get; set; }
}