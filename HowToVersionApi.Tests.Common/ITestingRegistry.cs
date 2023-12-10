namespace HowToVersionApi.Tests.Common;

public interface ITestingRegistry
{
    void RegisterScenario<TScenario>()
        where TScenario : class, new();

    void RegisterScenario(Type scenarioType);

    TScenario GetScenario<TScenario>()
        where TScenario : class, new();
}