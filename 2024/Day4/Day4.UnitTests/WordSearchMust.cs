using Day4.Logic;
using static Day4.UnitTests.Constants;

namespace Day4.UnitTests;

public class UnitTest1
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 10)]
    [InlineData(SECOND_SAMPLE_INPUT, 5)]
    [InlineData(PUZZLE_INPUT, 140)]
    public void LoadInputCorrectly(string input, int expectedLength)
    {
        var sut = new WordSearch(input);
        Assert.Equal(expectedLength, sut.Length);
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
.....", 1)]
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
}