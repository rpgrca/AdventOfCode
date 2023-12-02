using Day2.Logic;
using static Day2.UnitTests.Constants;

namespace Day2.UnitTests;

public class CubeConundrumGameMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 5)]
    [InlineData(PUZZLE_INPUT, 100)]
    public void LoadInputCorrectly(string input, int expectedLength)
    {
        var sut = new CubeConundrumGame(input);
        Assert.Equal(expectedLength, sut.Games);
    }
}