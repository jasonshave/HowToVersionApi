namespace HowToVersionApi.Tests.Common;

public class WebTestingFramework : ITestingFramework
{
    private readonly Dictionary<Type, ITestScenario> _testScenarios = new();

    public void RegisterScenario(ITestScenario testScenario)
    {
        _testScenarios.Add(testScenario.GetType(), testScenario);
    }

    public ITestScenario GetScenario(Type scenarioType)
    {
        _testScenarios.TryGetValue(scenarioType, out var testScenario);

        if (testScenario is null)
            throw new InvalidOperationException($"Test scenario {scenarioType.Name} is not registered.");

        return testScenario;
    }

    public ITestScenario GetScenario<TScenario>()
        where TScenario : ITestScenario
    {
        return GetScenario(typeof(TScenario));
    }

    //public ScenarioBase<TResult> GetScenarioWithResult<TRequest, TResult>(Type scenarioType)
    //{
    //    return (ScenarioBase<TResult>)GetScenario(scenarioType);
    //}

    //public ScenarioBase<TResult> GetScenarioWithResult<TScenario, TResult>()
    //    where TScenario : ScenarioBase<TResult>
    //{
    //    return (ScenarioBase<TResult>)GetScenario(typeof(TScenario));
    //}

    //public ScenarioBase<TResult> GetScenarioWithResult<TResult>()
    //{
    //    return (ScenarioBase<TResult>)GetScenario(typeof(ITestScenario<TResult>));
    //}

    //public ITestScenario<TRequest, TResult> GetScenarioWithResult<TScenario, TRequest, TResult>()
    //    where TScenario : ITestScenario<TRequest, TResult>
    //{
    //    return (ITestScenario<TRequest, TResult>)GetScenario(typeof(TScenario));
    //}
}