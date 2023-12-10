using System.Text.Json.Serialization;

namespace HowToVersionApi.Api.OpenWeather.Models;

public class GeocodingData
{
    public string Name { get; set; } = string.Empty;

    [JsonPropertyName("local_names")]
    public Dictionary<string, string>? LocalNames { get; set; } = new();

    [JsonPropertyName("lat")]
    public double Lat { get; set; }

    [JsonPropertyName("lon")]
    public double Lon { get; set; }

    public string? Country { get; set; } = string.Empty;

    public string? State { get; set; } = string.Empty;
}