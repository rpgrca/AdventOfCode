using Day1.Logic;
using static Day1.UnitTests.Constants;

namespace Day1.UnitTests;

public class HistoricallySignificantLocationsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 6)]
    [InlineData(PUZZLE_INPUT, 1000)]
    public void LoadDataCorrectly(string input, int expectedLength)
    {
        var sut = new HistoricallySignificantLocations(input);
        Assert.Equal(expectedLength, sut.Length);
    }

    [Theory]
    [InlineData("1   1", 0)]
    [InlineData("1   2", 1)]
    [InlineData("2   1", 1)]
    [InlineData("1   2\n2   1", 0)]
    public void CalculateTotalDistanceCorrectly(string input, int expectedDistance)
    {
        var sut = new HistoricallySignificantLocations(input);
        Assert.Equal(expectedDistance, sut.TotalDistance);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new HistoricallySignificantLocations(SAMPLE_INPUT);
        Assert.Equal(11, sut.TotalDistance);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new HistoricallySignificantLocations(PUZZLE_INPUT);
        Assert.Equal(1151792, sut.TotalDistance);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new HistoricallySignificantLocations(SAMPLE_INPUT);
        Assert.Equal(31, sut.SimilarityScore);
    }
}