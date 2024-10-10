using FluentMigrator.Runner;
using System.Reflection;

namespace CrossDataBase.Server.DataAccess.Core.Migrations;

public static class MigrateBuilder
{
    private static readonly string dirSeparator = Path.DirectorySeparatorChar.ToString();

    public static void Migration()
    {
        var path = new Uri(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)).LocalPath;
        var assemblyNames = Directory
            .GetFiles(path, $@"*.dll", SearchOption.TopDirectoryOnly)
            .Select(f =>
                f.Replace(path, string.Empty)
                 .Replace(".dll", string.Empty)
                 .Replace(dirSeparator, string.Empty))
            .ToArray();

        var migrationProvider = new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(c => c.AddSQLite()
                .WithGlobalConnectionString(System.Configuration.ConfigurationManager.ConnectionStrings["SQLite"].ConnectionString)
                .ScanIn(assemblyNames.Select(Assembly.Load).ToArray())
                .For
                .EmbeddedResources()
                .For
                .Migrations())
            .BuildServiceProvider(true);

        using var scope = migrationProvider.CreateScope();
        scope.ServiceProvider.GetRequiredService<IMigrationRunner>().MigrateUp();
    }
}