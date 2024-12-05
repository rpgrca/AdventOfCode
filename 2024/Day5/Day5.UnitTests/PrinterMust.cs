using Day5.Logic;
using static Day5.UnitTests.Constants;

namespace Day5.UnitTests;

public class PrinterMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 21, 6)]
    [InlineData(PUZZLE_INPUT, 1176, 190)]
    public void LoadInputCorrectly(string input, int expectedRules, int expectedUpdates)
    {
        var sut = new Printer(input);
        Assert.Equal(expectedRules, sut.RuleCount);
        Assert.Equal(expectedUpdates, sut.UpdatesCount);
    }
}