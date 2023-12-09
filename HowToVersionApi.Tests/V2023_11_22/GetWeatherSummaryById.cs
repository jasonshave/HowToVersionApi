using HowToVersionApi.Contracts.V2023_11_22;

namespace HowToVersionApi.Tests.V2023_11_22;

public class GetWeatherSummaryById : ScenarioBase<KeyValuePair<string, string>>
{
    public override string Version { get; } = V20231122.Version;

    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    public override string Path { get; set; } = $"weatherSummaries/2?api-version={V20231122.Version}";

    public override Action<KeyValuePair<string, string>> DataValidation { get; } = data =>
    {
        data.Should().NotBeNull();
    };
}