using Day23.Logic;
using static Day23.UnitTests.Constants;

namespace Day23.UnitTests;

public class LanPartyMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 32)]
    public void LoadInputCorrectly(string input, int expectedCount)
    {
        var sut = new LanParty(input);
        Assert.Equal(expectedCount, sut.Count);
    }
}