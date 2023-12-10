namespace HowToVersionApi.Tests.Common;

public abstract class TestScenarioBase
{
    public abstract HttpMethod HttpMethod { get; }

    public abstract string Path { get; set; }

    public virtual Action<HttpResponseMessage>? HttpResponseValidation { get; } = response =>
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Unexpected status code {response.StatusCode}");
        }
    };
}