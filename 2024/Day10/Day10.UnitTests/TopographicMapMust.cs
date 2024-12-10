using System.Numerics;
using System.Security.Cryptography;
using Day10.Logic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Host;
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
        var sut = new TopographicMap(input);
        Assert.Equal(expectedSize, sut.Size);
    }

    [Fact]
    public void LocateTrailheadsCorrectly_WhenUsingSecondSample()
    {
        var sut = new TopographicMap(SECOND_SAMPLE_INPUT);
        Assert.Collection(sut.Trailheads, p1 => Assert.Equal((0, 0), p1));
    }

    [Theory]
    [InlineData(THIRD_SAMPLE_INPUT)]
    [InlineData(FOURTH_SAMPLE_INPUT)]
    public void LocateTrailheadsCorrectly_WhenUsingThirdOrFourthSample(string input)
    {
        var sut = new TopographicMap(input);
        Assert.Collection(sut.Trailheads, p1 => Assert.Equal((3, 0), p1));
    }

    [Fact]
    public void LocateTrailheadsCorrectly_WhenUsingFifthSample()
    {
        var sut = new TopographicMap(FIFTH_SAMPLE_INPUT);
        Assert.Collection(sut.Trailheads,
            p1 => Assert.Equal((1, 0), p1),
            p2 => Assert.Equal((5, 6), p2));
    }

    [Fact]
    public void LocateTrailheadsCorrectly_WhenUsingSampleMap()
    {
        var sut = new TopographicMap(SAMPLE_INPUT);
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
        var sut = new TopographicMap(input);
        Assert.Equal(expectedScore, sut.TrailheadScore);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new TopographicMap(SAMPLE_INPUT);
        Assert.Equal(36, sut.TrailheadScore);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new TopographicMap(PUZZLE_INPUT);
        Assert.Equal(607, sut.TrailheadScore);
    }
}