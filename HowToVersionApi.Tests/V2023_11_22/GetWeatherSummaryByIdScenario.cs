namespace HowToVersionApi.Tests.V2023_11_22;

public class GetWeatherSummaryByIdScenario : TestScenario<Dictionary<string, string>>
{
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    public override string Path { get; set; } = "weatherSummaries/2?api-version={0}";

    public override Action<Dictionary<string, string>> DataValidation { get; } = data =>
    {
        data.Should().NotBeNullOrEmpty();
        data.Values.Should().Contain("Chilly");
    };
}