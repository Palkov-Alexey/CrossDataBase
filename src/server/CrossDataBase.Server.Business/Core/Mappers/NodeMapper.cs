using CrossDataBase.Server.Business.Abstraction.Core.Nodes.Models;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Nodes.Models;
using Newtonsoft.Json;

namespace CrossDataBase.Server.Business.Core.Mappers;

internal static class NodeMapper
{
    public static IReadOnlyCollection<NodeDbModel> Map(this IReadOnlyCollection<NodeModel> models) =>
        models.Select(Map).ToList();
    
    public static NodeDbModel Map(this NodeModel model) => new()
    {
        Id = model.Id,
        Type = model.Type,
        PosX = model.PosX,
        PosY = model.PosY,
        Data = JsonConvert.SerializeObject(model.Data)
    };

    public static IReadOnlyCollection<NodeModel> Map(this IReadOnlyCollection<NodeDbModel> models) =>
        models.Select(Map).ToList();
    
    public static NodeModel Map(this NodeDbModel model) => new()
    {
        Id = model.Id,
        Type = model.Type,
        PosX = model.PosX,
        PosY = model.PosY,
        Data = JsonConvert.DeserializeObject(model.Data)
    };
}