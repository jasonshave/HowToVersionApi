using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace HowToVersionApi.Tests;

public class WebServerFixture<TStartup> : WebApplicationFactory<TStartup>
    where TStartup : class
{
    public ITestingFramework TestingFramework { get; private set; } = null!;

    public ITestOutputHelper TestOutputHelper { get; set; } = null!;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        TestingFramework = new WebTestingFramework();
        
        TestingFramework.RegisterScenario(new V2023_11_20.GetWeatherScenario());
        TestingFramework.RegisterScenario(new V2023_11_21.GetWeatherScenario());
        TestingFramework.RegisterScenario(new V2023_11_22.GetWeatherScenario());
        TestingFramework.RegisterScenario(new V2023_11_22.GetWeatherSummaryById());

        builder
            .ConfigureLogging(loggingBuilder =>
            {
                loggingBuilder.Services.AddSingleton<ILoggerProvider>(_ => new XUnitLoggerProvider(TestOutputHelper));
            });
    }
}