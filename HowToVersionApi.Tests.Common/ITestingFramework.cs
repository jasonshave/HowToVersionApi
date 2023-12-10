namespace HowToVersionApi.Tests.Common;

public interface ITestingFramework
{
    void RegisterScenario<TScenario>()
        where TScenario : class, new();

    TScenario GetScenario<TScenario>()
        where TScenario : class, new();
}