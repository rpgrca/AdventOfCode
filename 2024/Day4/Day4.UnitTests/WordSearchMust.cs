using Day4.Logic;
using static Day4.UnitTests.Constants;

namespace Day4.UnitTests;

public class UnitTest1
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 10)]
    [InlineData(PUZZLE_INPUT, 140)]
    public void LoadInputCorrectly(string input, int expectedLength)
    {
        var sut = new WordSearch(input);
        Assert.Equal(expectedLength, sut.Length);
    }
}