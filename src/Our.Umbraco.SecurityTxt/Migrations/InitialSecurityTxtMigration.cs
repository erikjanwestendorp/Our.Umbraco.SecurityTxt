using Our.Umbraco.SecurityTxt.Models.Database;
using Umbraco.Cms.Infrastructure.Migrations;

namespace Our.Umbraco.SecurityTxt.Migrations;
internal class InitialSecurityTxtMigration : MigrationBase
{
    public InitialSecurityTxtMigration(IMigrationContext context) : base(context)
    {
    }

    protected override void Migrate()
    {
        if (TableExists("securityTxt"))
        {
            Database.Execute("exec sp_rename 'securityTxt', 'securityTxt'");
        }
        else if (!TableExists("securityTxt"))
        {
            Create.Table<SecurityTxtEntity>().Do();
        }
    }
}
