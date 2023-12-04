using Day4.Logic;
using static Day4.UnitTests.Constants;

namespace Day4.UnitTests;

public class ScratchcardsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 6, 5, 8)]
    [InlineData(PUZZLE_INPUT, 223, 10, 25)]
    public void LoadInputCorrectly(string input, int expectedAmount, int expectedWinningNumbers, int expectedOwnedNumbers)
    {
        var sut = new Scratchcards(input);
        Assert.Equal(expectedAmount, sut.Amount);
        Assert.Equal(expectedWinningNumbers, sut.WinningAmount);
        Assert.Equal(expectedOwnedNumbers, sut.OwnedAmount);
    }

    [Fact]
    public void CalculateTotalPointsCorrectly()
    {
        var sut = new Scratchcards("Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53");
        Assert.Equal(8, sut.TotalPoints);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new Scratchcards(SAMPLE_INPUT);
        Assert.Equal(13, sut.TotalPoints);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new Scratchcards(PUZZLE_INPUT);
        Assert.Equal(32001, sut.TotalPoints);
    }

    [Theory]
    [InlineData(@"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19", 3)]
    [InlineData(@"Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1", 7)]
    public void CalculateScratchCount(string input, int expectedCount)
    {
        var sut = new Scratchcards(input);
        Assert.Equal(expectedCount, sut.WonScratchCount);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new Scratchcards(SAMPLE_INPUT);
        Assert.Equal(30, sut.WonScratchCount);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = new Scratchcards(PUZZLE_INPUT);
        Assert.Equal(5037841, sut.WonScratchCount);
    }
}