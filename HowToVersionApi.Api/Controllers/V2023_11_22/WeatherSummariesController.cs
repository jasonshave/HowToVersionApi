using HowToVersionApi.Contracts.V2023_11_22;
using HowToVersionApi.Contracts.V2023_12_8;

namespace HowToVersionApi.Api.Controllers.V2023_11_22;

[ApiController]
[ApiVersion(V20231122.ApiVersion)]
[ApiVersion(V20231208.ApiVersion)]
[Route("[controller]")]
public class WeatherSummariesController : ControllerBase
{
    [HttpGet(Name = "GetWeatherSummaryById")]
    [MapToApiVersion(V20231122.ApiVersion)]
    [MapToApiVersion(V20231208.ApiVersion)]
    [Route("{id}")]
    public IActionResult GetSummaryById([FromRoute] int id)
    {
        var summaries = new[] { "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching" };
        return Ok(new { FeelsLike = summaries[id] });
    }
}