using Platform;
using Platform.Services;

using System.Collections.Generic;

using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.Intrinsics.X86;

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

        //----------------------------------------------------------------------

        /*
         * Note:
         * GetValue<T> is preferred for non-string types, ensuring type safety,
         * while the indexer is suitable for simple string retrieval.
         * */

        //Get the Configuration Value using Generic GetValue
        string? MyCustomKeyValueGeneric = builder.Configuration.GetValue<string>("MyCustomKey", "DefaultValue");

        //Get the Configuration Value using Indexer
        string? MyCustomKeyValueIndexer = builder.Configuration["MyCustomKey"];

        //app.MapGet("/", () => $"{MyCustomKeyValueGeneric}");

        //----------------------------------------------------------------------

        app.MapGet("/", () => $"EnvironmentName: {app.Environment.EnvironmentName} \n" +
         $"ApplicationName: {app.Environment.ApplicationName} \n" +
         $"WebRootPath: {app.Environment.WebRootPath} \n" +
         $"ContentRootPath: {app.Environment.ContentRootPath}");

        //This will Start the Application
        app.Run();
    }
}
