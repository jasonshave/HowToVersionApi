using System.Net;
using System.Net.Http.Json;
using FluentAssertions;

namespace HowToVersionApi.Tests.V20231120;

public class WeatherForecastIntegrationTests(WebServerFixture<Program> fixture) 
    : IClassFixture<WebServerFixture<Program>>
{
    [Theory]
    [ClassData(typeof(TestVersionGenerator))]
    public async Task GetSummaryTest(string path)
    {
        // arrange
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync("/summaries?api-version=" + path);
        var summaries = await response.Content.ReadFromJsonAsync<string[]>();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        summaries.Should().NotBeEmpty();
        summaries.Length.Should().Be(10);
    }

    [Fact]
    public async Task GetWeather_V20231120()
    {
        // arrange
        var client = fixture.CreateClient();

        // act
        var response = await client.GetAsync($"/weatherforecast?api-version=2023-11-20");
        var forecasts = await response.Content.ReadFromJsonAsync<Contracts.V20231120.WeatherForecast[]>();

        // assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        forecasts.Should().NotBeEmpty();
        forecasts.Length.Should().Be(5);
    }
}