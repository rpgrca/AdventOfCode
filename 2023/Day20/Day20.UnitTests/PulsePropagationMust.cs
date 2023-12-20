using Day20.Logic;
using static Day20.UnitTests.Constants;

namespace Day20.UnitTests;

public class PulsePropagationMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 5)]
    [InlineData(SECOND_SAMPLE_INPUT, 5)]
    [InlineData(PUZZLE_INPUT, 58)]
    public void LoadInputCorrectly(string input, int expectedCommands)
    {
        var sut = new PulsePropagation(input);
        Assert.Equal(expectedCommands, sut.CommandsCount);
    }
}