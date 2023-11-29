using FakeItEasy;
using FluentAssertions;
using Microsoft.Extensions.Logging;

namespace HowToVersionApi.Tests;

public class WeatherForecastControllerTests
{
    private readonly Controllers.V2023_11_20.WeatherForecastController _controller20 = new (A.Fake<ILogger<Controllers.V2023_11_20.WeatherForecastController>>());
    private readonly Controllers.V2023_11_21.WeatherForecastController _controller21 = new (A.Fake<ILogger<Controllers.V2023_11_21.WeatherForecastController>>());

    [Fact]
    public void GetSummaries()
    {
        // arrange/act
        var result = _controller20.GetSummaries();

        // assert
        result.Should().NotBeEmpty();
        result.Length.Should().Be(10);
    }

    [Fact]
    public void GetWeather_Version_20231120()
    {
        // arrange/act
        var result = _controller20.GetWeather();
        
        // assert
        result.Should().NotBeEmpty();
        result.First().TemperatureC.Should().NotBe(default);
    }

    [Fact]
    public void GetWeather_Version_20231121()
    {
        // arrange/act
        var result = _controller21.GetWeather();

        // assert
        result.Should().NotBeEmpty();
        result.First().Time.Should().NotBe(default);
    }
}