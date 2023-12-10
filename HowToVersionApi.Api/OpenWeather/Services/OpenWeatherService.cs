using HowToVersionApi.Api.OpenWeather.Models;

namespace HowToVersionApi.Api.OpenWeather.Services;

public class OpenWeatherService : IOpenWeatherService
{
    private readonly ILogger<OpenWeatherService> _logger;
    private readonly OpenWeatherApiConfiguration _openWeatherApiConfiguration;
    private readonly HttpClient _weatherClient;
    private readonly HttpClient _geocodingClient;

    public OpenWeatherService(IOptions<OpenWeatherApiConfiguration> openWeatherApiConfiguration, IHttpClientFactory httpClientFactory, ILogger<OpenWeatherService> logger)
    {
        _logger = logger;
        _openWeatherApiConfiguration = openWeatherApiConfiguration.Value;
        _weatherClient = httpClientFactory.CreateClient();
        _weatherClient.BaseAddress = new Uri(_openWeatherApiConfiguration.WeatherUrl);

        _geocodingClient = httpClientFactory.CreateClient();
        _geocodingClient.BaseAddress = new Uri(_openWeatherApiConfiguration.GeocodingUrl);
    }

    public async ValueTask<WeatherData?> GetWeatherAsync(GeocodingData data)
    {
        var response = await _weatherClient.GetAsync($"?lat={data.Lat}&lon={data.Lon}&units=metric&appid={_openWeatherApiConfiguration.ApiKey}");
        var stringData = await response.Content.ReadAsStringAsync();
        _logger.LogInformation(stringData);
        
        var weatherData = await response.Content.ReadFromJsonAsync<WeatherData>();
        return weatherData;
    }

    public async ValueTask<GeocodingData[]?> GetGeocodingAsync(string city)
    {
        var response = await _geocodingClient.GetAsync($"?q={city}&appid={_openWeatherApiConfiguration.ApiKey}");
        var geocodingData = await response.Content.ReadFromJsonAsync<GeocodingData[]>();
        return geocodingData;
    }
}