using HowToVersionApi.Api.OpenWeather.Services;
using HowToVersionApi.Contracts.V2023_12_8;

namespace HowToVersionApi.Api.Controllers.V2023_12_08;

[ApiController]
[ApiVersion(V20231208.ApiVersion)]
[Route("[controller]")]
public class GeocodingController : ControllerBase
{
    private readonly IOpenWeatherService _openWeatherService;

    public GeocodingController(IOpenWeatherService openWeatherService)
    {
        _openWeatherService = openWeatherService;
    }

    [HttpGet(Name = "GetGeocodingDataByCity")]
    [MapToApiVersion(V20231208.ApiVersion)]
    public async Task<IActionResult> GetGeocodingDataByCity([FromQuery] string city)
    {
        var geocodingData = await _openWeatherService.GetGeocodingAsync(city);
        return Ok(geocodingData);
    }
}