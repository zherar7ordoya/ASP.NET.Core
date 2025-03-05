using Platform.Services;

namespace Platform;

public class WeatherMiddleware(
    RequestDelegate nextDelegate,
    IResponseFormatter respFormatter)
{
    private readonly RequestDelegate next = nextDelegate;
    private readonly IResponseFormatter formatter = respFormatter;

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path == "/middleware/class")
        {
            await formatter.Format(context, "Middleware Class: It is raining in London");
        }
        else
        {
            await next(context);
        }
    }
}
