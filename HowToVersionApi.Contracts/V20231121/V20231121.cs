using HowToVersionApi.Abstractions;

namespace HowToVersionApi.Contracts.V20231121;

public struct V20231121 : IVersion
{
    public const string ApiVersion = "2023-11-21";
    public static string Version => ApiVersion;

    public static string ReleaseNotes => """
                                         - Added date to weather forecast
                                         """;
}