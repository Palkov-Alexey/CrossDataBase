using FluentMigrator;

namespace CrossDataBase.Server.DataAccess.Core.Migrations;

[Migration(1)]
public sealed class Mg1_Init : Migration
{
    public override void Up()
    {
        Execute.EmbeddedScript("Mg1_Init.sql");
    }

    public override void Down() { }
}