namespace HowToVersionApi.Abstractions;

public interface IForecaster<out TData>
    where TData : class
{
    IEnumerable<TData> GetForecast();
}