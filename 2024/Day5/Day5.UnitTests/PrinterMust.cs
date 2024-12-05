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

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new Printer(SAMPLE_INPUT);
        Assert.Equal(143, sut.SumOfMiddlePagesFromCorrectUpdates);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new Printer(PUZZLE_INPUT);
        Assert.Equal(4135, sut.SumOfMiddlePagesFromCorrectUpdates);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new Printer(SAMPLE_INPUT);
        Assert.Equal(123, sut.SumOfMiddlePagesFromIncorrectUpdates);
    }
}