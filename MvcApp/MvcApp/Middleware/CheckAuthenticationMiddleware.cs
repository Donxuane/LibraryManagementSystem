using MvcApp.Models;
using NuGet.Packaging.Signing;

namespace MvcApp.Middleware;

public class CheckAuthenticationMiddleware
{
    private readonly RequestDelegate _next;

    public CheckAuthenticationMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        var user = User.user;
        var userName = context.Request.Query["userName"];
        var password = context.Request.Query["password"];

        if (user.FirstOrDefault(x => x.UserName == userName) != null && user.FirstOrDefault(x => x.UserPassword == password) != null)
        {
            context.Response.Redirect("Index");
        }
        await _next(context);
    }
}
