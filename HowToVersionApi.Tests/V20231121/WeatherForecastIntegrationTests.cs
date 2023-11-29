using System.Net;
using System.Net.Http.Json;
using FluentAssertions;

namespace HowToVersionApi.Tests.V20231121;

public class WeatherForecastIntegrationTests(WebServerFixture<Program> fixture) 
    : IClassFixture<WebServerFixture<Program>>
{
    [Fact]
    public async Task GetWeather_V20231121()
    {
        // arrange
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync($"/weatherforecast?api-version=2023-11-21");
        var forecasts = await response.Content.ReadFromJsonAsync<Contracts.V20231121.WeatherForecast[]>();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        forecasts.Should().NotBeEmpty();
        forecasts.Length.Should().Be(5);
        forecasts.First().Time.Should().NotBe(default);
    }
}