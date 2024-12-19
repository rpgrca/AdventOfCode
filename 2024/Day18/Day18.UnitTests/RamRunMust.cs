using Day18.Logic;
using static Day18.UnitTests.Constants;

namespace Day18.UnitTests;

public class RamRunMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 25)]
    [InlineData(PUZZLE_INPUT, 3450)]
    public void LoadInputCorrectly(string input, int expectedCount)
    {
        var sut = new RamRun(input);
        Assert.Equal(expectedCount, sut.Count);
    }
}