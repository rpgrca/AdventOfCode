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
    public void UpdatePebblesCorrectly_WhenBlinkingOnceOnZeroPebble()
    {
        var sut = new PlutonianPebbles("0");
        sut.Blink();
        Assert.Collection(sut.Pebbles, p1 => Assert.Equal(1, p1));
    }

    [Fact]
    public void UpdatePebblesCorrectly_WhenBlinkingOnceOnOnePebble()
    {
        var sut = new PlutonianPebbles("1");
        sut.Blink();
        Assert.Collection(sut.Pebbles, p1 => Assert.Equal(2024, p1));
    }

    [Theory]
    [InlineData("10", 1, 0)]
    [InlineData("1000", 10, 0)]
    public void UpdatePebblesCorrectly_WhenPebbleHasEvenNumberOfDigits(string input, int expectedLeft, int expectedRight)
    {
        var sut = new PlutonianPebbles(input);
        sut.Blink();
        Assert.Collection(sut.Pebbles,
            p1 => Assert.Equal(expectedLeft, p1),
            p2 => Assert.Equal(expectedRight, p2));
    }
}