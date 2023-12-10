namespace HowToVersionApi.Tests.Common;

public class WebTestingRegistry : ITestingRegistry
{
    private readonly HashSet<Type> _testScenarios = new();

    public void RegisterScenario<TScenario>()
        where TScenario : class, new()
    {
        _testScenarios.Add(typeof(TScenario));
    }

    public void RegisterScenario(Type scenarioType)
    {
        _testScenarios.Add(scenarioType);
    }

    public TScenario GetScenario<TScenario>()
        where TScenario : class, new()
    {
        _testScenarios.TryGetValue(typeof(TScenario), out var scenarioType);
        if (scenarioType is null)
            throw new InvalidOperationException($"Test scenario {typeof(TScenario).Name} is not registered.");

        var testScenario = new TScenario();
        return testScenario;
    }
}