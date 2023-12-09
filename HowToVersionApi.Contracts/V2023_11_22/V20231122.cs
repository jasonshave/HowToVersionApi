using HowToVersionApi.Abstractions;

namespace HowToVersionApi.Contracts.V2023_11_22;

public struct V20231122 : IApiVersion
{
    public const string ApiVersion = "2023-11-22";

    public static string ApiPath => "weatherForecast";

    public static string RequestPath => $"{ApiPath}?api-version={ApiVersion}";

    public static string Version => ApiVersion;

    public static string ReleaseNotes => "-Set city to be 'Edmonton' for all responses.";
}