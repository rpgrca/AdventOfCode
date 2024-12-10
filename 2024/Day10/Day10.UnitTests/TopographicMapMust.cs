using Day10.Logic;
using static Day10.UnitTests.Constants;

namespace Day10.UnitTests;

public class TopographicMapMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 8)]
    [InlineData(SECOND_SAMPLE_INPUT, 4)]
    [InlineData(THIRD_SAMPLE_INPUT, 7)]
    [InlineData(FOURTH_SAMPLE_INPUT, 7)]
    [InlineData(PUZZLE_INPUT, 47)]
    public void LoadInputCorrectly(string input, int expectedSize)
    {
        var sut = TopographicMap.ForScore(input);
        Assert.Equal(expectedSize, sut.Size);
    }

    [Fact]
    public void LocateTrailheadsCorrectly_WhenUsingSecondSample()
    {
        var sut = TopographicMap.ForScore(SECOND_SAMPLE_INPUT);
        Assert.Collection(sut.Trailheads, p1 => Assert.Equal((0, 0), p1));
    }

    [Theory]
    [InlineData(THIRD_SAMPLE_INPUT)]
    [InlineData(FOURTH_SAMPLE_INPUT)]
    public void LocateTrailheadsCorrectly_WhenUsingThirdOrFourthSample(string input)
    {
        var sut = TopographicMap.ForScore(input);
        Assert.Collection(sut.Trailheads, p1 => Assert.Equal((3, 0), p1));
    }

    [Fact]
    public void LocateTrailheadsCorrectly_WhenUsingFifthSample()
    {
        var sut = TopographicMap.ForScore(FIFTH_SAMPLE_INPUT);
        Assert.Collection(sut.Trailheads,
            p1 => Assert.Equal((1, 0), p1),
            p2 => Assert.Equal((5, 6), p2));
    }

    [Fact]
    public void LocateTrailheadsCorrectly_WhenUsingSampleMap()
    {
        var sut = TopographicMap.ForScore(SAMPLE_INPUT);
        Assert.Collection(sut.Trailheads,
            p1 => Assert.Equal((2, 0), p1),
            p2 => Assert.Equal((4, 0), p2),
            p3 => Assert.Equal((4, 2), p3),
            p4 => Assert.Equal((6, 4), p4),
            p5 => Assert.Equal((2, 5), p5),
            p6 => Assert.Equal((5, 5), p6),
            p7 => Assert.Equal((0, 6), p7),
            p8 => Assert.Equal((6, 6), p8),
            p9 => Assert.Equal((1, 7), p9));
    }

    [Theory]
    [InlineData(SECOND_SAMPLE_INPUT, 1)]
    [InlineData(THIRD_SAMPLE_INPUT, 2)]
    [InlineData(FOURTH_SAMPLE_INPUT, 4)]
    [InlineData(FIFTH_SAMPLE_INPUT, 3)]
    public void CalculateTrailheadScoreCorrectly(string input, int expectedScore)
    {
        var sut = TopographicMap.ForScore(input);
        Assert.Equal(expectedScore, sut.Result);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = TopographicMap.ForScore(SAMPLE_INPUT);
        Assert.Equal(36, sut.Result);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = TopographicMap.ForScore(PUZZLE_INPUT);
        Assert.Equal(607, sut.Result);
    }

    [Theory]
    [InlineData(SIXTH_SAMPLE_INPUT, 3)]
    [InlineData(SEVENTH_SAMPLE_INPUT, 13)]
    [InlineData(EIGHTH_SAMPLE_INPUT, 227)]
    public void CalculateRatingCorrectly(string input, int expectedRating)
    {
        var sut = TopographicMap.ForRating(input);
        Assert.Equal(expectedRating, sut.Result);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = TopographicMap.ForRating(SAMPLE_INPUT);
        Assert.Equal(81, sut.Result);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = TopographicMap.ForRating(PUZZLE_INPUT);
        Assert.Equal(1384, sut.Result);
    }
}