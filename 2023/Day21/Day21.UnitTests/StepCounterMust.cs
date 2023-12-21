using Day21.Logic;
using static Day21.UnitTests.Constants;

namespace Day21.UnitTests;

public class StepCounterMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 11)]
    [InlineData(PUZZLE_INPUT, 131)]
    public void LoadInputCorrectly(string input, int expectedWidth)
    {
        var sut = new StepCounter(input);
        Assert.Equal(expectedWidth, sut.Width);
    }
}