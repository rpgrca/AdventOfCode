using Day6.Logic;
using static Day6.UnitTests.Constants;

namespace Day6.UnitTests;

public class GuardPatrolProtocolMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 10)]
    [InlineData(PUZZLE_INPUT, 130)]
    public void LoadInputCorrectly(string input, int expectedLength)
    {
        var sut = new GuardPatrolProtocol(input);
        Assert.Equal(expectedLength, sut.Length);
    }
}