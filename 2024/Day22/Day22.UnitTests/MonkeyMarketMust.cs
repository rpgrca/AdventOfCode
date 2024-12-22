using Day22.Logic;
using static Day22.UnitTests.Constants;

namespace Day22.UnitTests;

public class MonkeyMarketMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 4)]
    [InlineData(PUZZLE_INPUT, 2032)]
    public void LoadInputCorrectly(string input, int expectedCount)
    {
        var sut = new MonkeyMarket(input);
        Assert.Equal(expectedCount, sut.Count);
    }
}