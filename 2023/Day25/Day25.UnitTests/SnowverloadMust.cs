using Day25.Logic;
using static Day25.UnitTests.Constants;

namespace Day25.UnitTests;

public class SnowverloadMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 13)]
    [InlineData(PUZZLE_INPUT, 1264)]
    public void LoadInputCorrectly(string input, int expectedLength)
    {
        var sut = new Snowverload(input);
        Assert.Equal(expectedLength, sut.ComponentCount);
    }
}