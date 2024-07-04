using CrossDataBase.Server.Business.Core.Attributes;
using CrossDataBase.Server.Enum;

namespace CrossDataBase.Server.Business.Abstraction.Nodes.Models;
public class ServerModel : INodeData
{
    [NodeProperty("Server Type")]
    public SQLServerType ServerType { get; set; }

    [NodeProperty("Host")]
    public string Host { get; set; }

    [NodeProperty("Port")]
    public string Port { get; set; }

    [NodeProperty("Instance")]
    public string Instance { get; set; }

    [NodeProperty("Auth Type")]
    public SQLServerAuthenticationType AuthenticationType { get; set; }

    [NodeProperty("User")]
    public string User { get; set; }

    [NodeProperty("Password")]
    public string Password { get; set; }
}
