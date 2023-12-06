using Day6.Logic;
using static Day6.UnitTests.Constants;

namespace Day6.UnitTests;

public class ToyBoatMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 3)]
    [InlineData(PUZZLE_INPUT, 4)]
    public void LoadInputCorrectly(string input, int expectedRaces)
    {
        var sut = new ToyBoat(input);
        Assert.Equal(expectedRaces, sut.RaceCount);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new ToyBoat(SAMPLE_INPUT);
        Assert.Equal(288, sut.WaysToBreakRecord);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new ToyBoat(PUZZLE_INPUT);
        Assert.Equal(293046, sut.WaysToBreakRecord);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new ToyBoat(SAMPLE_INPUT, false);
        Assert.Equal(71503, sut.WaysToBreakRecord);
    }


}