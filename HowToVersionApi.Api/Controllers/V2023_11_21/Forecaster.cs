﻿using HowToVersionApi.Abstractions;
using HowToVersionApi.Contracts.V2023_11_21;

namespace HowToVersionApi.Api.Controllers.V2023_11_21;

public class Forecaster : IForecaster<WeatherForecast>
{
    private static readonly string[] Summaries =
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    public IEnumerable<WeatherForecast> GetForecast()
    {
        var weathers = Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Time = TimeOnly.FromDateTime(DateTime.Now.AddHours(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
            .ToArray();

        return weathers;
    }
}