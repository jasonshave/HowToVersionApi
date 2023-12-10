using HowToVersionApi.Contracts.V2023_11_22;
using MediatR;

namespace HowToVersionApi.Api.Requests.V2023_11_22;

public class GetWeatherForecast : IRequest<IEnumerable<WeatherForecast>>
{
}