using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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

        builder.AddSection<SecuritySection>();
        builder.AddDashboard<WelcomeDashboard>();

        builder.Services.AddUnique<ISecurityTxtRepository, SecurityTxtRepository>();
        builder.Services.AddUnique<ISecurityTxtService, SecurityTxtService>();
    }
}
