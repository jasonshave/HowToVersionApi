namespace HowToVersionApi.Api.OpenWeather.Models;

public class CurrentWeather
{
    public long Dt { get; set; }
    public long Sunrise { get; set; }
    public long Sunset { get; set; }
    public double Temp { get; set; }
    public double FeelsLike { get; set; }
    public int Pressure { get; set; }
    public int Humidity { get; set; }
    public double DewPoint { get; set; }
    public double Uvi { get; set; }
    public int Clouds { get; set; }
    public int Visibility { get; set; }
    public double WindSpeed { get; set; }
    public int WindDeg { get; set; }
    public double WindGust { get; set; }
    public List<WeatherCondition>? Weather { get; set; }
}