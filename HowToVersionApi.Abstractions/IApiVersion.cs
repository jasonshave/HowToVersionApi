namespace HowToVersionApi.Abstractions;

public interface IApiVersion
{
    static abstract string Version { get; }

    static abstract string ReleaseNotes { get; }
}