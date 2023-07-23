using Our.Umbraco.SecurityTxt.Sections;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Trees;
using Umbraco.Cms.Web.Common.Attributes;

namespace Our.Umbraco.SecurityTxt.Controllers;

[Tree(SecuritySection.SectionAlias, Alias, TreeTitle = "Security.txt", TreeGroup = "SecurityTxt", SortOrder = 1)]
[PluginController("SecurityTxt")]
public class SecurityTxtSectionTreeController : SecurityTxtTreeController
{
    public SecurityTxtSectionTreeController(ILocalizedTextService localizedTextService, UmbracoApiControllerTypeCollection umbracoApiControllerTypeCollection, IEventAggregator eventAggregator) : base(localizedTextService, umbracoApiControllerTypeCollection, eventAggregator)
    {
    }
}
