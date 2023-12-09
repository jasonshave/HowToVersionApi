using System.Net.Http.Json;
using HowToVersionApi.Contracts.V2023_11_20;

namespace HowToVersionApi.Tests.V2023_11_20;

public class GetWeatherScenario : ScenarioBase
{
    public override string Version { get; } = V20231120.Version;

    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    public override string Path { get; set; } = V20231120.RequestPath;

    public override Func<HttpResponseMessage, ValueTask>? HttpResponseValidation { get; } = async response =>
    {
        response.StatusCode.Should().Be(HttpStatusCode.OK);

        var data = await response.Content.ReadFromJsonAsync<WeatherForecast[]>();

        data.Should().NotBeEmpty();
        data.Length.Should().Be(5);
    };
}