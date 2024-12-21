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
    [InlineData(2, 0)]
    [InlineData(3, 0)]
    [InlineData(4, 1)]
    [InlineData(5, 1)]
    [InlineData(6, 2)]
    public void FindCheatsCorrectly(int picoseconds, int expectedCount)
    {
        var sut = new RaceCondition("#####\n#S..#\n###.#\n#E..#\n#####");
        sut.FindCheatsSaving(picoseconds);
        Assert.Equal(expectedCount, sut.FastCheatsCount);
    }
}