using Day7.Logic;
using static Day7.UnitTests.Constants;

namespace Day7.UnitTests;

public class CamelCardsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 5)]
    [InlineData(PUZZLE_INPUT, 1000)]
    public void LoadInputCorrectly(string input, int expectedCount)
    {
        var sut = new CamelCards(input);
        Assert.Equal(expectedCount, sut.Hands);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new CamelCards(SAMPLE_INPUT);
        Assert.Equal(6440, sut.TotalWinnings);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new CamelCards(PUZZLE_INPUT);
        Assert.True(250456319 > sut.TotalWinnings);
        Assert.Equal(250232501, sut.TotalWinnings);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new CamelCards(SAMPLE_INPUT, true);
        Assert.Equal(5905, sut.TotalWinnings);
    }
}