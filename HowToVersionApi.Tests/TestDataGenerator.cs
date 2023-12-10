namespace HowToVersionApi.Tests;

public class TestDataGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _data = new()
    {
        new object[] { new TestScenarioData(new V2023_11_20.GetWeatherTestScenario()) },
        new object[] { new TestScenarioData(new V2023_11_21.GetWeatherTestScenario()) },
        new object[] { new TestScenarioData(new V2023_11_22.GetWeatherTestScenario()) },
    };

    public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}