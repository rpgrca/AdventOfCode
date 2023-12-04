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
}