using Day2.Logic;
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
                Assert.Equal(3, p1.Draws[0].Blue);
                Assert.Equal(4, p1.Draws[0].Red);
                Assert.Equal(0, p1.Draws[0].Green);
            });
    }

    [Fact]
    public void ParseInputCorrectly_WhenGameHasMultipleDraws()
    {
        var sut = new CubeConundrumGame("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue");
        Assert.Collection(sut.Games,
            g1 =>
                Assert.Collection(g1.Draws,
                    d1 =>
                    {
                        Assert.Equal(3, d1.Blue);
                        Assert.Equal(4, d1.Red);
                        Assert.Equal(0, d1.Green);
                    },
                    d2 => {
                        Assert.Equal(6, d2.Blue);
                        Assert.Equal(1, d2.Red);
                        Assert.Equal(2, d2.Green);
                    })
        );
    }

    [Fact]
    public void ParseSampleInputCorrectly()
    {
        var sut = new CubeConundrumGame(@"Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue");
        Assert.Collection(sut.Games,
            g1 => Assert.Collection(g1.Draws,
                d1 =>
                {
                    Assert.Equal(3, d1.Blue);
                    Assert.Equal(4, d1.Red);
                    Assert.Equal(0, d1.Green);
                },
                d2 =>
                {
                    Assert.Equal(6, d2.Blue);
                    Assert.Equal(1, d2.Red);
                    Assert.Equal(2, d2.Green);
                },
                d3 =>
                {
                    Assert.Equal(0, d3.Blue);
                    Assert.Equal(0, d3.Red);
                    Assert.Equal(2, d3.Green);
                }),
            g2 => Assert.Collection(g2.Draws,
                d1 =>
                {
                    Assert.Equal(1, d1.Blue);
                    Assert.Equal(0, d1.Red);
                    Assert.Equal(2, d1.Green);
                },
                d2 => {
                    Assert.Equal(4, d2.Blue);
                    Assert.Equal(1, d2.Red);
                    Assert.Equal(3, d2.Green);
                },
                d3 =>
                {
                    Assert.Equal(1, d3.Blue);
                    Assert.Equal(0, d3.Red);
                    Assert.Equal(1, d3.Green);
                }
            )
        );
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new CubeConundrumGame(SAMPLE_INPUT);
        Assert.Equal(8, sut.SumOfValidGameIds);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new CubeConundrumGame(PUZZLE_INPUT);
        Assert.Equal(2563, sut.SumOfValidGameIds);
    }

    [Fact]
    public void CalculateSumOfPowersCorrectly_WhenInputHasOneGame()
    {
        var sut = new CubeConundrumGame("Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green");
        Assert.Equal(48, sut.SumOfPowers);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new CubeConundrumGame(SAMPLE_INPUT);
        Assert.Equal(2286, sut.SumOfPowers);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = new CubeConundrumGame(PUZZLE_INPUT);
        Assert.Equal(70768, sut.SumOfPowers);
    }
}