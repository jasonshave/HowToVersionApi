namespace HowToVersionApi.Tests.Common;

public static class ServiceCollectionExtensions
{
    public static ITestingFramework AddWebTestingFramework(this IServiceProvider services)
    {
        var testingFramework = new WebTestingFramework();
        return testingFramework;
    }
}