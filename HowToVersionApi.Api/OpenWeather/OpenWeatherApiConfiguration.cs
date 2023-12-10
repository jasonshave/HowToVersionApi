namespace HowToVersionApi.Api.OpenWeather;

public class OpenWeatherApiConfiguration
{
    public string ApiKey { get; set; } = string.Empty;

    public string WeatherUrl { get; set; } = string.Empty;

    public string GeocodingUrl { get; set; } = string.Empty;
}