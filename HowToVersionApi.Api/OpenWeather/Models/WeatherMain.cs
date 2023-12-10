using System.Text.Json.Serialization;

namespace HowToVersionApi.Api.OpenWeather.Models;

public class WeatherMain
{
    [JsonPropertyName("temp")]
    public double Temperature { get; set; }

    [JsonPropertyName("feels_like")]
    public double FeelsLike { get; set; }

    [JsonPropertyName("temp_min")]
    public double MinTemperature { get; set; }

    [JsonPropertyName("temp_max")]
    public double MaxTemperature { get; set; }

    public double Pressure { get; set; }

    public double Humidity { get; set; }
}