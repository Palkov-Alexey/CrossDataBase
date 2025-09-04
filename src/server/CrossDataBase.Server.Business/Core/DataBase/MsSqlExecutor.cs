using CrossDataBase.Server.Business.Abstraction.Nodes.Models;
using CrossDataBase.Server.Enum;
using System.Text;

namespace CrossDataBase.Server.Business.Core.DataBase;
internal class MsSqlExecutor : CoreExecutorBase
{
    protected override SQLServerType DbType => SQLServerType.MsSQL;

    protected override Task<object> QueryAsync(ServerModel server, string query)
    {
        if (server == null || string.IsNullOrEmpty(query))
        {
            return null;
        }

        var conn = ConnectionStringBuilder(server);


        return null;
    }

    private static string ConnectionStringBuilder(ServerModel server)
    {
        var builder = new StringBuilder($"Data Source={server.Host}");
        if (!string.IsNullOrEmpty(server.Instance))
        {
            builder.Append($@"\{server.Instance}");
        }

        if(server.AuthenticationType == SQLServerAuthenticationType.WindowsCredentials)
        {
            builder.Append("Integrated Security=True");
        }
        else
        {
            builder.Append($"User ID={server.User};Password={server.Password}");
        }

        builder.Append($"Catalog={server.DbName}");

        return builder.ToString();
    }
}
