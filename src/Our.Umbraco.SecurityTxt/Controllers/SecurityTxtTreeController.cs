using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Our.Umbraco.SecurityTxt.Extensions;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Trees;
using Umbraco.Cms.Web.BackOffice.Trees;
using Umbraco.Cms.Web.Common.Attributes;
using Umbraco.Extensions;

namespace Our.Umbraco.SecurityTxt.Controllers;

[Tree(Constants.Applications.Settings, Alias, TreeTitle = Title, TreeGroup = Group, SortOrder = 1)]
[PluginController("SecurityTxt")]
public class SecurityTxtTreeController : TreeController
{
    public const string Alias = SecurityTxtConstants.Trees.SecurityTxt.Alias;
    public const string Group = SecurityTxtConstants.Trees.SecurityTxt.Group;
    public const string Title = SecurityTxtConstants.Trees.SecurityTxt.Title;

    private readonly Configuration.SecurityTxtSettings _settings;
    private readonly IDomainService _domainService;

    public SecurityTxtTreeController(
        ILocalizedTextService localizedTextService,
        UmbracoApiControllerTypeCollection umbracoApiControllerTypeCollection,
        IEventAggregator eventAggregator, IOptions<Configuration.SecurityTxtSettings> settings, IDomainService domainService)
        : base(localizedTextService, umbracoApiControllerTypeCollection, eventAggregator)
    {
        _domainService = domainService;
        _settings = settings.Value;
    }

    protected override ActionResult<TreeNode?> CreateRootNode(FormCollection queryStrings)
    {
        var rootResult = base.CreateRootNode(queryStrings);
        if (rootResult.Result is not null)
        {
            return rootResult; 
        }

        var root = rootResult.Value;

        root.RoutePath = $"{SectionAlias}/{TreeAlias}/detail";
        root.Icon = RootIcon();
        root.HasChildren = _settings.MultiDomain;
        root.MenuUrl = null;

        return root;
    }

    protected override ActionResult<MenuItemCollection> GetMenuForNode(string id, FormCollection queryStrings)
    {
        return null;
    }

    protected override ActionResult<TreeNodeCollection> GetTreeNodes(string id, FormCollection queryStrings)
    {
        var nodes = new TreeNodeCollection();

        if (!_settings.MultiDomain)
        {
            return nodes;
        }
        
        if (id == Constants.System.Root.ToInvariantString())
        {
            var domains = _domainService.GetAll(true);

            if (domains.TryGetListIfAny(out var domainList))
            {

                foreach (var thing in domainList)
                {
                    var node = CreateTreeNode(thing.Id.ToString(), "-1", queryStrings, thing.DomainName, "icon-files", false);
                    nodes.Add(node);
                }
            }
        }

        return nodes;
    }

    private string RootIcon()
    {
        return _settings.MultiDomain ? "icon-folder" : "icon-files";
    }
}
