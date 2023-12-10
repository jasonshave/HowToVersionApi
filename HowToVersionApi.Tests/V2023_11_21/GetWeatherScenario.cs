using HowToVersionApi.Contracts.V2023_11_21;

namespace HowToVersionApi.Tests.V2023_11_21;

public class GetWeatherTestScenario : TestScenario<WeatherForecast[]>
{
    public override HttpMethod HttpMethod => HttpMethod.Get;

    public override string Path { get; set; } = V20231121.RequestPath;

    public override Action<WeatherForecast[]?> DataValidation => data =>
    {
        data.Should().NotBeNullOrEmpty();
        data.Count().Should().Be(5);
        data.First().Time.Should().NotBe(default);
    };
}