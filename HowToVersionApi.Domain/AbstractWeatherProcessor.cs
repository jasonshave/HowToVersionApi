using HowToVersionApi.Abstractions;
using Microsoft.Extensions.Logging;

namespace HowToVersionApi.Domain;

public abstract class AbstractWeatherProcessor<TVersion, TWeather> : IWeatherService<TWeather>
    where TVersion : IApiVersion
    where TWeather : class, new()
{
    private readonly IForecaster<TWeather> _forecaster;
    private readonly ILogger<AbstractWeatherProcessor<TVersion, TWeather>> _logger;

    protected AbstractWeatherProcessor(
        IForecaster<TWeather> forecaster,
        ILogger<AbstractWeatherProcessor<TVersion, TWeather>> logger)
    {
        _forecaster = forecaster;
        _logger = logger;
    }

    public IEnumerable<TWeather> GetWeather()
    {
        _logger.LogInformation("Invoking method for version {ApiVersion}, {ReleaseNotes}", TVersion.Version, TVersion.ReleaseNotes);

        var weatherForecast = _forecaster.GetForecast();
        return weatherForecast;
    }
}