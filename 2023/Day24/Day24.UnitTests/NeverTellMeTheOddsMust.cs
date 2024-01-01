using System.Security.Cryptography;
using Day24.Logic;
using static Day24.UnitTests.Constants;

namespace Day24.UnitTests;

public class NeverTellMeTheOddsMust
{
/*    [Theory]
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
            h1 => Assert.Equal(((19, 13, 30), (-2,  1, -2)), h1.Data),
            h2 => Assert.Equal(((18, 19, 22), (-1, -1, -2)), h2.Data),
            h3 => Assert.Equal(((20, 25, 34), (-2, -2, -4)), h3.Data),
            h4 => Assert.Equal(((12, 31, 28), (-1, -2, -1)), h4.Data),
            h5 => Assert.Equal(((20, 19, 15), ( 1, -5, -3)), h5.Data));
    }

    [Fact]
    public void CalculateIntersectionCorrectly_WhenVelocitiesIn2dAreParallel()
    {
        var sut = new NeverTellMeTheOdds("18, 19, 22 @ -1, -1, -2\n20, 25, 34 @ -2, -2, -4");
        sut.IntersectBetween(7, 27);
        Assert.Equal(0, sut.Intersections);
    }

    [Fact]
    public void CalculateIntersectionCorrectly_WhenRoutesCollideInsideWindow()
    {
        var sut = new NeverTellMeTheOdds("19, 13, 30 @ -2, 1, -2\n18, 19, 22 @ -1, -1, -2");
        sut.IntersectBetween(7, 27);
        Assert.Equal(1, sut.Intersections);
    }

    [Fact]
    public void CalculateIntersectionCorrectly_WhenRoutesCollideAfterWindow()
    {
        var sut = new NeverTellMeTheOdds("19, 13, 30 @ -2, 1, -2\n12, 31, 28 @ -1, -2, -1");
        sut.IntersectBetween(7, 27);
        Assert.Equal(0, sut.Intersections);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new NeverTellMeTheOdds(SAMPLE_INPUT);
        sut.IntersectBetween(7, 27);
        Assert.Equal(2, sut.Intersections);
    }
*/
    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new NeverTellMeTheOdds(PUZZLE_INPUT);
        sut.IntersectBetween(200_000_000_000_000, 400_000_000_000_000);
        Assert.True(14364 < sut.Intersections);
        Assert.True(16031 < sut.Intersections);
        Assert.True(16518 < sut.Intersections);
        Assert.True(19548 > sut.Intersections);
        Assert.True(16724 < sut.Intersections);
        Assert.Equal(16727, sut.Intersections);
    }
}