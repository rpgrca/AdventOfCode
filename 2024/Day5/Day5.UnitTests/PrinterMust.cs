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
        var sut = Printer.WithoutReordering(input);
        Assert.Equal(expectedRules, sut.RuleCount);
        Assert.Equal(expectedUpdates, sut.UpdatesCount);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = Printer.WithoutReordering(SAMPLE_INPUT);
        Assert.Equal(143, sut.SumOfMiddlePages);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = Printer.WithoutReordering(PUZZLE_INPUT);
        Assert.Equal(4135, sut.SumOfMiddlePages);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = Printer.WithReordering(SAMPLE_INPUT);
        Assert.Equal(123, sut.SumOfMiddlePages);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = Printer.WithReordering(PUZZLE_INPUT);
        Assert.Equal(5285, sut.SumOfMiddlePages);
    }
}