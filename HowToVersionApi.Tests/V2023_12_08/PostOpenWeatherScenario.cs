using HowToVersionApi.Api.OpenWeather.Models;
using HowToVersionApi.Contracts.V2023_12_8;

namespace HowToVersionApi.Tests.V2023_12_08;

public class PostOpenWeatherScenario : TestScenario<WeatherData>
{
    public override HttpMethod HttpMethod { get; } = HttpMethod.Post;

    public override string Path { get; set; } = V20231208.OpenWeatherApiPath + "/?api-version=" + V20231208.ApiVersion;

    public override Action<WeatherData?>? DataValidation { get; } = data =>
    {
        data.Should().NotBeNull();
    };
}