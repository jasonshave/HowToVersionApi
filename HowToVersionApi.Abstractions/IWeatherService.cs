namespace HowToVersionApi.Abstractions;

public interface IWeatherService<out TWeather>
    where TWeather : class
{
    IEnumerable<TWeather> GetWeather();
}