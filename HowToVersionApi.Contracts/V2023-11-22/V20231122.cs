using HowToVersionApi.Abstractions;

namespace HowToVersionApi.Contracts.V2023_11_22;

public struct V20231122 : IVersion
{
    public const string ApiVersion = "2023-11-22";
    public static string Version => ApiVersion;

    public static string ReleaseNotes => """
                                         - Added wind speed model
                                         """;
}