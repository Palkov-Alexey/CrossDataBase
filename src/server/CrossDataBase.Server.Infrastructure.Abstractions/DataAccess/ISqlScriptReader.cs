namespace CrossDataBase.Server.Infrastructure.Abstractions.DataAccess;

public interface ISqlScriptReader
{
    string Get<T>(T dao, string scriptPath);
}