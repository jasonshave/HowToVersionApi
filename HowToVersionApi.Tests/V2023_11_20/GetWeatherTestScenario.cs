using HowToVersionApi.Contracts.V2023_11_20;

namespace HowToVersionApi.Tests.V2023_11_20;

public class GetWeatherTestScenario : TestScenario
{
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    public override string Path { get; set; } = V20231120.RequestPath;
}