using System.Reflection.Metadata;
using Day20.Logic;
using static Day20.UnitTests.Constants;

namespace Day20.UnitTests;

public class RaceConditionMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 15, 1, 3, 5, 7)]
    [InlineData(PUZZLE_INPUT, 141, 43, 73, 69, 71)]
    public void LoadInputCorrectly(string input, int expectedSize, int startX, int startY, int endX, int endY)
    {
        var sut = new RaceCondition(input);
        Assert.Equal(expectedSize, sut.Size);
        Assert.Equal((startX, startY), sut.Start);
        Assert.Equal((endX, endY), sut.End);
    }

    [Theory]
    [InlineData(1, 0)]
    [InlineData(2, 1)]
    [InlineData(3, 1)]
    [InlineData(4, 2)]
    [InlineData(5, 2)]
    [InlineData(6, 2)]
    public void FindCheatsCorrectly(int picoseconds, int expectedCount)
    {
        var sut = new RaceCondition("#####\n#S..#\n###.#\n#E..#\n#####");
        sut.FindCheatsSavingAtLeast(picoseconds);
        Assert.Equal(expectedCount, sut.FastCheatsCount);
    }

    [Theory]
    [InlineData(64, 44)]
    [InlineData(40, 43)]
    [InlineData(38, 42)]
    [InlineData(36, 41)]
    [InlineData(20, 40)]
    [InlineData(12, 39)]
    [InlineData(10, 36)]
    [InlineData(8, 34)]
    [InlineData(6, 30)]
    [InlineData(4, 28)]
    [InlineData(2, 14)]
    public void ExecuteSamplesCorrectly(int picoseconds, int expectedCount)
    {
        var sut = new RaceCondition(SAMPLE_INPUT);
        sut.FindCheatsSavingAtLeast(picoseconds);
        Assert.Equal(expectedCount, sut.FastCheatsCount);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new RaceCondition(SAMPLE_INPUT);
        sut.FindCheatsSavingAtLeast(1000);
        Assert.Equal(44, sut.FastCheatsCount);
    }
}