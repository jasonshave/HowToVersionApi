namespace HowToVersionApi.Abstractions;

public interface IApiVersion
{
    static abstract string Version { get; }

    static abstract string ReleaseNotes { get; }

    static abstract string ApiPath { get; }

    static abstract string RequestPath { get; }

}