using HowToVersionApi.Api.OpenWeather.Models;
using HowToVersionApi.Api.OpenWeather.Services;
using HowToVersionApi.Contracts.V2023_12_8;

namespace HowToVersionApi.Api.Controllers.V2023_12_08;

[ApiController]
[ApiVersion(V20231208.ApiVersion)]
[Route("[controller]")]
public class OpenWeatherController : ControllerBase
{
    private readonly IOpenWeatherService _openWeatherService;

    public OpenWeatherController(IOpenWeatherService openWeatherService)
    {
        _openWeatherService = openWeatherService;
    }

    [HttpGet(Name = "GetWeatherByCity")]
    [MapToApiVersion(V20231208.ApiVersion)]
    public async Task<IActionResult> GetOpenWeatherByCity([FromQuery] string city)
    {
        var geocodingData = await _openWeatherService.GetGeocodingAsync(city);
        var openWeather = await _openWeatherService.GetWeatherAsync(geocodingData.First());

        return openWeather is null ? NotFound() : Ok(openWeather);
    }

    [HttpPost(Name = "GetWeatherByCoordinates")]
    [MapToApiVersion(V20231208.ApiVersion)]
    public async Task<IActionResult> GetOpenWeather(GetWeatherByCoordinates getWeatherByCoordinates)
    {
        var coordinates = new GeocodingData()
        {
            Lat = getWeatherByCoordinates.Latitude,
            Lon = getWeatherByCoordinates.Longitude
        };
        var openWeather = await _openWeatherService.GetWeatherAsync(coordinates);

        return openWeather is null ? NotFound() : Ok(openWeather);
    }
}