using HowToVersionApi.Abstractions;
using HowToVersionApi.Contracts.V2023_11_20;

namespace HowToVersionApi.Api.Controllers.V2023_11_20;

[ApiController]
[ApiVersion(V20231120.ApiVersion)]
[Route("[controller]")]
public class WeatherForecastController(IWeatherService<WeatherForecast> weatherService) : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        var weathers = weatherService.GetWeather();

        return weathers;
    }
}