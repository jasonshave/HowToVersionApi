using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Logging;

namespace HowToVersionApi.Tests.Common;

public abstract class ScenarioBase : ITestScenario
{
    public abstract string Version { get; }

    public abstract HttpMethod HttpMethod { get; }

    public abstract string Path { get; set; }

    public virtual HttpContent? RequestContent { get; set; } = null;

    public virtual Func<HttpResponseMessage, ValueTask>? HttpResponseValidation { get; } = response =>
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Unexpected status code {response.StatusCode}");
        }

        return ValueTask.CompletedTask;
    };


    public virtual async ValueTask ProcessScenarioAsync(HttpClient httpClient, ILogger? logger = null)
    {
        logger?.LogInformation("Handling scenario {scenario} for version {version}", GetType().Name, Version);

        var request = new HttpRequestMessage(HttpMethod, Path)
        {
            Content = RequestContent
        };
        var response = await httpClient.SendAsync(request);

        await (ValueTask)HttpResponseValidation?.Invoke(response);
    }

    public virtual async ValueTask<TResponse> ProcessScenarioAsync<TResponse>(HttpClient httpClient, ILogger? logger = null)
    {
        throw new NotImplementedException();
    }

    public virtual async ValueTask<TResponse> ProcessScenarioAsync<TRequest, TResponse>(TRequest request, HttpClient httpClient, ILogger? logger = null)
    {
        throw new NotImplementedException();
    }
}

public abstract class ScenarioBase<TResponse> : ITestScenario<TResponse>
{
    public abstract string Version { get; }

    public abstract HttpMethod HttpMethod { get; }

    public abstract string Path { get; set; }

    public virtual HttpContent? Content { get; } = null;

    public virtual TResponse? Result { get; private set; }

    public abstract Action<TResponse?> DataValidation { get; }

    public virtual Action<HttpResponseMessage>? HttpResponseValidation { get; } = response =>
    {
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception($"Unexpected status code {response.StatusCode}");
        }
    };

    public virtual async ValueTask<TResponse?> ProcessScenarioAsync(HttpClient httpClient, ILogger? logger = null)
    {
        logger?.LogInformation("Handling scenario {scenario} for version {version}", GetType().Name, Version);

        var request = new HttpRequestMessage(HttpMethod, Path);
        var response = await httpClient.SendAsync(request);

        HttpResponseValidation?.Invoke(response);

        var result = await response.Content.ReadFromJsonAsync<TResponse>();

        DataValidation?.Invoke(result);
        Result = result;
        return result;
    }

    public ValueTask<TResponse> ProcessScenarioAsync<TRequest>(TRequest request, HttpClient httpClient, ILogger? logger = null)
    {
        throw new NotImplementedException();
    }
}