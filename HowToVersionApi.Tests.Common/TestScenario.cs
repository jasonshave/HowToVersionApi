using Microsoft.Extensions.Logging;
using System.Net.Http.Json;

namespace HowToVersionApi.Tests.Common;

public abstract class TestScenario : BaseScenario
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

public abstract class TestScenario<TResponse> : BaseScenario
{
    public abstract Action<TResponse?>? DataValidation { get; }

    private HttpContent? _httpContent;

    public virtual async ValueTask<TResponse?> ProcessWithResultAsync(HttpClient httpClient, ILogger? logger = null)
    {
        logger?.LogInformation("Handling scenario {scenario}.", GetType().Name);

        var request = new HttpRequestMessage(HttpMethod, Path);
        var response = await httpClient.SendAsync(request);

        HttpResponseValidation?.Invoke(response);

        var result = await response.Content.ReadFromJsonAsync<TResponse>();

        DataValidation?.Invoke(result);

        return result;
    }

    public virtual async ValueTask<TResponse?> ProcessWithRequestAndPayloadAsync<TRequest>(TRequest data, HttpClient httpClient, ILogger? logger = null)
    {
        logger?.LogInformation("Handling scenario {scenario}.", GetType().Name);
        
        _httpContent = JsonContent.Create(data);
        var result = await ProcessWithResultAsync(httpClient, logger);

        return result;
    }
}