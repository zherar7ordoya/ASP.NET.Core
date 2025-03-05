namespace Platform;

public class WeatherMiddleware(RequestDelegate nextDelegate)
{
    private readonly RequestDelegate next = nextDelegate;

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path == "/middleware/class")
        {
            await context.Response.WriteAsync("Middleware Class: It is raining in London");
        }
        else
        {
            await next(context);
        }
    }
}
