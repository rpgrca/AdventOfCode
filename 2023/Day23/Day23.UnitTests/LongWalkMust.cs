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

    [Theory]
    [InlineData("#.###\n#...#\n###.#", 4)]
    [InlineData("#.#######\n#.......#\n#.###.#.#\n#.....#.#\n#######.#", 14)]
    public void FindLongestPathCorrectly(string input, int expectedLength)
    {
        var sut = new LongWalk(input);
        sut.FindLongestSlipperyPath();
        Assert.Equal(expectedLength, sut.LongestPathLength);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new LongWalk(SAMPLE_INPUT);
        sut.FindLongestSlipperyPath();
        Assert.Equal(94, sut.LongestPathLength);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new LongWalk(PUZZLE_INPUT);
        sut.FindLongestSlipperyPath();
        Assert.Equal(2130, sut.LongestPathLength);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new LongWalk(SAMPLE_INPUT);
        sut.FindLongestDryPath();
        Assert.Equal(154, sut.LongestPathLength);
    }
}