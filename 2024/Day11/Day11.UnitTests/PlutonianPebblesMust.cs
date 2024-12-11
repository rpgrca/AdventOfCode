using System.Numerics;
using Day11.Logic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Host;
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
        Assert.Collection(sut.Pebbles, p1 => Assert.Equal(1, p1));
    }

    [Fact]
    public void MultiplyPebbleNumberBy2024_WhenBlinkingOnceOnPebble1()
    {
        var sut = new PlutonianPebbles("1");
        sut.Blink();
        Assert.Collection(sut.Pebbles, p1 => Assert.Equal(2024, p1));
    }

    [Theory]
    [InlineData("10", 1, 0)]
    [InlineData("1000", 10, 0)]
    public void SplitPebbleInHalf_WhenPebbleHasEvenNumberOfDigits(string input, int expectedLeft, int expectedRight)
    {
        var sut = new PlutonianPebbles(input);
        sut.Blink();
        Assert.Collection(sut.Pebbles,
            p1 => Assert.Equal(expectedLeft, p1),
            p2 => Assert.Equal(expectedRight, p2));
    }

    [Fact]
    public void MultiplyPebbleNumberBy2024_WhenBlinkingOnceOnPebbleNotCoveredByPreviousRules()
    {
        var sut = new PlutonianPebbles("999");
        sut.Blink();
        Assert.Collection(sut.Pebbles, p1 => Assert.Equal(2021976, p1));
    }

    [Fact]
    public void UpdatePebblesCorrectlyOnSecondSample()
    {
        var sut = new PlutonianPebbles(SECOND_SAMPLE_INPUT);
        sut.Blink();
        Assert.Collection(sut.Pebbles,
            p1 => Assert.Equal(1, p1),
            p2 => Assert.Equal(2024, p2),
            p3 => Assert.Equal(1, p3),
            p4 => Assert.Equal(0, p4),
            p5 => Assert.Equal(9, p5),
            p6 => Assert.Equal(9, p6),
            p7 => Assert.Equal(2021976, p7));
    }

    [Fact]
    public void UpdatePebblesCorrectlyOnSample_WhenBlinkingOnce()
    {
        var sut = new PlutonianPebbles(SAMPLE_INPUT);
        sut.Blink();
        Assert.Collection(sut.Pebbles,
            p1 => Assert.Equal(253000, p1),
            p2 => Assert.Equal(1, p2),
            p3 => Assert.Equal(7, p3));
    }

    [Fact]
    public void UpdatePebblesCorrectlyOnSample_WhenBlinkingTwice()
    {
        var sut = new PlutonianPebbles(SAMPLE_INPUT);
        sut.Blink(2);
        Assert.Collection(sut.Pebbles,
            p1 => Assert.Equal(253, p1),
            p2 => Assert.Equal(0, p2),
            p3 => Assert.Equal(2024, p3),
            p4 => Assert.Equal(14168, p4));
    }

}