using HowToVersionApi.Contracts.V2023_11_21;
using System.Net.Http.Json;

namespace HowToVersionApi.Tests.V2023_11_21;

public class WeatherForecastIntegrationTests(WebServerFixture<Program> _fixture) : IClassFixture<WebServerFixture<Program>>
{
    [Fact]
    public async Task GetWeather_V20231121()
    {
        // arrange
        var client = _fixture.CreateClient();

        // act
        var response = await client.GetAsync("/weatherForecast?api-version=2023-11-21");
        var forecasts = await response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        forecasts.Should().NotBeEmpty();
        forecasts.Count().Should().Be(5);
        forecasts.First().Time.Should().NotBe(default);
    }
}