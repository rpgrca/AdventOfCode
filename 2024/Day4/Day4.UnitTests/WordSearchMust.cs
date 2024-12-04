using Day4.Logic;
using static Day4.UnitTests.Constants;

namespace Day4.UnitTests;

public class UnitTest1
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 10, 10)]
    [InlineData(SECOND_SAMPLE_INPUT, 6, 5)]
    [InlineData(PUZZLE_INPUT, 140, 140)]
    public void LoadInputCorrectly(string input, int expectedWidth, int expectedHeight)
    {
        var sut = new WordSearch(input);
        Assert.Equal(expectedWidth, sut.Width);
        Assert.Equal(expectedHeight, sut.Height);
    }

    [Theory]
    [InlineData(@"......
......
......
XMAS..
......", 1)]
    [InlineData(@"......
.SAMX.
......
......
......", 1)]
    [InlineData(@"......
.SAMX.
......
XMAS..
......", 2)]
    public void FindXmasHorizontally(string input, int expectedLength)
    {
        var sut = new WordSearch(input);
        Assert.Equal(expectedLength, sut.XmasCount);
    }

    [Theory]
    [InlineData(@"......
.S....
.A....
.M....
.X....", 1)]
    [InlineData(@"..X...
..M...
..A...
..S...
......", 1)]
    [InlineData(@"..X...
.SM...
.AA...
.MS...
.X....", 2)]
    public void FindXmasVertically(string input, int expectedLength)
    {
        var sut = new WordSearch(input);
        Assert.Equal(expectedLength, sut.XmasCount);
    }

    [Theory]
    [InlineData(@"..X...
...M..
....A.
.....S
......", 1)]
    [InlineData(@"...X..
..M...
.A....
S.....
......", 1)]
    [InlineData(@"......
....S.
...A..
..M...
.X....", 1)]
    [InlineData(@"......
..S...
...A..
....M.
.....X", 1)]
    [InlineData(@"X..X..
SMM.S.
.AAA..
S.MS..
.X.X..", 4)]
    public void FindXmasDiagonally(string input, int expectedCount)
    {
        var sut = new WordSearch(input);
        Assert.Equal(expectedCount, sut.XmasCount);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new WordSearch(SAMPLE_INPUT);
        Assert.Equal(18, sut.XmasCount);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new WordSearch(PUZZLE_INPUT);
        Assert.Equal(2532, sut.XmasCount);
    }

    [Theory]
    [InlineData("M.M\n.A.\nS.S")]
    [InlineData("S.S\n.A.\nM.M")]
    [InlineData("M.S\n.A.\nM.S")]
    [InlineData("S.M\n.A.\nS.M")]
    public void FindX_MasCorrectly(string input)
    {
        var sut = new WordSearch(input);
        Assert.Equal(1, sut.X_MasCount);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new WordSearch(SAMPLE_INPUT);
        Assert.Equal(9, sut.X_MasCount);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = new WordSearch(PUZZLE_INPUT);
        Assert.Equal(1941, sut.X_MasCount);
    }
}