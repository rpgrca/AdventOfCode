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
    [InlineData(1, 2)]
    [InlineData(2, 2)]
    [InlineData(3, 1)]
    [InlineData(4, 1)]
    [InlineData(5, 0)]
    [InlineData(6, 0)]
    public void FindCheatsCorrectly(int picoseconds, int expectedCount)
    {
        var sut = new RaceCondition("#####\n#S..#\n###.#\n#E..#\n#####");
        sut.FindCheatsSavingAtLeast(picoseconds);
        Assert.Equal(expectedCount, sut.FastCheatsCount);
    }

    [Theory]
    [InlineData(64, 1)]
    [InlineData(40, 2)]
    [InlineData(38, 3)]
    [InlineData(36, 4)]
    [InlineData(20, 5)]
    [InlineData(12, 8)]
    [InlineData(10, 10)]
    [InlineData(8, 14)]
    [InlineData(6, 16)]
    [InlineData(4, 30)]
    [InlineData(2, 44)]
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
        sut.FindCheatsSavingAtLeast(100);
        Assert.Equal(0, sut.FastCheatsCount);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new RaceCondition(PUZZLE_INPUT);
        sut.FindCheatsSavingAtLeast(100);
        Assert.True(6763 > sut.FastCheatsCount);
        Assert.True(5644 > sut.FastCheatsCount);
        Assert.Equal(1286, sut.FastCheatsCount);
    }

    [Theory]
    [InlineData(76, 3)]
    [InlineData(74, 7)]
    [InlineData(72, 29)]
    [InlineData(70, 41)]
    [InlineData(68, 55)]
    [InlineData(66, 67)]
    [InlineData(64, 86)]
    [InlineData(62, 106)]
    [InlineData(60, 129)]
    [InlineData(58, 154)]
    [InlineData(56, 193)]
    [InlineData(54, 222)]
    [InlineData(52, 253)]
    [InlineData(50, 285)]
    public void SolveSecondSampleCorrectly(int picoseconds, int expectedCount)
    {
        var sut = new RaceCondition(SAMPLE_INPUT);
        sut.Find20SecondCheatsSavingAtLeast(picoseconds);
        Assert.Equal(expectedCount, sut.FastCheatsCount);
    }
}