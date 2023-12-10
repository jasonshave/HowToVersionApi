﻿using HowToVersionApi.Abstractions;

namespace HowToVersionApi.Contracts.V2023_12_8;

public struct V20231208 : IApiVersion
{
    public const string ApiVersion = "2023-12-08";

    public const string GeocodingApiPath = "geocoding";

    public const string OpenWeatherApiPath = "openWeather";

    public static string Version => ApiVersion;

    public static string ReleaseNotes => "-Integration with Open Weather API to get lat/lon by city name.";
}