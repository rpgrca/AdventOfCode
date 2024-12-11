using Day11.Logic;
using static Day11.UnitTests.Constants;

namespace Day11.UnitTests;

public class PlutonianPebblesMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 2)]
    [InlineData(SECOND_SAMPLE_INPUT, 5)]
    [InlineData(PUZZLE_INPUT, 8)]
    public void LoadInputCorrectly(string input, int expectedCount)
    {
        var sut = new PlutonianPebbles(input);
        Assert.Equal(expectedCount, sut.Count);
    }

    [Fact]
    public void TransformPebbleTo1_WhenBlinkingOnceOnPebble0()
    {
        var sut = new PlutonianPebbles("0");
        sut.Blink();
        Assert.Equal(1, sut.Count);
    }

    [Fact]
    public void MultiplyPebbleNumberBy2024_WhenBlinkingOnceOnPebble1()
    {
        var sut = new PlutonianPebbles("1");
        sut.Blink();
        Assert.Equal(1, sut.Count);
    }

    [Theory]
    [InlineData("10")]
    [InlineData("1000")]
    public void SplitPebbleInHalf_WhenPebbleHasEvenNumberOfDigits(string input)
    {
        var sut = new PlutonianPebbles(input);
        sut.Blink();
        Assert.Equal(2, sut.Count);
    }

    [Fact]
    public void MultiplyPebbleNumberBy2024_WhenBlinkingOnceOnPebbleNotCoveredByPreviousRules()
    {
        var sut = new PlutonianPebbles("999");
        sut.Blink();
        Assert.Equal(1, sut.Count);
    }

    [Fact]
    public void UpdatePebblesCorrectlyOnSecondSample()
    {
        var sut = new PlutonianPebbles(SECOND_SAMPLE_INPUT);
        sut.Blink();
        Assert.Equal(7, sut.Count);
    }

    [Fact]
    public void UpdatePebblesCorrectlyOnSample_WhenBlinkingOnce()
    {
        var sut = new PlutonianPebbles(SAMPLE_INPUT);
        sut.Blink();
        Assert.Equal(3, sut.Count);
    }

    [Fact]
    public void UpdatePebblesCorrectlyOnSample_WhenBlinkingTwice()
    {
        var sut = new PlutonianPebbles(SAMPLE_INPUT);
        sut.Blink(2);
        Assert.Equal(4, sut.Count);
    }

    [Fact]
    public void UpdatePebblesCorrectlyOnSample_WhenBlinkingThrice()
    {
        var sut = new PlutonianPebbles(SAMPLE_INPUT);
        sut.Blink(3);
        Assert.Equal(5, sut.Count);
    }

    [Fact]
    public void UpdatePebblesCorrectlyOnSample_WhenBlinkingFourTimes()
    {
        var sut = new PlutonianPebbles(SAMPLE_INPUT);
        sut.Blink(4);
        Assert.Equal(9, sut.Count);
    }

    [Fact]
    public void UpdatePebblesCorrectlyOnSample_WhenBlinkingFiveTimes()
    {
        var sut = new PlutonianPebbles(SAMPLE_INPUT);
        sut.Blink(5);
        Assert.Equal(13, sut.Count);
    }

    [Fact]
    public void UpdatePebblesCorrectlyOnSample_WhenBlinkingSixTimes()
    {
        var sut  =new PlutonianPebbles(SAMPLE_INPUT);
        sut.Blink(6);
        Assert.Equal(22, sut.Count);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new PlutonianPebbles(SAMPLE_INPUT);
        sut.Blink(25);
        Assert.Equal(55312, sut.Count);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new PlutonianPebbles(PUZZLE_INPUT);
        sut.Blink(25);
        Assert.Equal(189092, sut.Count);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = new PlutonianPebbles(PUZZLE_INPUT);
        sut.Blink(75);
        Assert.Equal(224_869_647_102_559, sut.Count);
    }
}