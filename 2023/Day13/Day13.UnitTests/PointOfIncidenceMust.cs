using System.Drawing;
using Day13.Logic;
using static Day13.UnitTests.Constants;

namespace Day13.UnitTests;

public class PointOfIncidenceMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 2)]
    [InlineData(PUZZLE_INPUT, 100)]
    public void LoadInputCorrectly(string input, int expectedMaps)
    {
        var sut = new PointOfIncidence(input);
        Assert.Equal(expectedMaps, sut.MapCount);
    }

    [Fact]
    public void FindVerticalMirroringCorrectly()
    {
        var sut = new PointOfIncidence(@"#.##..##.
..#.##.#.
##......#
##......#
..#.##.#.
..##..##.
#.#.##.#.");
        Assert.Equal(5, sut.PatternSummary);
    }

    [Fact]
    public void FindHorizontalMirroringCorrectly()
    {
        var sut = new PointOfIncidence(@"#...##..#
#....#..#
..##..###
#####.##.
#####.##.
..##..###
#....#..#");
        Assert.Equal(400, sut.PatternSummary);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new PointOfIncidence(SAMPLE_INPUT);
        Assert.Equal(405, sut.PatternSummary);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new PointOfIncidence(PUZZLE_INPUT);
        Assert.Equal(33047, sut.PatternSummary);
    }

    [Fact]
    public void FixHorizontalSmudgeCorrectly()
    {
        var sut = new PointOfIncidence(@"#.##..##.
..#.##.#.
##......#
##......#
..#.##.#.
..##..##.
#.#.##.#.", true);
        Assert.Equal(300, sut.PatternSummary);
    }
}