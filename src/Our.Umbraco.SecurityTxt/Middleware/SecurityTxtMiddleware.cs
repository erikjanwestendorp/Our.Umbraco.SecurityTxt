using Microsoft.AspNetCore.Http;
using Our.Umbraco.SecurityTxt.Services;

namespace Our.Umbraco.SecurityTxt.Middleware;

public class SecurityTxtMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ISecurityTxtService _securityTxtService;

    public SecurityTxtMiddleware(RequestDelegate next, ISecurityTxtService securityTxtService)
    {
        _next = next;
        _securityTxtService = securityTxtService;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Path.Equals("/.well-known/security.txt", StringComparison.InvariantCultureIgnoreCase))
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
