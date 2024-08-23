namespace YouTrackTsStatistic.Data.Infrastructure.Exceptions;

public class ScriptNotFoundException(string assemblyName, string scriptPath)
    : Exception($"Script {scriptPath} not found in assembly {assemblyName}");