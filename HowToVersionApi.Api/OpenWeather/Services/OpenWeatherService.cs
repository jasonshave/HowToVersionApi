using HowToVersionApi.Api.OpenWeather.Models;

namespace HowToVersionApi.Api.OpenWeather.Services;

public class OpenWeatherService : IOpenWeatherService
{
    private readonly OpenWeatherApiConfiguration _openWeatherApiConfiguration;
    private readonly HttpClient _weatherClient;
    private readonly HttpClient _geocodingClient;

    public OpenWeatherService(IOptions<OpenWeatherApiConfiguration> openWeatherApiConfiguration, IHttpClientFactory httpClientFactory)
    {
        _openWeatherApiConfiguration = openWeatherApiConfiguration.Value;
        _weatherClient = httpClientFactory.CreateClient();
        _weatherClient.BaseAddress = new Uri(_openWeatherApiConfiguration.WeatherUrl);

        _geocodingClient = httpClientFactory.CreateClient();
        _geocodingClient.BaseAddress = new Uri(_openWeatherApiConfiguration.GeocodingUrl);
    }

    public async ValueTask<WeatherData?> GetWeatherAsync(string lat, string lon)
    {
        var response = await _weatherClient.GetAsync($"?lat={lat}&lon={lon}&appid={_openWeatherApiConfiguration.ApiKey}");
        var weatherData = await response.Content.ReadFromJsonAsync<WeatherData>();
        return weatherData;
    }

    public async ValueTask<GeocodingData?> GetGeocodingAsync(string city)
    {
        var response = await _geocodingClient.GetAsync($"?q={city}&appid={_openWeatherApiConfiguration.ApiKey}");
        var geocodingData = await response.Content.ReadFromJsonAsync<GeocodingData>();
        return geocodingData;
    }
}