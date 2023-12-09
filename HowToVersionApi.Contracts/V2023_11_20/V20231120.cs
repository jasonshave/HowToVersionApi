using HowToVersionApi.Abstractions;

namespace HowToVersionApi.Contracts.V2023_11_20;

public struct V20231120 : IApiVersion
{
    public const string ApiVersion = "2023-11-20";

    public static string ApiPath => "weatherForecast";

    public static string RequestPath => $"{ApiPath}?api-version={ApiVersion}";

    public static string Version => ApiVersion;

    public static string ReleaseNotes => "-Initial release";
}