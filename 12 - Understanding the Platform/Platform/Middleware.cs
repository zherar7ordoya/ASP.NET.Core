using Microsoft.Extensions.Options;

namespace Platform
{

    public class QueryStringMiddleWare
    {
        private readonly RequestDelegate? next;

        public QueryStringMiddleWare() { }

        public QueryStringMiddleWare(RequestDelegate nextDelegate)
        {
            next = nextDelegate;
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Method == HttpMethods.Get && context.Request.Query["custom"] == "true")
            {
                if (!context.Response.HasStarted)
                {
                    context.Response.ContentType = "text/plain";
                }

                await context.Response.WriteAsync("Class-based Middleware \n");
            }
            if (next != null)
            {
                await next(context);
            }
        }
    }

    public class LocationMiddleware(RequestDelegate nextDelegate, IOptions<MessageOptions> opts)
    {
        private readonly RequestDelegate next = nextDelegate;
        private readonly MessageOptions options = opts.Value;

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path == "/location")
            {
                await context.Response.WriteAsync($"{options.CityName}, {options.CountryName}");
            }
            else
            {
                await next(context);
            }
        }
    }
}
