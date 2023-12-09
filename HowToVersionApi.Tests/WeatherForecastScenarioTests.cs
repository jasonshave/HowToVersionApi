using HowToVersionApi.Contracts.V2023_11_20;
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
    public async Task ExecuteScenario_GetWeatherV21_ShouldValidate()
    {
        // arrange
        var client = _fixture.CreateClient();

        // act + assert
        var getWeatherScenario = _fixture.TestingFramework.GetScenarioWithResult<V2023_11_21.GetWeatherScenario, Contracts.V2023_11_21.WeatherForecast[]>();

        await getWeatherScenario.ProcessScenarioAsync(client, _logger);
    }

    [Fact]
    public async Task ExecuteScenario_GetWeatherV22_ShouldValidate()
    {
        // arrange
        var client = _fixture.CreateClient();

        // act + assert
        var getWeatherScenario = _fixture.TestingFramework.GetScenarioWithResult<V2023_11_22.GetWeatherScenario, IEnumerable<Contracts.V2023_11_22.WeatherForecast>>();

        await getWeatherScenario.ProcessScenarioAsync(client, _logger);
    }

    [Fact]
    public async Task ExecuteScenario_GetWeatherSummaryByIdV22_ShouldValidate()
    {
        // arrange
        var client = _fixture.CreateClient();

        // act + assert
        var getWeatherScenario = _fixture.TestingFramework.GetScenarioWithResult<V2023_11_22.GetWeatherSummaryById, KeyValuePair<string, string>>();
        await getWeatherScenario.ProcessScenarioAsync(client, _logger);
    }

    //[Theory]
    //[ClassData(typeof(TestDataGenerator))]
    //public async Task ExecuteScenario_GetWeathers_ShouldValidate(TestScenarioData testScenarioData)
    //{
    //    // arrange
    //    var client = _fixture.CreateClient();

    //    // act + assert
    //    await testScenarioData.TestScenario.ProcessScenarioAsync(client, _logger);
    //}
}