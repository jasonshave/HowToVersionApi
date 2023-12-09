using HowToVersionApi.Abstractions;
using HowToVersionApi.Contracts.V2023_11_21;
using HowToVersionApi.Domain;

namespace HowToVersionApi.Api.Controllers.V2023_11_21;

public class WeatherService : AbstractWeatherProcessor<V20231121, WeatherForecast>
{
    public WeatherService(IForecaster<WeatherForecast> forecaster, ILogger<WeatherService> logger)
        : base(forecaster, logger)
    {
    }
}