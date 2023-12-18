using Day18.Logic;
using static Day18.UnitTests.Constants;

namespace Day18.UnitTests;

public class LavaductLagoonMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 14)]
    public void LoadInputCorrectly(string input, int expectedLength)
    {
        var sut = new LavaductLagoon(input);
        Assert.Equal(expectedLength, sut.DigPlanLength);
    }
}