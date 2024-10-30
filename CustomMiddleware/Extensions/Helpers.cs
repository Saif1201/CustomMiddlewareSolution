
namespace TestMiddleware.Extensions;

    public static class Helpers
    {
    public static IApplicationBuilder UseCustomMiddleware(this IApplicationBuilder app)
    {
        return app.UseMiddleware<CustomMiddleware>();
    }
    }
public class CustomMiddleware : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        await context.Response.WriteAsync("Middleware 2 -- Start\n");
        await next(context);
        await context.Response.WriteAsync("Middleware 2 -- End\n");

    }
}

