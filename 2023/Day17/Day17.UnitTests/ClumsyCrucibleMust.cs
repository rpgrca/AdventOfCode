using Day17.Logic;
using static Day17.UnitTests.Constants;

namespace Day17.UnitTests;

public class ClumsyCrucibleMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 13, 13)]
    [InlineData(PUZZLE_INPUT, 141, 141)]
    public void LoadInputCorrectly(string input, int expectedWidth, int expectedHeight)
    {
        var sut = new ClumsyCrucible(input);
        Assert.Equal(expectedWidth, sut.Width);
        Assert.Equal(expectedHeight, sut.Height);
    }
}