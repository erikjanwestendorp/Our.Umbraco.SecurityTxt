using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Our.Umbraco.SecurityTxt.Controllers;
using Our.Umbraco.SecurityTxt.Dashboards;
using Our.Umbraco.SecurityTxt.Middleware;
using Our.Umbraco.SecurityTxt.Repositories;
using Our.Umbraco.SecurityTxt.Repositories.Implementation;
using Our.Umbraco.SecurityTxt.Sections;
using Our.Umbraco.SecurityTxt.Services;
using Our.Umbraco.SecurityTxt.Services.Implementation;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Web.Common.ApplicationBuilder;
using Umbraco.Extensions;

namespace Our.Umbraco.SecurityTxt.Compose;
public class SecurityTxtComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
        builder.ManifestFilters().Append<ManifestFilter>();
        builder.Services.Configure<UmbracoPipelineOptions>(options =>
        {
            options.AddFilter(new UmbracoPipelineFilter(
                "Security Security.txt",
                applicationBuilder => { applicationBuilder.UseMiddleware<SecurityTxtMiddleware>(); },
                applicationBuilder => { },
                applicationBuilder => { }
            ));
        });

        builder.Services.AddOptions<Configuration.SecurityTxtSettings>().Bind(builder.Config.GetSection(SecurityTxtConstants.SettingSections.SecurityTxtSettings));

        var securityTxtSettings = builder.Config.GetSection(SecurityTxtConstants.SettingSections.SecurityTxtSettings)
            .Get<Configuration.SecurityTxtSettings>();
        
        if (securityTxtSettings is {AsSection: true})
        {
            builder.AddSection<SecuritySection>();
            builder.AddDashboard<WelcomeDashboard>();
            builder.Trees()?.RemoveTreeController<SecurityTxtTreeController>();
        }
        else
        {
            builder.Trees()?.RemoveTreeController<SecurityTxtSectionTreeController>();
        }


        builder.Services.AddUnique<ISecurityTxtRepository, SecurityTxtRepository>();
        builder.Services.AddUnique<ISecurityTxtService, SecurityTxtService>();


    }
}
