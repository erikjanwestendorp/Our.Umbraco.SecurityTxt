using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Our.Umbraco.SecurityTxt.Services;

namespace Our.Umbraco.SecurityTxt.Middleware;

public class SecurityTxtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ISecurityTxtService _securityTxtService;
    private readonly Configuration.SecurityTxtSettings _settings;

    public SecurityTxtMiddleware(RequestDelegate next, ISecurityTxtService securityTxtService, IOptions<Configuration.SecurityTxtSettings> settings)
    {
        _next = next;
        _securityTxtService = securityTxtService;
        _settings = settings.Value;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Path.Equals(_settings.Path, StringComparison.InvariantCultureIgnoreCase))
        {
            await _next.Invoke(context); 
            return;
        }

        var securityTxt = _securityTxtService.GetContent();

        if (string.IsNullOrWhiteSpace(securityTxt))
        {
            await _next.Invoke(context);
            return;
        }

        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync(securityTxt);
    }
}
