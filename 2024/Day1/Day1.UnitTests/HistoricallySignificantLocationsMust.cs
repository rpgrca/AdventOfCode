using Day1.Logic;
using static Day1.UnitTests.Constants;

namespace Day1.UnitTests;

public class HistoricallySignificantLocationsMust
{
    [Fact]
    public void LoadDataCorrectly()
    {
        var sut = new HistoricallySignificantLocations(SAMPLE_INPUT);
        Assert.Equal(6, sut.Length);
    }
}