using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace HowToVersionApi.Tests.Common;

public abstract class TestScenario : TestScenarioBase
{
    public virtual async ValueTask ProcessAsync(HttpClient httpClient, ILogger? logger = null)
    {
        logger?.LogInformation("Handling scenario {scenario}.", GetType().Name);

        var request = new HttpRequestMessage(HttpMethod, Path)
        {
            Content = RequestContent
        };
        var response = await httpClient.SendAsync(request);

        HttpResponseValidation?.Invoke(response);
    }
}

public abstract class TestScenario<TResult> : TestScenarioBase
{
    public abstract Action<TResult?>? DataValidation { get; }

    private HttpContent? _httpContent;

    public virtual async ValueTask<TResult?> ProcessAsync(HttpClient httpClient, ILogger? logger = null)
    {
        logger?.LogInformation("Handling scenario {scenario}.", GetType().Name);

        var request = new HttpRequestMessage(HttpMethod, Path);

        if (_httpContent is not null) request.Content = _httpContent;

        var response = await httpClient.SendAsync(request);

        HttpResponseValidation?.Invoke(response);

        var result = await response.Content.ReadFromJsonAsync<TResult>();

        DataValidation?.Invoke(result);

        return result;
    }

    public virtual async ValueTask<TResult?> ProcessAsync<TRequest>(TRequest data, HttpClient httpClient, ILogger? logger = null)
    {
        logger?.LogInformation("Handling scenario {scenario}.", GetType().Name);

        _httpContent = JsonContent.Create(data);
        var result = await ProcessAsync(httpClient, logger);

        return result;
    }
}