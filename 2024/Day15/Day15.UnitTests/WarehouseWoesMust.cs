using System.Security.Cryptography;
using Day15.Logic;
using static Day15.UnitTests.Constants;

namespace Day15.UnitTests;

public class WarehouseWoesMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 10, 700)]
    [InlineData(PUZZLE_INPUT, 50, 20000)]
    public void LoadInputCorrectly(string input, int expectedSize, int expectedMoves)
    {
        var sut = new WarehouseWoes(input);
        Assert.Equal(expectedSize, sut.Size);
        Assert.Equal(expectedMoves, sut.Count);
    }

    [Fact]
    public void MoveRobotCorrectly_WhenFacingLeft()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#.@.#\n#...#\n#####\n\n<");
        sut.Execute();
        Assert.Equal((1, 2), sut.Position);
    }

    [Fact]
    public void MoveRobotCorrectly_WhenFacingUp()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#.@.#\n#...#\n#####\n\n^");
        sut.Execute();
        Assert.Equal((2, 1), sut.Position);
    }

    [Fact]
    public void MoveRobotCorrectly_WhenFacingRight()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#.@.#\n#...#\n#####\n\n>");
        sut.Execute();
        Assert.Equal((3, 2), sut.Position);
    }

    [Fact]
    public void MoveRobotCorrectly_WhenFacingDown()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#.@.#\n#...#\n#####\n\nV");
        sut.Execute();
        Assert.Equal((2, 3), sut.Position);
    }

    [Fact]
    public void StayInPosition_WhenWallBlocksLeft()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#@...#\n#...#\n#####\n\n<");
        sut.Execute();
        Assert.Equal((1, 2), sut.Position);
    }

    [Fact]
    public void StayInPosition_WhenWallBlocksUp()
    {
        var sut = new WarehouseWoes("#####\n#.@.#\n#...#\n#...#\n#####\n\n^");
        sut.Execute();
        Assert.Equal((2, 1), sut.Position);
    }

    [Fact]
    public void StayInPosition_WhenWallBlocksRight()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#..@#\n#...#\n#####\n\n>");
        sut.Execute();
        Assert.Equal((3, 2), sut.Position);
    }

    [Fact]
    public void SayInPosition_WhenWallBlocksDown()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#...#\n#.@.#\n#####\n\nV");
        sut.Execute();
        Assert.Equal((2, 3), sut.Position);
    }

    [Fact]
    public void PushBoxLeft_WhenHittingBoxWithFreeSpaceBehind()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#..O@#\n#...#\n#####\n\n<");
        sut.Execute();
        Assert.Equal((3, 2), sut.Position);
        Assert.Equal(202, sut.SumOfGpsCoordinates);
    }
}