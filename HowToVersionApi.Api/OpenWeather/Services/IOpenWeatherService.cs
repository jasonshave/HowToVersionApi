using HowToVersionApi.Api.OpenWeather.Models;

namespace HowToVersionApi.Api.OpenWeather.Services;

public interface IOpenWeatherService
{
    ValueTask<WeatherData?> GetWeatherAsync(string lat, string lon);
    ValueTask<GeocodingData?> GetGeocodingAsync(string city);
}