using HowToVersionApi.Abstractions;

namespace HowToVersionApi.Contracts.V2023_11_21;

public struct V20231121 : IApiVersion
{
    public const string ApiVersion = "2023-11-21";

    public static string ApiPath => "weatherForecast";

    public static string RequestPath => $"{ApiPath}?api-version={ApiVersion}";

    public static string Version => ApiVersion;

    public static string ReleaseNotes => "-Added date to weather forecast";
}