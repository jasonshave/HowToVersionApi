using HowToVersionApi.Abstractions;
using HowToVersionApi.Contracts.V2023_11_20;
using HowToVersionApi.Contracts.V2023_11_21;

namespace HowToVersionApi.Api;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddVersion<TVersion>(this IServiceCollection services)
        where TVersion : IApiVersion
    {
        if (TVersion.Version == V20231120.Version)
        {
            services.AddScoped<IWeatherService<Contracts.V2023_11_20.WeatherForecast>, Controllers.V2023_11_20.WeatherService>();
            services.AddScoped<IForecaster<Contracts.V2023_11_20.WeatherForecast>, Controllers.V2023_11_20.Forecaster>();
        }

        if (TVersion.Version == V20231121.Version)
        {
            services.AddScoped<IWeatherService<Contracts.V2023_11_21.WeatherForecast>, Controllers.V2023_11_21.WeatherService>();
            services.AddScoped<IForecaster<Contracts.V2023_11_21.WeatherForecast>, Controllers.V2023_11_21.Forecaster>();
        }

        return services;
    }
}