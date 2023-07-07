using Microsoft.AspNetCore.Http;

namespace Our.Umbraco.SecurityTxt.Middleware;

public class SecurityTxtMiddleware
{
    private readonly RequestDelegate _next;

    public SecurityTxtMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        if (!context.Request.Path.Equals("/.well-known/security.txt", StringComparison.InvariantCultureIgnoreCase))
        {
            await _next.Invoke(context);
            return;
        }

        var securityTxt = "todo";

        if (string.IsNullOrWhiteSpace(securityTxt))
        {
            await _next.Invoke(context);
            return;
        }

        context.Response.ContentType = "text/plain";
        await context.Response.WriteAsync(securityTxt);
    }
}
