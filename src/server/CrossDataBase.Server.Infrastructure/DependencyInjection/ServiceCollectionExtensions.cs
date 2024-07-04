using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CrossDataBase.Server.Infrastructure.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static void RegisterByDIAttribute(this IServiceCollection services, string assemblySearchPattern)
    {
        var assemblyPath = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).LocalPath;
        services.RegisterByDIAttribute(assemblyPath, assemblySearchPattern);
    }

    public static void RegisterByDIAttribute(this IServiceCollection services, string assemblyPath, string assemblySearchPattern)
    {
        var installer = new DIInstaller(services);
        installer.RegisterByDIAttribute(assemblyPath, assemblySearchPattern);
        installer.Initialize();
    }

    public static void RegisterByDIAttribute(this IServiceCollection services, params Assembly[] assemblyList)
    {
        var installer = new DIInstaller(services);
        installer.RegisterByDIAttribute(assemblyList);
        installer.Initialize();
    }
}
