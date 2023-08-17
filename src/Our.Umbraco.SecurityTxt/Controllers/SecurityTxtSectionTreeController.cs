using Microsoft.Extensions.Options;
using Our.Umbraco.SecurityTxt.Sections;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Web.BackOffice.Trees;
using Umbraco.Cms.Web.Common.Attributes;

namespace Our.Umbraco.SecurityTxt.Controllers;

[Tree(SecuritySection.SectionAlias, Alias, TreeTitle = Title, TreeGroup = Group, SortOrder = 1)]
[PluginController("SecurityTxt")]
public class SecurityTxtSectionTreeController : SecurityTxtTreeController
{
    public SecurityTxtSectionTreeController(ILocalizedTextService localizedTextService, UmbracoApiControllerTypeCollection umbracoApiControllerTypeCollection, IEventAggregator eventAggregator, IOptions<Configuration.SecurityTxtSettings> settings, IDomainService domainService) : base(localizedTextService, umbracoApiControllerTypeCollection, eventAggregator, settings, domainService)
    {
    }
}
