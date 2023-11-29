using Microsoft.AspNetCore.Mvc.Testing;

namespace HowToVersionApi.Tests;

public class WebServerFixture<TStartup> : WebApplicationFactory<TStartup>
    where TStartup : class
{
}