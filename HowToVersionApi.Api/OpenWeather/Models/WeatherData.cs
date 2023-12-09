namespace HowToVersionApi.Api.OpenWeather.Models;

public class WeatherData
{
    public double Lat { get; set; }
    public double Lon { get; set; }
    public string Timezone { get; set; } = string.Empty;
    public int TimezoneOffset { get; set; }
    public CurrentWeather? Current { get; set; }
    public List<MinutelyForecast>? Minutely { get; set; }
    public List<HourlyForecast>? Hourly { get; set; }
    public List<DailyForecast>? Daily { get; set; }
    public List<Alert>? Alerts { get; set; }
}