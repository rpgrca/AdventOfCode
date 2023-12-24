using System.Security.Cryptography;
using Day24.Logic;
using static Day24.UnitTests.Constants;

namespace Day24.UnitTests;

public class NeverTellMeTheOddsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 5)]
    [InlineData(PUZZLE_INPUT, 300)]
    public void LoadInputCorrectly(string input, int expectedLength)
    {
        var sut = new NeverTellMeTheOdds(input);
        Assert.Equal(expectedLength, sut.HailCount);
    }

    [Fact]
    public void ParseInputCorrectly()
    {
        var sut = new NeverTellMeTheOdds(SAMPLE_INPUT);
        Assert.Collection(sut.Hails,
            h1 => Assert.Equal(((19UL, 13UL, 30UL), (-2,  1, -2)), h1.Data),
            h2 => Assert.Equal(((18UL, 19UL, 22UL), (-1, -1, -2)), h2.Data),
            h3 => Assert.Equal(((20UL, 25UL, 34UL), (-2, -2, -4)), h3.Data),
            h4 => Assert.Equal(((12UL, 31UL, 28UL), (-1, -2, -1)), h4.Data),
            h5 => Assert.Equal(((20UL, 19UL, 15UL), ( 1, -5, -3)), h5.Data));
    }
}