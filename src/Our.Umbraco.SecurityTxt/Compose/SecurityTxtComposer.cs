using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Our.Umbraco.SecurityTxt.Dashboards;
using Our.Umbraco.SecurityTxt.Middleware;
using Our.Umbraco.SecurityTxt.Sections;
using Umbraco.Cms.Core.Composing;
using Umbraco.Cms.Core.DependencyInjection;
using Umbraco.Cms.Web.Common.ApplicationBuilder;

namespace Our.Umbraco.SecurityTxt.Compose;
public class SecurityTxtComposer : IComposer
{
    public void Compose(IUmbracoBuilder builder)
    {
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
    }
}
