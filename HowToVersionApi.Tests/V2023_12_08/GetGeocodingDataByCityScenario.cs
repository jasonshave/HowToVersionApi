using HowToVersionApi.Api.OpenWeather.Models;
using HowToVersionApi.Contracts.V2023_12_8;

namespace HowToVersionApi.Tests.V2023_12_08;

public class GetGeocodingDataByCityScenario : TestScenario<GeocodingData[]>
{
    public override HttpMethod HttpMethod { get; } = HttpMethod.Get;

    public override string Path { get; set; } = V20231208.GeocodingApiPath + "?city={0}&api-version=" + V20231208.ApiVersion;

    public override Action<GeocodingData[]?>? DataValidation { get; } = data =>
    {
        data.Should().NotBeNullOrEmpty();
    };
}