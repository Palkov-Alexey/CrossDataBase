using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace CrossDataBase.Server.DataAccess.Core.Migrations;

public static class MigrateBuilder
{
    public static void Migration()
    {
        var migrationProvider = new ServiceCollection()
            .AddFluentMigratorCore()
            .ConfigureRunner(c => c.AddSQLite()
                .WithGlobalConnectionString(System.Configuration.ConfigurationManager.ConnectionStrings["SQLite"].ConnectionString)
                .ScanIn(Assembly.GetExecutingAssembly())
                .For
                .EmbeddedResources()
                .For
                .Migrations())
            .BuildServiceProvider(true);

        using var scope = migrationProvider.CreateScope();
        scope.ServiceProvider.GetRequiredService<IMigrationRunner>().MigrateUp();
    }
}