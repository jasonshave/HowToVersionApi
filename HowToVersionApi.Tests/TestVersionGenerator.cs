using System.Collections;

namespace HowToVersionApi.Tests;

public class TestVersionGenerator : IEnumerable<object[]>
{
    private readonly List<object[]> _versions = new()
    {
        new object[] { "2023-11-20" },
        new object[] { "2023-11-21" },
        new object[] { "2023-11-22" }
    };

    public IEnumerator<object[]> GetEnumerator() => _versions.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}