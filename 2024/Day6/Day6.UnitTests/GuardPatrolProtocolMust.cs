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
}