using FluentMigrator;

namespace CrossDataBase.Server.DataAccess.Core.Migrations;

[Migration(20240828161631)]
public sealed class Mg20240828161631_Init : Migration
{
    public override void Up()
    {
        Execute.EmbeddedScript("Mg20240828161631_Init.sql");
    }

    public override void Down() { }
}