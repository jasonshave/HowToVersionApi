using HowToVersionApi.Api.OpenWeather.Models;
using MediatR;

namespace HowToVersionApi.Api.Requests.V2023_12_8;

public class GetWeatherRequest : IRequest<WeatherData>
{
    public string City { get; set; } = string.Empty;
}