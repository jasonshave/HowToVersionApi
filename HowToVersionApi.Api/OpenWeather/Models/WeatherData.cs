using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Components.Endpoints;

namespace HowToVersionApi.Api.OpenWeather.Models;

public class WeatherData
{
    [JsonPropertyName("coord")]
    public Coordinates Coordinates { get; set; }
    
    public List<Weather>? Weather { get; set; }

    public string Base { get; set; }

    public WeatherMain Main { get; set; } = new();

    public int Visibility { get; set; }

    public Dictionary<string, double>? Wind { get; set; }

    public Dictionary<string, double>? Rain { get; set; }

    public Dictionary<string, double>? Clouds { get; set; }

    [JsonPropertyName("dt")]
    public int TimeOfDay { get; set; }

    public WeatherSystemData WeatherSystemData { get; set; }

    public int Timezone { get; set; }

    public int Id { get; set; }

    public string Name { get; set; }

    public int Cod { get; set; }
}