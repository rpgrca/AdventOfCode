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
}