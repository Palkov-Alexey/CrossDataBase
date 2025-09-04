using CrossDataBase.Server.Business.Abstraction.Core.Connectors.Models;
using CrossDataBase.Server.DataAccess.Abstraction.Core.Connectors.Models;
using CrossDataBase.Server.Models;

namespace CrossDataBase.Server.Mapper;

internal static class ConnectorMapper
{
    public static IReadOnlyCollection<Connector> Map(this IReadOnlyCollection<ConnectorModel> models) =>
        models.Select(Map).ToList();
    
    public static Connector Map(this ConnectorModel model) => new()
    {
        Id = model.Id,
        FromNode = model.FromNode,
        From = model.From,
        ToNode = model.ToNode,
        To = model.To
    };
    
    public static IReadOnlyCollection<ConnectorModel> Map(this IReadOnlyCollection<Connector> models) =>
        models.Select(Map).ToList();
    
    public static ConnectorModel Map(this Connector model) => new()
    {
        Id = model.Id,
        FromNode = model.FromNode,
        From = model.From,
        ToNode = model.ToNode,
        To = model.To
    };
}
