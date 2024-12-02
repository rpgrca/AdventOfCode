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
        var sut = new Reports(input);
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
        var sut = new Reports(input);
        Assert.Equal(expectedCount, sut.SafeReportsCount);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new Reports(SAMPLE_INPUT);
        Assert.Equal(2, sut.SafeReportsCount);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new Reports(PUZZLE_INPUT);
        Assert.Equal(326, sut.SafeReportsCount);
    }

    [Theory]
    [InlineData("7 6 4 2 1", 1)]
    [InlineData("1 3 6 7 9", 1)]
    [InlineData("1 2 7 8 9", 0)]
    [InlineData("9 7 6 2 1", 0)]
    //[InlineData("1 3 2 4 5", 1)]
    public void HaveWorkingProblemDampener(string input, int expectedCount)
    {
        var sut = new Reports(input);
        Assert.Equal(expectedCount, sut.SafeReportsWithDampener);
    }
}