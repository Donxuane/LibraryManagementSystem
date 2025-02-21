namespace MvcApp.Middleware;

public class GetUserIpAdressMiddleware
{
    private readonly RequestDelegate _next;

    public GetUserIpAdressMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task InvokeAsync(HttpContext context)
    {
        string? userIp = context.Connection.RemoteIpAddress?.ToString();
        string? serverIp = context.Connection.LocalIpAddress?.ToString();
        Console.WriteLine($"User Ip Adress: {userIp}\nServer Ip Adress: {serverIp}");
        await _next(context);
    }
}

public class GetUserIp
{
    private readonly RequestDelegate _next;

    public GetUserIp(RequestDelegate next) => _next = next;

    public async Task InvokeAsync(HttpContext context)
    {
        string? ip = context.GetServerVariable("HTTP_X_FORWARDED_FOR");

        if(string.IsNullOrEmpty(ip))
        {
            ip = context.GetServerVariable("REMOTE_ADDR");
        }
        Console.WriteLine($"User Ip: {ip}");
        await _next(context);
    }
}