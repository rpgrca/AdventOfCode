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
    [InlineData(PUZZLE_INPUT, 150, 150)]
    public void ExpandUniverseCorrectly(string input, int expectedWidth, int expectedHeight)
    {
        var sut = new CosmicExpansion(input);
        Assert.Equal(expectedWidth, sut.ExpandedWidth);
        Assert.Equal(expectedHeight, sut.ExpandedHeight);
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 9)]
    [InlineData(PUZZLE_INPUT, 427)]
    public void CountGalaxiesCorrectly(string input, int expectedGalaxies)
    {
        var sut = new CosmicExpansion(input);
        Assert.Equal(expectedGalaxies, sut.GalaxyCount);
    }
}