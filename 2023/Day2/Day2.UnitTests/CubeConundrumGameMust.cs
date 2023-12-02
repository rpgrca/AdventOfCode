using Day2.Logic;
using static Day2.UnitTests.Constants;

namespace Day2.UnitTests;

public class CubeConundrumGameMust
{
    [Fact]
    public void LoadInputCorrectly()
    {
        var sut = new CubeConundrumGame(SAMPLE_INPUT);
        Assert.Equal(5, sut.Games);
    }
}