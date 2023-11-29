namespace HowToVersionApi.Abstractions;

public interface IVersion
{
    public static abstract string Version { get; }

    public static abstract string ReleaseNotes { get; }
}