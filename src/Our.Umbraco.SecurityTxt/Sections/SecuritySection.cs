using Umbraco.Cms.Core.Sections;

namespace Our.Umbraco.SecurityTxt.Sections;

public class SecuritySection : ISection
{
    public const string SectionAlias = "security";
    public const string SectionName = "Security";
    public string Alias => SectionAlias;
    public string Name => SectionName;
}
