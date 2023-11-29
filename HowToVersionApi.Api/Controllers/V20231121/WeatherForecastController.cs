using HowToVersionApi.Contracts.V20231121;

namespace HowToVersionApi.Controllers.V2023_11_21;

[ApiController]
[ApiVersion(V20231121.ApiVersion)]
[Route("[controller]")]
public class WeatherForecastController(ILogger<WeatherForecastController> logger) : ControllerBase
{
    private static readonly string[] Summaries = 
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    [MapToApiVersion(V20231121.ApiVersion)]
    [HttpGet(Name = "GetWeatherForecast21")]
    public IEnumerable<WeatherForecast> GetWeather()
    {
        logger.LogInformation($"Invoking weather forecast for version {V20231121.ApiVersion}");

        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Time = TimeOnly.FromDateTime(DateTime.Now.AddHours(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }
}