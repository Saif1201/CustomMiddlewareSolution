using TestMiddleware.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<CustomMiddleware>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Use( async (HttpContext context, RequestDelegate next) => 
{
    await context.Response.WriteAsync("Middleware 1-- Start\n");
    await next(context);
    await context.Response.WriteAsync("Middleware 1-- End\n");
});

app.UseCustomMiddleware();

app.Use( async (HttpContext context, RequestDelegate next) =>
{
    await context.Response.WriteAsync("Middleware 3 -- Start\n");
    await next(context);
    await context.Response.WriteAsync("Middleware 3 -- End\n");

});

app.Run( async (context) => await context.Response.WriteAsync("Last middleware\n"));

app.Run();
