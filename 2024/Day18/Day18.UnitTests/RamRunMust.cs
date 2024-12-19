using Day18.Logic;
using static Day18.UnitTests.Constants;

namespace Day18.UnitTests;

public class RamRunMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 25, 7)]
    [InlineData(PUZZLE_INPUT, 3450, 71)]
    public void LoadInputCorrectly(string input, int expectedCount, int expectedSize)
    {
        var sut = new RamRun(input, expectedSize);
        Assert.Equal(expectedCount, sut.Count);
        Assert.Equal(expectedSize, sut.Size);
    }

    [Fact]
    public void LoadCorruptedMemoryInMapCorrectly()
    {
        var sut = new RamRun(SAMPLE_INPUT, 7);
        sut.Load(12);
        Assert.Equal(@"...#...
..#..#.
....#..
...#..#
..#..#.
.#..#..
#.#....", sut.Plot());
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new RamRun(SAMPLE_INPUT, 7);
        sut.Load(12);
        sut.Solve();
        Assert.Equal(22, sut.Steps);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new RamRun(PUZZLE_INPUT, 71);
        sut.Load(1024);
        sut.Solve();
        Assert.True(254 < sut.Steps);
        Assert.True(260 < sut.Steps);
        Assert.Equal(262, sut.Steps);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new RamRun(SAMPLE_INPUT, 7);
        sut.Load(12);
        sut.SolveDrop(12);
        Assert.Equal("6,1", sut.BlockedPath);
    }
}