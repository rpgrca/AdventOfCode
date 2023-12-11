using Day11.Logic;
using static Day11.UnitTests.Constants;

namespace Day11.UnitTests;

public class CosmicExpansionMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 10, 10)]
    [InlineData(PUZZLE_INPUT, 140, 140)]
    public void LoadInputCorrectly(string input, int expectedWidth, int expectedHeight)
    {
        var sut = new CosmicExpansion(input);
        Assert.Equal(expectedWidth, sut.Width);
        Assert.Equal(expectedHeight, sut.Height);
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 13, 12)]
    public void ExpandUniverseCorrectly(string input, int expectedWidth, int expectedHeight)
    {
        var sut = new CosmicExpansion(input);
        Assert.Equal(expectedWidth, sut.ExpandedWidth);
        Assert.Equal(expectedHeight, sut.ExpandedHeight);
    }
}