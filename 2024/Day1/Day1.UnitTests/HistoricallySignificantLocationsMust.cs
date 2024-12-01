using Day1.Logic;
using static Day1.UnitTests.Constants;

namespace Day1.UnitTests;

public class HistoricallySignificantLocationsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 6)]
    [InlineData(PUZZLE_INPUT, 1000)]
    public void LoadDataCorrectly(string input, int expectedLength)
    {
        var sut = new HistoricallySignificantLocations(input);
        Assert.Equal(expectedLength, sut.Length);
    }
}