using HowToVersionApi.Api.Requests.V2023_11_22;
using HowToVersionApi.Contracts.V2023_11_22;
using HowToVersionApi.Contracts.V2023_12_8;
using MediatR;

namespace HowToVersionApi.Api.Controllers.V2023_11_22;

[ApiController]
[ApiVersion(V20231122.ApiVersion)]
[ApiVersion(V20231208.ApiVersion)]
[Route("[controller]")]
public class WeatherForecastController(IMediator mediator) : ControllerBase
{
    [MapToApiVersion(V20231122.ApiVersion)]
    [MapToApiVersion(V20231208.ApiVersion)]
    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> GetWeather22()
    {
        var weathers = await mediator.Send(new GetWeatherForecast());

        return weathers;
    }
}