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

    [Fact]
    public void LocateGalaxiesInExpandedUniverseCorrectly()
    {
        var sut = new CosmicExpansion(SAMPLE_INPUT);
        Assert.Collection(sut.Galaxies,
            g1 => Assert.Equal((4, 0), g1),
            g2 => Assert.Equal((9, 1), g2),
            g3 => Assert.Equal((0, 2), g3),
            g4 => Assert.Equal((8, 5), g4),
            g5 => Assert.Equal((1, 6), g5),
            g6 => Assert.Equal((12, 7), g6),
            g7 => Assert.Equal((9, 10), g7),
            g8 => Assert.Equal((0, 11), g8),
            g9 => Assert.Equal((5, 11), g9));
    }

    [Theory]
    [InlineData(4, 8, 9)]
    public void CalculateGalaxyDistanceCorrectly(int start, int end, int expectedDistance)
    {
        var sut = new CosmicExpansion(SAMPLE_INPUT);
        Assert.Equal(expectedDistance, sut.CalculateDistanceBetween(start, end));
    }
}