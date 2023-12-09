using HowToVersionApi.Contracts.V2023_11_22;
using System.Net.Http.Json;

namespace HowToVersionApi.Tests.V2023_11_22;

public class WeatherForecastIntegrationTests(WebServerFixture<Program> _fixture) : IClassFixture<WebServerFixture<Program>>
{
    [Fact]
    public async Task GetWeather_V20231122()
    {
        // arrange
        var client = _fixture.CreateClient();

        // act
        var response = await client.GetAsync("/weatherForecast?api-version=2023-11-22");
        var forecasts = await response.Content.ReadFromJsonAsync<IEnumerable<WeatherForecast>>();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        forecasts.Should().NotBeNullOrEmpty();
        forecasts.Count().Should().Be(5);
        forecasts.First().Time.Should().NotBe(default);
        forecasts.Should().AllSatisfy(x => x.City.Should().Be("Edmonton"));
    }
}