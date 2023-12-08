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
        Assert.True(250_456_319 > sut.TotalWinnings);
        Assert.Equal(250_232_501, sut.TotalWinnings);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new CamelCards(SAMPLE_INPUT, true);
        Assert.Equal(5905, sut.TotalWinnings);
    }

    [Fact]
    public void SortTypesCorrectly()
    {
        var sut = new CamelCards("QQQQ2 3\nJKKK2 5", true);
        Assert.Equal(11, sut.TotalWinnings);
    }

    [Fact]
    public void SortTypesCorrectly_WhenFullHouseAndPokerWithJockerExist()
    {
        var sut = new CamelCards("JJ992 3\nJ2332 5", true);
        Assert.Equal(11, sut.TotalWinnings);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = new CamelCards(PUZZLE_INPUT, true);
        Assert.True(249_975_781 > sut.TotalWinnings);
        Assert.Equal(249_138_943, sut.TotalWinnings);
    }
}