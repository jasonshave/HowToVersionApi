using HowToVersionApi.Abstractions;
using HowToVersionApi.Contracts.V2023_11_20;
using HowToVersionApi.Domain;

namespace HowToVersionApi.Api.Controllers.V2023_11_20;

public class WeatherService : AbstractWeatherProcessor<V20231120, WeatherForecast>
{
    public WeatherService(IForecaster<WeatherForecast> forecaster, ILogger<WeatherService> logger)
        : base(forecaster, logger)
    {
    }
}