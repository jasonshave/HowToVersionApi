using HowToVersionApi.Contracts.V2023_11_22;

namespace HowToVersionApi.Tests.V2023_11_22;

public class GetWeatherTestScenario : TestScenario<IEnumerable<WeatherForecast>>
{
    public override HttpMethod HttpMethod => HttpMethod.Get;

    public override string Path { get; set; } = $"{V20231122.WeatherApiPath}?api-version={V20231122.ApiVersion}";

    public override Action<IEnumerable<WeatherForecast>?> DataValidation { get; } = data =>
    {
        data.Should().NotBeNullOrEmpty();
        data.Count().Should().Be(5);
        data.First().Time.Should().NotBe(default);
        data.Should().AllSatisfy(x => x.City.Should().Be("Edmonton"));
    };
}