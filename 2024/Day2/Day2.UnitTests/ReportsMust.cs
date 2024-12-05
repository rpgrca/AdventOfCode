using Day2.Logic;
using static Day2.UnitTests.Constants;

namespace Day2.UnitTests;

public class ReportsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 6)]
    [InlineData(PUZZLE_INPUT, 1000)]
    public void LoadInputCorrectly(string input, int expectedLength)
    {
        var sut = Reports.CreateWithoutDampener(input);
        Assert.Equal(expectedLength, sut.Length);
    }

    [Theory]
    [InlineData("7 6 4 2 1", 1)]
    [InlineData("1 2 7 8 9", 0)]
    [InlineData("9 7 6 2 1", 0)]
    [InlineData("1 3 2 4 5", 0)]
    [InlineData("8 6 4 4 1", 0)]
    [InlineData("1 3 6 7 9", 1)]
    public void DetermineSafeReportCorrectly(string input, int expectedCount)
    {
        var sut = Reports.CreateWithoutDampener(input);
        Assert.Equal(expectedCount, sut.SafeReportsCount);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = Reports.CreateWithoutDampener(SAMPLE_INPUT);
        Assert.Equal(2, sut.SafeReportsCount);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = Reports.CreateWithoutDampener(PUZZLE_INPUT);
        Assert.Equal(326, sut.SafeReportsCount);
    }

    [Theory]
    [InlineData("7 6 4 2 1", 1)]
    [InlineData("1 3 6 7 9", 1)]
    [InlineData("1 2 7 8 9", 0)]
    [InlineData("9 7 6 2 1", 0)]
    [InlineData("1 3 2 4 5", 1)]
    [InlineData("8 6 4 4 1", 1)]
    [InlineData("1 3 2 4 3", 0)]
    [InlineData("9 7 8 6 7", 0)]
    [InlineData("1 2 7 3 4", 1)]
    [InlineData("1 2 7 3 8", 0)]
    [InlineData("9 1 2 3 4", 1)]
    [InlineData("4 4 5 6 7", 1)]
    public void HaveWorkingProblemDampener(string input, int expectedCount)
    {
        var sut = Reports.CreateWithDampener(input);
        Assert.Equal(expectedCount, sut.SafeReportsCount);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = Reports.CreateWithDampener(SAMPLE_INPUT);
        Assert.Equal(4, sut.SafeReportsCount);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = Reports.CreateWithDampener(PUZZLE_INPUT);
        Assert.Equal(381, sut.SafeReportsCount);
    }
}