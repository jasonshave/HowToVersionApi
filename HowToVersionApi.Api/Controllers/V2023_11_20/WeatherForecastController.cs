using HowToVersionApi.Contracts.V2023_11_20;
using HowToVersionApi.Contracts.V2023_11_21;
using HowToVersionApi.Contracts.V2023_11_22;

namespace HowToVersionApi.Controllers.V2023_11_20;

[ApiController]
[ApiVersion(V20231120.ApiVersion)]
[ApiVersion(V20231121.ApiVersion)]
[ApiVersion(V20231122.ApiVersion)]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
{
    private static readonly string[] Summaries = 
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [HttpGet(Name = "GetSummaries")]
    [Route("/summaries")]
    public string[] GetSummaries() => Summaries;

    [MapToApiVersion(V20231120.ApiVersion)]
    [HttpGet(Name = "GetWeatherForecast20")]
    public IEnumerable<Contracts.V2023_11_20.WeatherForecast> GetWeather()
    {
        logger.LogInformation($"Invoking weather forecast for version {V20231120.ApiVersion}");

        return Enumerable.Range(1, 5).Select(index => new Contracts.V2023_11_20.WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
    }
}