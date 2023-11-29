using HowToVersionApi.Contracts.V20231122;

namespace HowToVersionApi.Controllers.V2023_11_22;

[ApiController]
[ApiVersion(V20231122.ApiVersion)]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
{
    [MapToApiVersion(V20231122.ApiVersion)]
    [HttpGet(Name = "GetWindSpeed")]
    [Route("/windspeed")]
    public WindSpeed GetWindSpeed()
    {
        logger.LogInformation($"Invoking weather forecast for version {V20231122.ApiVersion}");

        return new WindSpeed()
        {
            SpeedInMph = 11
        };
    }
}