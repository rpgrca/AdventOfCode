using Day23.Logic;
using static Day23.UnitTests.Constants;

namespace Day23.UnitTests;

public class LongWalkMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 23, 23)]
    [InlineData(PUZZLE_INPUT, 141, 141)]
    public void LoadInputCorrectly(string input, int expectedWidth, int expectedHeight)
    {
        var sut = new LongWalk(input);
        Assert.Equal(expectedWidth, sut.Width);
        Assert.Equal(expectedHeight, sut.Height);
    }

    [Theory]
    [InlineData(SAMPLE_INPUT)]
    [InlineData(PUZZLE_INPUT)]
    public void FindStartPositionCorrectly(string input)
    {
        var sut = new LongWalk(input);
        Assert.Equal((1, 0), sut.StartingPosition);
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 21, 22)]
    public void FindEndPositionCorrectly(string input, int expectedX, int expectedY)
    {
        var sut = new LongWalk(input);
        Assert.Equal((expectedX, expectedY), sut.EndingPosition);
    }
}