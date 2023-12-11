using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit.Abstractions;

namespace HowToVersionApi.Tests;

public class WebServerFixture<TStartup> : WebApplicationFactory<TStartup>
    where TStartup : class
{
    public ITestOutputHelper TestOutputHelper { get; set; } = null!;

    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder
            .ConfigureTestServices(services => 
            {
                services.AddWebTestingFramework(Assembly.GetExecutingAssembly());
            })
            .ConfigureLogging(loggingBuilder =>
            {
                loggingBuilder.Services.AddSingleton<ILoggerProvider>(_ => new XUnitLoggerProvider(TestOutputHelper));
            });
    }
}