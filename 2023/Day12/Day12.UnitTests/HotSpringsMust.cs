using Day12.Logic;
using static Day12.UnitTests.Constants;

namespace Day12.UnitTests;

public class HotSpringsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 6)]
    [InlineData(PUZZLE_INPUT, 1000)]
    public void LoadInputCorrectly(string input, int expectedRows)
    {
        var sut  = new HotSprings(input);
        Assert.Equal(expectedRows, sut.RowCount);
    }
}