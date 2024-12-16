using Day16.Logic;
using static Day16.UnitTests.Constants;

namespace Day16.UnitTests;

public class ReindeerMazeMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 15)]
    [InlineData(SECOND_SAMPLE_INPUT, 17)]
    [InlineData(PUZZLE_INPUT, 141)]
    public void LoadInputCorrectly(string input, int expectedSize)
    {
        var sut = new ReindeerMaze(input);
        Assert.Equal(expectedSize, sut.Size);
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 1, 13)]
    [InlineData(SECOND_SAMPLE_INPUT, 1, 15)]
    [InlineData(PUZZLE_INPUT, 1, 139)]
    public void LocateStartPointCorrectly(string input, int expectedX, int expectedY)
    {
        var sut = new ReindeerMaze(input);
        Assert.Equal((expectedX, expectedY), sut.StartPoint);
    }
}