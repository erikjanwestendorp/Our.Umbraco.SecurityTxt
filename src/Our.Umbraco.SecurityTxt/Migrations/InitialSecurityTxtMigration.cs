using Our.Umbraco.SecurityTxt.Models.Database;
using Umbraco.Cms.Infrastructure.Migrations;

namespace Our.Umbraco.SecurityTxt.Migrations;

internal class InitialSecurityTxtMigration : MigrationBase
{
    public const string TableName = SecurityTxtConstants.Database.Tables.SecurityTxt;
    public InitialSecurityTxtMigration(IMigrationContext context) : base(context)
    {
    }

    protected override void Migrate()
    {
        if (TableExists(TableName))
        {
            Database.Execute("exec sp_rename 'securityTxt', 'securityTxt'");
        }
        else if (!TableExists(TableName))
        {
            Create.Table<SecurityTxtEntity>().Do();
        }
    }
}
