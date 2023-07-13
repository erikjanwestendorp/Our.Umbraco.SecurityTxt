using Our.Umbraco.SecurityTxt.Sections;
using Umbraco.Cms.Core.Dashboards;

namespace Our.Umbraco.SecurityTxt.Dashboards;

public class WelcomeDashboard : IDashboard
{
    public string? Alias => "securityTxtWelcomeDashboard";
    public string? View => "/App_Plugins/SecurityTxt/Dashboards/welcomeDashboard.html";
    public string[] Sections => new[] {SecuritySection.SectionAlias};
    public IAccessRule[] AccessRules => Array.Empty<IAccessRule>();
}
