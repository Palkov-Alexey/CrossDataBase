using CrossDataBase.Server.Business.Abstraction.Core.Nodes.Models;
using CrossDataBase.Server.Models;
using Fields = CrossDataBase.Server.Business.Abstraction.Core.Nodes.Models.Fields;

namespace CrossDataBase.Server.Mapper;

internal static class NodeMapper
{
    public static NodeModel Map(this Node node) => new()
    {
        Id = node.Id,
        Type = node.Type,
        PosX = node.PosY,
        PosY = node.PosY,
        Data = node.Data
    };
    
    public static Node Map(this NodeModel node) => new()
    {
        Id = node.Id,
        Type = node.Type,
        PosX = node.PosY,
        PosY = node.PosY,
        Data = node.Data
    };
}