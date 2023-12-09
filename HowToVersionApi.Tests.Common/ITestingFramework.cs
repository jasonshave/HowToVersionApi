namespace HowToVersionApi.Tests.Common;

public interface ITestingFramework
{
    void RegisterScenario(ITestScenario scenario);

    ITestScenario GetScenario<TScenario>()
        where TScenario : ITestScenario;

    ITestScenario GetScenario(Type scenarioType);

    ITestScenario<TResult> GetScenarioWithResult<TScenario, TResult>()
        where TScenario : ScenarioBase<TResult>;
}