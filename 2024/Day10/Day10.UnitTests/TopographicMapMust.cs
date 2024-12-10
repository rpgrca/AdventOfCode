using Day10.Logic;
using static Day10.UnitTests.Constants;

namespace Day10.UnitTests;

public class TopographicMapMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 8)]
    [InlineData(SECOND_SAMPLE_INPUT, 4)]
    [InlineData(THIRD_SAMPLE_INPUT, 7)]
    [InlineData(FOURTH_SAMPLE_INPUT, 7)]
    [InlineData(PUZZLE_INPUT, 47)]
    public void LoadInputCorrectly(string input, int expectedSize)
    {
        var sut = new TopographicMap(input);
        Assert.Equal(expectedSize, sut.Size);
    }
}