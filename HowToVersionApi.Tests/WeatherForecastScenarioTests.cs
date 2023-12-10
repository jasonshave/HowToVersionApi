using HowToVersionApi.Contracts.V2023_11_22;
using HowToVersionApi.Contracts.V2023_12_8;
using HowToVersionApi.Tests.V2023_12_08;
using Microsoft.Extensions.DependencyInjection;
using Xunit.Abstractions;

namespace HowToVersionApi.Tests;

public class WeatherForecastScenarioTests : IClassFixture<WebServerFixture<Program>>
{
    private readonly WebServerFixture<Program> _fixture;
    private readonly ITestingRegistry _testRegistry;

    public WeatherForecastScenarioTests(ITestOutputHelper testOutputHelper, WebServerFixture<Program> fixture)
    {
        _fixture = fixture;
        _fixture.TestOutputHelper = testOutputHelper;
        _testRegistry = _fixture.Services.GetRequiredService<ITestingRegistry>();
    }

    [Fact]
    public async Task ExecuteScenario_GetWeatherV20_ShouldValidate()
    {
        // arrange
        var client = _fixture.CreateClient();

        // act + assert
        var getWeatherScenario = _testRegistry.GetScenario<V2023_11_20.GetWeatherTestScenario>();
        await getWeatherScenario.ProcessAsync(client);
    }

    [Fact]
    public async Task ExecuteScenario_GetWeatherV21_ShouldValidate()
    {
        // arrange
        var client = _fixture.CreateClient();

        // act + assert
        var getWeatherScenario = _testRegistry.GetScenario<V2023_11_21.GetWeatherTestScenario>();
        await getWeatherScenario.ProcessAsync(client);
    }

    [Fact]
    public async Task ExecuteScenario_GetWeatherV22_ShouldValidate()
    {
        // arrange
        var client = _fixture.CreateClient();

        // act + assert
        var getWeatherScenario = _testRegistry.GetScenario<V2023_11_22.GetWeatherTestScenario>();
        await getWeatherScenario.ProcessAsync(client);
    }

    [Fact]
    public async Task ExecuteScenario_GetWeatherSummaryByIdV22_ShouldValidate()
    {
        // arrange
        var client = _fixture.CreateClient();

        // act + assert
        var getWeatherScenario = _testRegistry.GetScenario<V2023_11_22.GetWeatherSummaryByIdScenario>();
        var version = V20231122.ApiVersion;
        getWeatherScenario.Path = string.Format(getWeatherScenario.Path, version);
        await getWeatherScenario.ProcessAsync(client);
    }

    [Theory]
    [InlineData(V20231122.ApiVersion)]
    [InlineData(V20231208.ApiVersion)]
    public async Task ExecuteScenario_GetWeatherSummaryById_ShouldValidate(string version)
    {
        // arrange
        var client = _fixture.CreateClient();

        // act + assert
        var getWeatherScenario = _testRegistry.GetScenario<V2023_11_22.GetWeatherSummaryByIdScenario>();
        getWeatherScenario.Path = string.Format(getWeatherScenario.Path, version);
        await getWeatherScenario.ProcessAsync(client);
    }

    [Theory]
    [InlineData("Edmonton")]
    [InlineData("Calgary")]
    public async Task ExecuteScenario_GetGeocodingDataByCityScenario_ReturnsValidWeather(string cityName)
    {
        // arrange
        var client = _fixture.CreateClient();

        // act
        var scenario = _testRegistry.GetScenario<GetGeocodingDataByCityScenario>();
        var result = await scenario.ProcessAsync(client, path => string.Format(path, cityName));

        // assert
        result.First().Name.Should().Be(cityName);
    }

    [Fact]
    public async Task ExecuteScenario_PostOpenWeatherRequest_Validates()
    {
        // arrange
        var client = _fixture.CreateClient();
        
        // act
        var geoScenario = _testRegistry.GetScenario<GetGeocodingDataByCityScenario>();
        var weatherScenario = _testRegistry.GetScenario<PostOpenWeatherScenario>();

        var geoResult = await geoScenario.ProcessAsync(client, path => string.Format(path, "Edmonton"));

        var request = new GetWeatherByCoordinates(geoResult.First().Lat, geoResult.First().Lon);
        var result = await weatherScenario.ProcessAsync(request, client);

        // assert
        result.Name.Should().Be("Edmonton");
    }
}