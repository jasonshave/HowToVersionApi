using HowToVersionApi.Abstractions;

namespace HowToVersionApi.Contracts.V20231120;

public struct V20231120 : IVersion
{
    public const string ApiVersion = "2023-11-20";
    public static string Version => ApiVersion;

    public static string ReleaseNotes => """
                                         - Initial release
                                         """;
}