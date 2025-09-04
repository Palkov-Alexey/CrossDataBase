using FluentMigrator.Runner;
using System.Reflection;

namespace CrossDataBase.Server;

public static class MigrateBuilder
{
    private static readonly string DirSeparator = Path.DirectorySeparatorChar.ToString();

    public static void Migration()
    {
        var path = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) ?? string.Empty).LocalPath;
        var assemblyNames = Directory
            .GetFiles(path, "CrossDataBase.*.dll", SearchOption.TopDirectoryOnly)
            .Select(f =>
                f.Replace(path, string.Empty)
                 .Replace(".dll", string.Empty)
                 .Replace(DirSeparator, string.Empty))
            .ToArray();

        var migrationProvider = new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(c => c.AddSQLite()
                .WithGlobalConnectionString(System.Configuration.ConfigurationManager.ConnectionStrings["SQLite"].ConnectionString)
                .ScanIn([.. assemblyNames.Select(Assembly.Load)])
                .For
                .EmbeddedResources()
                .For
                .Migrations())
            .BuildServiceProvider(true);

        using var scope = migrationProvider.CreateScope();
        scope.ServiceProvider.GetRequiredService<IMigrationRunner>().MigrateUp();
    }
}