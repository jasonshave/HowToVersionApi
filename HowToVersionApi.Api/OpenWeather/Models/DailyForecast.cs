namespace HowToVersionApi.Api.OpenWeather.Models;

public class DailyForecast
{
    public long Dt { get; set; }
    public long Sunrise { get; set; }
    public long Sunset { get; set; }
    public long Moonrise { get; set; }
    public long Moonset { get; set; }
    public double MoonPhase { get; set; }
    public string Summary { get; set; } = string.Empty;
    public TemperatureInfo? Temp { get; set; }
    public FeelsLikeInfo? FeelsLike { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
    public double DewPoint { get; set; }
    public double WindSpeed { get; set; }
    public int WindDeg { get; set; }
    public double WindGust { get; set; }
    public List<WeatherCondition>? Weather { get; set; }
    public int Clouds { get; set; }
    public double Pop { get; set; }
    public double Rain { get; set; }
    public double Uvi { get; set; }
}