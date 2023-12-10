namespace HowToVersionApi.Abstractions;

public interface IWindService<out TWind>
    where TWind : class
{
    TWind GetWind();
}