namespace HowToVersionApi.Contracts.V2023_11_22
{
    public class WeatherForecast
    {
        public DateOnly Date { get; set; }

        public TimeOnly Time { get; set; }

        public string City = "Edmonton";

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}
