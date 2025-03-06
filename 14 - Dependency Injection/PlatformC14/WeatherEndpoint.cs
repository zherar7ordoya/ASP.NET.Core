using Platform.Services;

namespace Platform;

public class WeatherEndpoint(IResponseFormatter responseFormatter)
{
    private readonly IResponseFormatter formatter = responseFormatter;

    public async Task Endpoint(HttpContext context)
    {
        await formatter.Format(context, "Endpoint Class: It is cloudy in Milan");
    }
}
