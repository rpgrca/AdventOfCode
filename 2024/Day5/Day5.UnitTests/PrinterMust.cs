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
        var sut = PrinterFactory.WithoutReordering(input);
        Assert.Equal(expectedRules, sut.RuleCount);
        Assert.Equal(expectedUpdates, sut.UpdatesCount);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = PrinterFactory.WithoutReordering(SAMPLE_INPUT);
        Assert.Equal(143, sut.SumOfMiddlePages);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = PrinterFactory.WithoutReordering(PUZZLE_INPUT);
        Assert.Equal(4135, sut.SumOfMiddlePages);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = PrinterFactory.WithReordering(SAMPLE_INPUT);
        Assert.Equal(123, sut.SumOfMiddlePages);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = PrinterFactory.WithReordering(PUZZLE_INPUT);
        Assert.Equal(5285, sut.SumOfMiddlePages);
    }
}