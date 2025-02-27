//using Microsoft.Extensions.Options;
//using Platform;

//var builder = WebApplication.CreateBuilder(args);

//builder.Services.Configure<MessageOptions>(options =>
//{
//    options.CityName = "Albany";
//});

//var app = builder.Build();

//app.UseMiddleware<LocationMiddleware>();

//app.MapGet("/", () => "Hello World!");
//app.Run();

//******************************************************************************

using Platform;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.UseMiddleware<Population>();
app.UseMiddleware<Capital>();

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapGet("routing", async context =>
    {
        await context.Response.WriteAsync("Request Was Routed");
    });

    endpoints.MapGet("dev", async context =>
    {
        await context.Response.WriteAsync("Gerardo Tordoya");
    });
});

app.Run(async (context) =>
{
    await context.Response.WriteAsync("Terminal Middleware Reached");
});

app.Run();
