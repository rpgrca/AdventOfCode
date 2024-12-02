using Day2.Logic;
using static Day2.UnitTests.Constants;

namespace Day2.UnitTests;

public class ReportsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 6)]
    [InlineData(PUZZLE_INPUT, 1000)]
    public void LoadInputCorrectly(string input, int expectedLength)
    {
        var sut = new Reports(input);
        Assert.Equal(expectedLength, sut.Length);
    }

    [Theory]
    [InlineData("7 6 4 2 1", 1)]
    [InlineData("1 2 7 8 9", 0)]
    public void DetermineSafeReportCorrectly(string input, int expectedCount)
    {
        var sut = new Reports(input);
        Assert.Equal(expectedCount, sut.SafeReportsCount);
    }
}