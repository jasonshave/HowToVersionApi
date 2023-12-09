﻿namespace HowToVersionApi.Api.OpenWeather.Models;

public class TemperatureInfo
{
    public double Day { get; set; }
    public double Min { get; set; }
    public double Max { get; set; }
    public double Night { get; set; }
    public double Eve { get; set; }
    public double Morn { get; set; }
}