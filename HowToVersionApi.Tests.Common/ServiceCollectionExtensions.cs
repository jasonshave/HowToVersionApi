using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace HowToVersionApi.Tests.Common;

public static class ServiceCollectionExtensions
{
    public static ITestingRegistry AddWebTestingFramework(this IServiceCollection services, Assembly assemblyToScan)
    {
        var baseType = typeof(TestScenarioBase);
        var matchingTypes = assemblyToScan.GetTypes().Where(type => baseType.IsAssignableFrom(type) && type.IsClass);
        
        ITestingRegistry testingRegistry = new WebTestingRegistry();

        // add all scenarios
        foreach (var type in matchingTypes)
        {
            testingRegistry.RegisterScenario(type);
        }

        // register for DI
        services.AddSingleton(testingRegistry);

        return testingRegistry;
    }
}