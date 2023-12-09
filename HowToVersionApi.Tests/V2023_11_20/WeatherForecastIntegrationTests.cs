using HowToVersionApi.Contracts.V2023_11_20;

namespace HowToVersionApi.Tests.V2023_11_20;

public class WeatherForecastIntegrationTests(WebServerFixture<Program> _fixture) : IClassFixture<WebServerFixture<Program>>
{
    [Fact]
    public async Task GetWeather_V20231120()
    {
        // arrange
        var client = _fixture.CreateClient();

        // act
        var response = await client.GetAsync("/weatherForecast?api-version=2023-11-20");
        var stream = await response.Content.ReadAsStreamAsync();
        var forecasts = await JsonSerializer.DeserializeAsync<WeatherForecast[]>(stream);

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        forecasts.Should().NotBeEmpty();
        forecasts.Length.Should().Be(5);
    }
}