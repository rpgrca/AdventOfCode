using Day14.Logic;
using static Day14.UnitTests.Constants;

namespace Day14.UnitTests;

public class RestroomRedoubtMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 11, 7, 12)]
    [InlineData(PUZZLE_INPUT, 101, 103, 500)]
    public void LoadInputCorrectly(string input, int width, int height, int expectedCount)
    {
        var sut = new RestroomRedoubt(input, width, height);
        Assert.Equal(expectedCount, sut.RobotCount);
    }
}