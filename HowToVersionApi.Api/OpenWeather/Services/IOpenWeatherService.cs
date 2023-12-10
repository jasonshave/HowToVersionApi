using HowToVersionApi.Api.OpenWeather.Models;

namespace HowToVersionApi.Api.OpenWeather.Services;

public interface IOpenWeatherService
{
    ValueTask<WeatherData?> GetWeatherAsync(GeocodingData data);
    ValueTask<GeocodingData[]?> GetGeocodingAsync(string city);
}