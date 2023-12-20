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

    [Theory]
    [InlineData(SAMPLE_INPUT, 3, 1, 0)]
    [InlineData(SECOND_SAMPLE_INPUT, 2, 2, 1)]
    [InlineData(PUZZLE_INPUT, 48, 9, 1)]
    public void ParseInputCorrectly(string input, int expectedFlipFlops, int expectedConjuntions, int expectedUnnameds)
    {
        var sut = new PulsePropagation(input);
        Assert.Equal(expectedFlipFlops, sut.FlipFlopCount);
        Assert.Equal(expectedConjuntions, sut.ConjuntionCount);
        Assert.Equal(expectedUnnameds, sut.UnnamedCount);
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 3)]
    [InlineData(SECOND_SAMPLE_INPUT, 1)]
    [InlineData(PUZZLE_INPUT, 4)]
    public void CalculateInitialBroadcastTargetsCorrectly(string input, int expectedBroadcasterTargets)
    {
        var sut = new PulsePropagation(input);
        Assert.Equal(expectedBroadcasterTargets, sut.BroadcasterTargets);
    }

    [Fact]
    public void BroadcastCorrectly_WhenBroadcastTargetIsUnnamed()
    {
        var sut = new PulsePropagation("broadcaster -> output");
        sut.Pulse();
        Assert.Equal(1, sut.LowPulseCount);
        Assert.Equal(0, sut.HighPulseCount);
    }
}