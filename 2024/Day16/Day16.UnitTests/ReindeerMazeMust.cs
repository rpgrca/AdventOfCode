using Day16.Logic;
using static Day16.UnitTests.Constants;

namespace Day16.UnitTests;

public class ReindeerMazeMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 15)]
    [InlineData(SECOND_SAMPLE_INPUT, 17)]
    [InlineData(PUZZLE_INPUT, 141)]
    public void LoadInputCorrectly(string input, int expectedSize)
    {
        var sut = new ReindeerMaze(input);
        Assert.Equal(expectedSize, sut.Size);
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 1, 13)]
    [InlineData(SECOND_SAMPLE_INPUT, 1, 15)]
    [InlineData(PUZZLE_INPUT, 1, 139)]
    public void LocateStartPointCorrectly(string input, int expectedX, int expectedY)
    {
        var sut = new ReindeerMaze(input);
        Assert.Equal((expectedX, expectedY), sut.StartPoint);
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 13, 1)]
    [InlineData(SECOND_SAMPLE_INPUT, 15, 1)]
    [InlineData(PUZZLE_INPUT, 139, 1)]
    public void LocateEndPointCorrectly(string input, int expectedX, int expectedY)
    {
        var sut = new ReindeerMaze(input);
        Assert.Equal((expectedX, expectedY), sut.EndPoint);
    }

    [Theory]
    [InlineData("#####\n#####\n#####\n#S.E#\n#####", 2)]
    [InlineData("######\n######\n######\n######\n#S..E#\n######", 3)]
    public void MoveEastCorrectly(string input, int expectedScore)
    {
        var sut = new ReindeerMaze(input);
        sut.Run();
        Assert.Equal(expectedScore, sut.LowestScore);
    }

    [Fact]
    public void MoveNorthCorrectly()
    {
        var sut = new ReindeerMaze("#####\n#..E#\n#..S#\n#...#\n#####");
        sut.Run();
        Assert.Equal(1001, sut.LowestScore);
    }

    [Fact]
    public void MoveWestCorrectly()
    {
        var sut = new ReindeerMaze("#####\n#E.S#\n#...#\n#...#\n#####");
        sut.Run();
        Assert.Equal(2002, sut.LowestScore);
    }

    [Fact]
    public void MoveSouthCorrectly()
    {
        var sut = new ReindeerMaze("#####\n#.S.#\n#...#\n#.E.#\n#####");
        sut.Run();
        Assert.Equal(1002, sut.LowestScore);
    }

    [Theory]
    [InlineData("########\n#.....E#\n#.###.##\n#.###.##\n#.###..#\n#.####.#\n#S.....#\n########", 2010)]
    [InlineData("########\n#.....E#\n#####.##\n#.###.##\n#.###..#\n#.####.#\n#S.....#\n########", 4012)]
    public void ChooseBestPathCorrectly_WhenTurningEastAndNorth(string input, int expectedScore)
    {
        var sut = new ReindeerMaze(input);
        sut.Run();
        Assert.Equal(expectedScore, sut.LowestScore);
    }
}