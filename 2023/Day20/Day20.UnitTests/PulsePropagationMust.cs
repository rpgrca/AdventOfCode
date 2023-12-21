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
    public void CountPulsesCorrectly_WhenTargetIsUnnamed()
    {
        var sut = new PulsePropagation("broadcaster -> output");
        sut.Pulse();
        Assert.Equal(2, sut.LowPulseCount);
        Assert.Equal(0, sut.HighPulseCount);
    }

    [Fact]
    public void CountPulsesCorrectly_WhenFlipFlopOffReceivesLowPulse()
    {
        var sut = new PulsePropagation("broadcaster -> a\n%a -> output");
        sut.Pulse();
        Assert.Equal(2, sut.LowPulseCount);
        Assert.Equal(1, sut.HighPulseCount);
    }

    [Fact]
    public void CountPulsesCorrectly_WhenFlipFlopOffReceivesHighPulse()
    {
        var sut = new PulsePropagation("broadcaster -> a\n%a -> b, output\n%b -> output");
        sut.Pulse();
        Assert.Equal(2, sut.LowPulseCount);
        Assert.Equal(2, sut.HighPulseCount);
    }

    [Fact]
    public void CountPulsesCorrectly_WhenFlipFlopOnReceivesHighPulse()
    {
        var sut = new PulsePropagation("broadcaster -> a, b\n%a -> b\n%b -> output");
        sut.Pulse();
        Assert.Equal(3, sut.LowPulseCount);
        Assert.Equal(2, sut.HighPulseCount);
    }

    [Fact]
    public void CountPulsesCorrectly_WhenConjunctionReceivesHighPulse()
    {
        var sut = new PulsePropagation("broadcaster -> a\n%a -> b\n&b -> output");
        sut.Pulse();
        Assert.Equal(3, sut.LowPulseCount);
        Assert.Equal(1, sut.HighPulseCount);
    }

    [Fact]
    public void CountPulsesCorrectly_WhenConjunctionReceivesLowPulse()
    {
        var sut = new PulsePropagation("broadcaster -> a\n%a -> b\n&b -> c\n&c -> output");
        sut.Pulse();
        Assert.Equal(3, sut.LowPulseCount);
        Assert.Equal(2, sut.HighPulseCount);
    }

    [Fact]
    public void HandleOnePulseCorrectly_WhenUsingSampleInput()
    {
        var sut = new PulsePropagation(SAMPLE_INPUT);
        sut.Pulse();
        Assert.Equal(8, sut.LowPulseCount);
        Assert.Equal(4, sut.HighPulseCount);
    }

    [Fact]
    public void HandleTwoPulsesCorrectly_WhenUsingSampleInput()
    {
        var sut = new PulsePropagation(SAMPLE_INPUT);
        sut.Pulse(2);
        Assert.Equal(16, sut.LowPulseCount);
        Assert.Equal(8, sut.HighPulseCount);
    }

    [Fact]
    public void HandleOnePulseCorrectly_WhenUsingSecondSampleInput()
    {
        var sut = new PulsePropagation(SECOND_SAMPLE_INPUT);
        sut.Pulse();
        Assert.Equal(4, sut.LowPulseCount);
        Assert.Equal(4, sut.HighPulseCount);
    }

    [Fact]
    public void HandleTwoPulsesCorrectly_WhenUsingSecondSampleInput()
    {
        var sut = new PulsePropagation(SECOND_SAMPLE_INPUT);
        sut.Pulse(2);
        Assert.Equal(8, sut.LowPulseCount);
        Assert.Equal(6, sut.HighPulseCount);
    }

    [Fact]
    public void HandleThreePulsesCorrectly_WhenUsingSecondSampleInput()
    {
        var sut = new PulsePropagation(SECOND_SAMPLE_INPUT);
        sut.Pulse(3);
        Assert.Equal(13, sut.LowPulseCount);
        Assert.Equal(9, sut.HighPulseCount);
    }

    [Fact]
    public void HandleFourPulsesCorrectly_WhenUsingSecondSampleInput()
    {
        var sut = new PulsePropagation(SECOND_SAMPLE_INPUT);
        sut.Pulse(4);
        Assert.Equal(17, sut.LowPulseCount);
        Assert.Equal(11, sut.HighPulseCount);
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 32000000)]
    [InlineData(SECOND_SAMPLE_INPUT, 11687500)]
    public void SolveFirstSampleCorrectly(string input, int expectedCount)
    {
        var sut = new PulsePropagation(input);
        sut.Pulse(1000);
        Assert.Equal(expectedCount, sut.PulseMultiplication);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new PulsePropagation(PUZZLE_INPUT);
        sut.Pulse(1000);
        Assert.Equal(731517480, sut.PulseMultiplication);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = new PulsePropagation(PUZZLE_INPUT);
        var amount = sut.ButtonPressesUntilRxReceivesLowPulse();
        Assert.Equal(244178746156661, amount);
    }
}