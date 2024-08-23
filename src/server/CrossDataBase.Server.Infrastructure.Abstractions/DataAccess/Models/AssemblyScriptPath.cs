﻿using System.Reflection;

namespace CrossDataBase.Server.Infrastructure.Abstractions.DataAccess.Models;

public sealed class AssemblyScriptPath(Assembly assembly, string scriptPath)
{
    public Assembly Assembly { get; } = assembly;

    public string ScriptPath { get; } = scriptPath;
}

public sealed class AssemblyScriptPathEqualityComparer : IEqualityComparer<AssemblyScriptPath>
{
    public bool Equals(AssemblyScriptPath x, AssemblyScriptPath y)
    {
        if (x == null && y == null)
        {
            return true;
        }

        if (x == null || y == null)
        {
            return false;
        }

        var xAssemblyName = x.Assembly.GetName().Name;
        var xScriptPath = x.ScriptPath;

        var yAssemblyName = y.Assembly.GetName().Name;
        var yScriptPath = y.ScriptPath;

        return xAssemblyName == yAssemblyName && xScriptPath == yScriptPath;
    }

    public int GetHashCode(AssemblyScriptPath obj)
    {
        var assemblyName = obj.Assembly.GetName().Name;
        var scriptPath = obj.ScriptPath;

        return $"{assemblyName}::{scriptPath}".GetHashCode();
    }
}