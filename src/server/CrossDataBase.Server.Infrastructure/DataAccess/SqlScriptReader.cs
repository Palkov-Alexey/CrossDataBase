using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess;
using CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;
using CrossDataBase.Server.Infrastructure.Abstractions.DependencyInjection;
using System.Collections.Concurrent;
using System.Reflection;
using YouTrackTsStatistic.Data.Infrastructure.Exceptions;

namespace CrossDataBase.Server.Infrastructure.DataAccess;

[InjectAsSingleton(typeof(ISqlScriptReader))]
public class SqlScriptReader : ISqlScriptReader
{
    private readonly ConcurrentDictionary<AssemblyScriptPath, string> scripts
        = new(new AssemblyScriptPathEqualityComparer());

    public string Get<T>(T dao, string scriptPath)
    {
        return Get(typeof(T), scriptPath);
    }

    private string Get(Type type, string scriptPath)
    {
        var assembly = type.Assembly;
        var assemblyScriptPath = new AssemblyScriptPath(assembly, scriptPath);

        var script = scripts.GetOrAdd(assemblyScriptPath, ScriptFactory);

        return script;
    }

    private static string ScriptFactory(AssemblyScriptPath assemblyScriptPath)
    {
        var script = GetScriptResourceFromAssembly(assemblyScriptPath.Assembly, assemblyScriptPath.ScriptPath);

        return script;
    }

    private static string GetScriptResourceFromAssembly(Assembly assembly, string scriptPath)
    {
        var assemblyName = assembly.GetName().Name;

        using var stream = assembly.GetManifestResourceStream($"{assemblyName}.{scriptPath}") ?? throw new ScriptNotFoundException(assemblyName, scriptPath);

        using var reader = new StreamReader(stream);
        return reader.ReadToEnd();
    }
}