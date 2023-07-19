using Umbraco.Cms.Core.Packaging;

namespace Our.Umbraco.SecurityTxt.Migrations;

internal class SecurityTxtMigrationPlan : PackageMigrationPlan
{
    public SecurityTxtMigrationPlan() : base("SecurityTxt", "security_txt_migrations")
    {
    }

    protected override void DefinePlan()
    {
        To<InitialSecurityTxtMigration>("initial-stat");
    }
}
