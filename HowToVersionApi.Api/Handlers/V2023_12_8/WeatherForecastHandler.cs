using HowToVersionApi.Api.OpenWeather.Models;
using HowToVersionApi.Api.OpenWeather.Services;
using HowToVersionApi.Api.Requests.V2023_12_8;
using MediatR;

namespace HowToVersionApi.Api.Handlers.V2023_12_8;

public class WeatherForecastHandler : IRequestHandler<GetWeatherRequest, WeatherData>
{
    private readonly IOpenWeatherService _openWeatherService;

    public WeatherForecastHandler(IOpenWeatherService openWeatherService)
    {
        _openWeatherService = openWeatherService;
    }

    public async Task<WeatherData> Handle(GetWeatherRequest request, CancellationToken cancellationToken)
    {
        var geocodingData = await _openWeatherService.GetGeocodingAsync(request.City);

        var weatherData = await _openWeatherService.GetWeatherAsync(geocodingData.First());

        return weatherData;
    }
}