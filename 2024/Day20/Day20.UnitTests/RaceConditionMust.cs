using Day20.Logic;
using static Day20.UnitTests.Constants;

namespace Day20.UnitTests;

public class RaceConditionMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 15)]
    [InlineData(PUZZLE_INPUT, 141)]
    public void LoadInputCorrectly(string input, int expectedSize)
    {
        var sut = new RaceCondition(input);
        Assert.Equal(expectedSize, sut.Size);
    }
}