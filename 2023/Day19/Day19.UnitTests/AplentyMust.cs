using Day19.Logic;
using static Day19.UnitTests.Constants;

namespace Day19.UnitTests;

public class AplentyMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 11, 5)]
    [InlineData(PUZZLE_INPUT, 587, 200)]
    public void LoadDataCorrectly(string input, int expectedRuleCount, int expectedPartCount)
    {
        var sut = new Aplenty(input);
        Assert.Equal(expectedRuleCount, sut.RuleCount);
        Assert.Equal(expectedPartCount, sut.PartCount);
    }
}