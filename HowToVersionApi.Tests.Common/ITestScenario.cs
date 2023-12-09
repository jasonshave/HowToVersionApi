using Microsoft.Extensions.Logging;

namespace HowToVersionApi.Tests.Common;

public interface ITestScenario
{
    string Version { get; }

    HttpMethod HttpMethod { get; }

    string Path { get; set; }

    HttpContent? RequestContent { get; }

    Func<HttpResponseMessage, ValueTask>? HttpResponseValidation { get; }

    ValueTask ProcessScenarioAsync(HttpClient httpClient, ILogger? logger = null);

    ValueTask<TResponse> ProcessScenarioAsync<TResponse>(HttpClient httpClient, ILogger? logger = null);

    ValueTask<TResponse> ProcessScenarioAsync<TRequest, TResponse>(TRequest request, HttpClient httpClient, ILogger? logger = null);
}

public interface ITestScenario<TResponse>
{
    string Version { get; }

    HttpMethod HttpMethod { get; }

    string Path { get; set; }

    HttpContent? Content { get; }

    Action<HttpResponseMessage>? HttpResponseValidation { get; }

    ValueTask<TResponse?> ProcessScenarioAsync(HttpClient httpClient, ILogger? logger = null);

    ValueTask<TResponse> ProcessScenarioAsync<TRequest>(TRequest request, HttpClient httpClient, ILogger? logger = null);

}