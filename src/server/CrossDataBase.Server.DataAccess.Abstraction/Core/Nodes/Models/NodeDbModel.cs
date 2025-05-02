using System.ComponentModel.DataAnnotations.Schema;
using CrossDataBase.Server.Enum;

namespace CrossDataBase.Server.DataAccess.Abstraction.Core.Nodes.Models;

public class NodeDbModel
{
    [Column(TypeName = "id")]
    public int Id { get; set; }
    
    [Column(TypeName = "type")]
    public NodeType Type { get; set; }
    
    [Column(TypeName = "pos_x")]
    public int PosX { get; set; }
    
    [Column(TypeName = "pos_y")]
    public int PosY { get; set; }
    
    [Column(TypeName = "data")]
    public string Data { get; set; }
}