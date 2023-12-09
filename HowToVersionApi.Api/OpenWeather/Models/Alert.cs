namespace HowToVersionApi.Api.OpenWeather.Models;

public class Alert
{
    public string SenderName { get; set; } = string.Empty;
    public string Event { get; set; } = string.Empty;
    public long Start { get; set; }
    public long End { get; set; }
    public string Description { get; set; } = string.Empty;
    public List<string>? Tags { get; set; }
}