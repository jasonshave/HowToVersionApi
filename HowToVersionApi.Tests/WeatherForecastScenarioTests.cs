using HowToVersionApi.Contracts.V2023_11_20;
using HowToVersionApi.Contracts.V2023_11_22;
using HowToVersionApi.Contracts.V2023_12_8;
using HowToVersionApi.Tests.V2023_12_08;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace HowToVersionApi.Tests;

public class WeatherForecastScenarioTests : IClassFixture<WebServerFixture<Program>>
{
    private readonly WebServerFixture<Program> _fixture;
    private readonly ILogger<WeatherForecastScenarioTests> _logger;

    public WeatherForecastScenarioTests(ITestOutputHelper testOutputHelper, WebServerFixture<Program> fixture)
    {
        _fixture = fixture;
        _fixture.TestOutputHelper = testOutputHelper;
        _logger = _fixture.Services.GetRequiredService<ILogger<WeatherForecastScenarioTests>>();
    }

    [Fact]
    public async Task ExecuteScenario_GetWeatherV20_ShouldValidate()
    {
        // arrange
        var client = _fixture.CreateClient();

        // act + assert
        var getWeatherScenario = _fixture.TestingFramework.GetScenario<V2023_11_20.GetWeatherTestScenario>();
        await getWeatherScenario.ProcessAsync(client, _logger);
    }

    [Fact]
    public async Task ExecuteScenario_GetWeatherV21_ShouldValidate()
    {
        // arrange
        var client = _fixture.CreateClient();

        // act + assert
        var getWeatherScenario = _fixture.TestingFramework.GetScenario<V2023_11_21.GetWeatherTestScenario>();
        await getWeatherScenario.ProcessWithResultAsync(client, _logger);
    }

    [Fact]
    public async Task ExecuteScenario_GetWeatherV22_ShouldValidate()
    {
        // arrange
        var client = _fixture.CreateClient();

        // act + assert
        var getWeatherScenario = _fixture.TestingFramework.GetScenario<V2023_11_22.GetWeatherTestScenario>();
        await getWeatherScenario.ProcessWithResultAsync(client, _logger);
    }

    [Fact]
    public async Task ExecuteScenario_GetWeatherSummaryByIdV22_ShouldValidate()
    {
        // arrange
        var client = _fixture.CreateClient();

        // act + assert
        var getWeatherScenario = _fixture.TestingFramework.GetScenario<V2023_11_22.GetWeatherSummaryById>();
        var version = V20231122.ApiVersion;
        getWeatherScenario.Path = string.Format(getWeatherScenario.Path, version);
        await getWeatherScenario.ProcessWithResultAsync(client, _logger);
    }

    [Theory]
    [InlineData(V20231122.ApiVersion)]
    [InlineData(V20231208.ApiVersion)]
    public async Task ExecuteScenario_GetWeatherSummaryById_ShouldValidate(string version)
    {
        // arrange
        var client = _fixture.CreateClient();

        // act + assert
        var getWeatherScenario = _fixture.TestingFramework.GetScenario<V2023_11_22.GetWeatherSummaryById>();
        getWeatherScenario.Path = string.Format(getWeatherScenario.Path, version);
        await getWeatherScenario.ProcessWithResultAsync(client, _logger);
    }

    [Theory]
    [InlineData("Edmonton")]
    [InlineData("Calgary")]
    public async Task ExecuteScenario_GetGeocodingDataByCityScenario_ReturnsValidWeather(string cityName)
    {
        // arrange
        var client = _fixture.CreateClient();
        
        // act
        var scenario = _fixture.TestingFramework.GetScenario<GetGeocodingDataByCity>();
        scenario.Path = string.Format(scenario.Path, cityName);

        var result = await scenario.ProcessWithResultAsync(client, _logger);

        // assert
        result.First().Name.Should().Be(cityName);
    }
}