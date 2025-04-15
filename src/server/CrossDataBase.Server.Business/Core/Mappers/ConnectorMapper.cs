using CrossDataBase.Server.Business.Abstraction.Core.Connectors.Models;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Connectors.Models;

namespace CrossDataBase.Server.Business.Core.Mappers;

internal static class ConnectorMapper
{
    public static IReadOnlyCollection<ConnectorDbModel> Map(this IReadOnlyCollection<ConnectorModel> models) =>
        models.Select(Map).ToList();
    
    public static ConnectorDbModel Map(this ConnectorModel model) => new()
    {
        Id = model.Id,
        FromNode = model.FromNode,
        From = model.From,
        ToNode = model.ToNode,
        To = model.To
    };
    
    public static IReadOnlyCollection<ConnectorModel> Map(this IReadOnlyCollection<ConnectorDbModel> models) =>
        models.Select(Map).ToList();
    
    public static ConnectorModel Map(this ConnectorDbModel model) => new()
    {
        Id = model.Id,
        FromNode = model.FromNode,
        From = model.From,
        ToNode = model.ToNode,
        To = model.To
    };
}
