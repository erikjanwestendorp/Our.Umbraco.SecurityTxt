using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Umbraco.Cms.Core;
using Umbraco.Cms.Core.Events;
using Umbraco.Cms.Core.Services;
using Umbraco.Cms.Core.Trees;
using Umbraco.Cms.Web.BackOffice.Trees;
using Umbraco.Cms.Web.Common.Attributes;

namespace Our.Umbraco.SecurityTxt.Controllers;

[Tree(Constants.Applications.Settings, Alias, TreeTitle = "Security.txt", TreeGroup = "SecurityTxt", SortOrder = 1)]
[PluginController("SecurityTxt")]
public class SecurityTxtTreeController : TreeController
{
    public const string Alias = "SecurityTxt";

    public SecurityTxtTreeController(
        ILocalizedTextService localizedTextService,
        UmbracoApiControllerTypeCollection umbracoApiControllerTypeCollection,
        IEventAggregator eventAggregator)
        : base(localizedTextService, umbracoApiControllerTypeCollection, eventAggregator)
    { }

    protected override ActionResult<TreeNode?> CreateRootNode(FormCollection queryStrings)
    {
        var rootResult = base.CreateRootNode(queryStrings);
        if (rootResult.Result is not null)
        {
            return rootResult; 
        }

        var root = rootResult.Value;

        root.RoutePath = $"{SectionAlias}/{TreeAlias}/detail";
        root.Icon = "icon-files";
        root.HasChildren = false;
        root.MenuUrl = null;

        return root;
    }

    protected override ActionResult<MenuItemCollection> GetMenuForNode(string id, FormCollection queryStrings)
    {
        return null;
    }

    protected override ActionResult<TreeNodeCollection> GetTreeNodes(string id, FormCollection queryStrings)
    {
        return new TreeNodeCollection();
    }
}
