using HowToVersionApi.Api.Requests.V2023_11_22;
using HowToVersionApi.Contracts.V2023_11_22;
using MediatR;

namespace HowToVersionApi.Api.Handlers.V2023_11_22;

public class WeatherForecastHandler : IRequestHandler<GetWeatherForecast, IEnumerable<WeatherForecast>>
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecast request, CancellationToken cancellationToken)
    {
        return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Time = TimeOnly.FromDateTime(DateTime.Now.AddHours(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        }));
    }
}