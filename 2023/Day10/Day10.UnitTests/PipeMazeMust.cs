using Day10.Logic;
using static Day10.UnitTests.Constants;

namespace Day10.UnitTests;

public class PipeMazeMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 5, 5)]
    [InlineData(THIRD_SAMPLE_INPUT, 5, 5)]
    [InlineData(PUZZLE_INPUT, 140, 140)]
    public void LoadInputCorrectly(string input, int expectedWidth, int expectedHeight)
    {
        var sut = new PipeMaze(input);
        Assert.Equal(expectedWidth, sut.W);
        Assert.Equal(expectedHeight, sut.H);
    }
}