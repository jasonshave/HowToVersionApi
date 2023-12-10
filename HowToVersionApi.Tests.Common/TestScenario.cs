using System.Net.Http.Json;

namespace HowToVersionApi.Tests.Common;

public abstract class TestScenario : TestScenarioBase
{
    public virtual async ValueTask ProcessAsync(HttpClient httpClient, Func<string, string>? pathDelegate = null)
    {
        // modify path if need be
        Path = pathDelegate?.Invoke(Path) ?? Path;

        var request = new HttpRequestMessage(HttpMethod, Path);
        var response = await httpClient.SendAsync(request);

        HttpResponseValidation?.Invoke(response);
    }
}

public abstract class TestScenario<TResult> : TestScenarioBase
{
    public virtual HttpContent? HttpContent { get; set; }

    public abstract Action<TResult?>? DataValidation { get; }

    public virtual async ValueTask<TResult?> ProcessAsync(HttpClient httpClient, Func<string, string>? pathDelegate = null)
    {
        // modify path if need be
        Path = pathDelegate?.Invoke(Path) ?? Path;

        var request = new HttpRequestMessage(HttpMethod, Path)
        {
            Content = HttpContent
        };
        var response = await httpClient.SendAsync(request);

        HttpResponseValidation?.Invoke(response);

        var result = await response.Content.ReadFromJsonAsync<TResult>();

        DataValidation?.Invoke(result);

        return result;
    }

    public virtual async ValueTask<TResult?> ProcessAsync<TRequest>(TRequest payload, HttpClient httpClient, Func<string, string>? pathDelegate = null)
    {
        HttpContent = JsonContent.Create(payload);
        var result = await ProcessAsync(httpClient, pathDelegate);

        return result;
    }
}