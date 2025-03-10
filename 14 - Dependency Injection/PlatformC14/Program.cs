using Platform;
using Platform.Services;
using System.Diagnostics;

internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddSingleton<IResponseFormatter, HtmlResponseFormatter>();

        var app = builder.Build();
        app.UseMiddleware<WeatherMiddleware>();

        // Endpoint functions
        app.MapGet("middleware/function", async (HttpContext context, IResponseFormatter formatter) =>
        {
            await formatter.Format(context, "Middleware Function: It is snowing in Chicago");
        });

        app.MapGet("endpoint/function", async (HttpContext context, IResponseFormatter formatter) =>
        {
            await formatter.Format(context, "Endpoint Function: It is sunny in LA");
        });

        app.MapGet("/", () => $"Worker Process Name: {Process.GetCurrentProcess().ProcessName}");

        app.Run();
    }
}
