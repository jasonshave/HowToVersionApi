using HowToVersionApi.Contracts.V2023_11_22;
using HowToVersionApi.Contracts.V2023_12_8;
using HowToVersionApi.Tests.V2023_12_08;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace HowToVersionApi.Tests;

public class WeatherForecastScenarioTests : IClassFixture<WebServerFixture<Program>>
{
    private readonly ITestingRegistry _testRegistry;

    private readonly HttpClient _httpClient;

    public WeatherForecastScenarioTests(ITestOutputHelper testOutputHelper, WebServerFixture<Program> fixture)
    {
        fixture.TestOutputHelper = testOutputHelper;
        _testRegistry = fixture.Services.GetRequiredService<ITestingRegistry>();
        _httpClient = fixture.CreateClient();
    }

    [Fact]
    public async Task ExecuteScenario_GetWeatherV20_ShouldValidate()
    {
        // arrange
        var scenario = _testRegistry.GetScenario<V2023_11_20.GetWeatherTestScenario>();

        // act + assert
        await scenario.ProcessAsync(_httpClient);
    }

    [Fact]
    public async Task ExecuteScenario_GetWeatherV21_ShouldValidate()
    {
        // arrange
        var scenario = _testRegistry.GetScenario<V2023_11_21.GetWeatherTestScenario>();

        // act + assert
        await scenario.ProcessAsync(_httpClient);
    }

    [Fact]
    public async Task ExecuteScenario_GetWeatherV22_ShouldValidate()
    {
        // arrange
        var scenario = _testRegistry.GetScenario<V2023_11_22.GetWeatherTestScenario>();

        // act + assert
        await scenario.ProcessAsync(_httpClient);
    }

    [Fact]
    public async Task ExecuteScenario_GetWeatherSummaryByIdV22_ShouldValidate()
    {
        // arrange
        var version = V20231122.ApiVersion;
        var scenario = _testRegistry.GetScenario<V2023_11_22.GetWeatherSummaryByIdScenario>();

        // act + assert
        scenario.Path = string.Format(scenario.Path, version);
        await scenario.ProcessAsync(_httpClient);
    }

    [Theory]
    [InlineData(V20231122.ApiVersion)]
    [InlineData(V20231208.ApiVersion)]
    public async Task ExecuteScenario_GetWeatherSummaryById_ShouldValidate(string version)
    {
        // arrange
        var scenario = _testRegistry.GetScenario<V2023_11_22.GetWeatherSummaryByIdScenario>();

        // act + assert
        scenario.Path = string.Format(scenario.Path, version);
        await scenario.ProcessAsync(_httpClient);
    }

    [Theory]
    [InlineData("Edmonton")]
    [InlineData("Calgary")]
    public async Task ExecuteScenario_GetGeocodingDataByCityScenario_ReturnsValidWeather(string cityName)
    {
        // arrange
        var scenario = _testRegistry.GetScenario<GetGeocodingDataByCityScenario>();

        // act
        var result = await scenario.ProcessAsync(_httpClient, path => string.Format(path, cityName));

        // assert
        result.First().Name.Should().Be(cityName);
    }

    [Fact]
    public async Task ExecuteScenario_PostOpenWeatherRequest_Validates()
    {
        // arrange
        var geoScenario = _testRegistry.GetScenario<GetGeocodingDataByCityScenario>();
        var weatherScenario = _testRegistry.GetScenario<PostOpenWeatherScenario>();
        
        // act
        var geoResult = await geoScenario.ProcessAsync(_httpClient, path => string.Format(path, "Edmonton"));

        var request = new GetWeatherByCoordinates(geoResult.First().Lat, geoResult.First().Lon);
        var result = await weatherScenario.ProcessAsync(request, _httpClient);

        // assert
        result.Name.Should().Be("Edmonton");
    }
}