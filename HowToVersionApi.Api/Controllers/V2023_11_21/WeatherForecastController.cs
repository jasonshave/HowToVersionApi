using HowToVersionApi.Abstractions;
using HowToVersionApi.Contracts.V2023_11_21;

namespace HowToVersionApi.Api.Controllers.V2023_11_21;

[ApiController]
[ApiVersion(V20231121.ApiVersion)]
[Route("[controller]")]
public class WeatherForecastController(
    IWeatherService<WeatherForecast> weatherService) : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> GetWeather21()
    {
        var weathers = weatherService.GetWeather();

        return weathers;
    }
}