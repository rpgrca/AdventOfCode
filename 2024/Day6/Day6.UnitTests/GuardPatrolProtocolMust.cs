using System.Diagnostics;
using Day6.Logic;
using static Day6.UnitTests.Constants;

namespace Day6.UnitTests;

public class GuardPatrolProtocolMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 10)]
    [InlineData(PUZZLE_INPUT, 130)]
    public void LoadInputCorrectly(string input, int expectedLength)
    {
        var sut = new GuardPatrolProtocol(input);
        Assert.Equal(expectedLength, sut.Length);
    }

    [Fact]
    public void CalculateUpMovementCorrectly()
    {
        const string input = @"..........
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...";
        var sut = new GuardPatrolProtocol(input);
        Assert.Equal(7, sut.DistinctVisitedPositions);
    }

    [Fact]
    public void CalculateRightMovementCorrectly()
    {
        const string input = @"....#.....
..........
..........
..#.......
.......#..
..........
.#..^.....
........#.
#.........
......#...";

        var sut = new GuardPatrolProtocol(input);
        Assert.Equal(11, sut.DistinctVisitedPositions);
    }

    [Fact]
    public void CalculateDownMovementCorrectly()
    {
        const string input = @"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
..........
#.........
......#...";

        var sut = new GuardPatrolProtocol(input);
        Assert.Equal(18, sut.DistinctVisitedPositions);
    }

    [Fact]
    public void CalculateLeftMovementCorrectly()
    {
        const string input = @"....#.....
.........#
..........
..#.......
.......#..
..........
....^.....
........#.
#.........
......#...";

        var sut = new GuardPatrolProtocol(input);
        Assert.Equal(22, sut.DistinctVisitedPositions);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new GuardPatrolProtocol(SAMPLE_INPUT);
        Assert.Equal(41, sut.DistinctVisitedPositions);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new GuardPatrolProtocol(PUZZLE_INPUT);
        Assert.Equal(5162, sut.DistinctVisitedPositions);
    }

    [Fact]
    public void CountOnePossibleObstructionCorrectly()
    {
        const string input = @"....#.....
.........#
..........
..........
..........
..........
....^.....
........#.
..........
..........";
        var sut = new GuardPatrolProtocol(input, true);
        Assert.Equal(1, sut.PossibleObstructions);
    }

    [Fact]
    public void CountTwoPossibleObstructionsCorrectly()
    {
        const string input = @"....#.....
.........#
..........
..#.......
.......#..
..........
.#..^.....
........#.
..........
..........";

        var sut = new GuardPatrolProtocol(input, true);
        Assert.Equal(2, sut.PossibleObstructions);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new GuardPatrolProtocol(SAMPLE_INPUT, true);
        Assert.Equal(6, sut.PossibleObstructions);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = new GuardPatrolProtocol(PUZZLE_INPUT, true);
        Assert.Equal(1909, sut.PossibleObstructions);
    }

    // For mutation test
    [Fact]
    public void ThrowException_WhenMapDoesNotHaveInitialPoint()
    {
        const string input = "..\r..";
        Assert.Throws<UnreachableException>(() => new GuardPatrolProtocol(input));
    }
}