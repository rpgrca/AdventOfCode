using Day20.Logic;
using static Day20.UnitTests.Constants;

namespace Day20.UnitTests;

public class RaceConditionMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 15, 1, 3, 5, 7)]
    [InlineData(PUZZLE_INPUT, 141, 43, 73, 69, 71)]
    public void LoadInputCorrectly(string input, int expectedSize, int startX, int startY, int endX, int endY)
    {
        var sut = new RaceCondition(input);
        Assert.Equal(expectedSize, sut.Size);
        Assert.Equal((startX, startY), sut.Start);
        Assert.Equal((endX, endY), sut.End);
    }
}