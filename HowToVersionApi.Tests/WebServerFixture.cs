using HowToVersionApi.Tests.Common;
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
        
        TestingFramework.RegisterScenario<V2023_11_20.GetWeatherTestScenario>();
        TestingFramework.RegisterScenario<V2023_11_21.GetWeatherTestScenario>();
        TestingFramework.RegisterScenario<V2023_11_22.GetWeatherTestScenario>();
        TestingFramework.RegisterScenario<V2023_11_22.GetWeatherSummaryById>();
        TestingFramework.RegisterScenario<V2023_12_08.GetGeocodingDataByCity>();

        builder
            .ConfigureLogging(loggingBuilder =>
            {
                loggingBuilder.Services.AddSingleton<ILoggerProvider>(_ => new XUnitLoggerProvider(TestOutputHelper));
            });
    }
}