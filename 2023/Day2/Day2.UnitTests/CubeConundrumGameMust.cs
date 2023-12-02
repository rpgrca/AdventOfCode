using Day2.Logic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Host;
using static Day2.UnitTests.Constants;

namespace Day2.UnitTests;

public class CubeConundrumGameMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 5)]
    [InlineData(PUZZLE_INPUT, 100)]
    public void LoadInputCorrectly(string input, int expectedLength)
    {
        var sut = new CubeConundrumGame(input);
        Assert.Equal(expectedLength, sut.GameCount);
    }

    [Fact]
    public void ParseInputCorrectly()
    {
        var sut = new CubeConundrumGame("Game 1: 3 blue, 4 red");
        Assert.Collection(sut.Games,
            p1 => {
                Assert.Equal(3, p1.Blue);
                Assert.Equal(4, p1.Red);
                Assert.Equal(0, p1.Green);
            });
    }

    [Fact]
    public void ParseInputCorrectly_WhenGameHasMultipleDraws()
    {
        var sut = new CubeConundrumGame("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue");
        Assert.Collection(sut.Games,
            p1 => {
                Assert.Equal(3, p1.Blue);
                Assert.Equal(4, p1.Red);
                Assert.Equal(0, p1.Green);
            },
            p2 => {
                Assert.Equal(6, p2.Blue);
                Assert.Equal(1, p2.Red);
                Assert.Equal(2, p2.Green);
            });
    }

}