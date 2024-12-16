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
        Assert.Equal(expectedSize, sut.Height);
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
        var sut = new WarehouseWoes("#####\n#...#\n#.@.#\n#...#\n#####\n\nv");
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
    public void StayInPosition_WhenWallBlocksBoxLeft()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#O@.#\n#...#\n#####\n\n<");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(201, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void StayInPosition_WhenWallBlocksUp()
    {
        var sut = new WarehouseWoes("#####\n#.@.#\n#...#\n#...#\n#####\n\n^");
        sut.Execute();
        Assert.Equal((2, 1), sut.Position);
    }

    [Fact]
    public void StayInPosition_WhenWallBlocksBoxUp()
    {
        var sut = new WarehouseWoes("#####\n#.O.#\n#.@.#\n#...#\n#####\n\n^");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(102, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void StayInPosition_WhenWallBlocksRight()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#..@#\n#...#\n#####\n\n>");
        sut.Execute();
        Assert.Equal((3, 2), sut.Position);
    }

    [Fact]
    public void StayInPosition_WhenWallBlocksBoxRight()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#.@O#\n#...#\n#####\n\n>");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(203, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void SayInPosition_WhenWallBlocksDown()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#...#\n#.@.#\n#####\n\nv");
        sut.Execute();
        Assert.Equal((2, 3), sut.Position);
    }

    [Fact]
    public void SayInPosition_WhenWallBlocksBoxDown()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#.@.#\n#.O.#\n#####\n\nv");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(302, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxLeft_WhenHittingBoxWithFreeSpaceBehind()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#.O@#\n#...#\n#####\n\n<");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(201, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxLeft_WhenHittingBoxWithBoxAndFreeSpaceBehind()
    {
        var sut = new WarehouseWoes("######\n#....#\n#.OO@#\n#....#\n#....#\n######\n\n<");
        sut.Execute();
        Assert.Equal((3, 2), sut.Position);
        Assert.Equal(403, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxRight_WhenHittingBoxWithFreeSpaceBehind()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#@O.#\n#...#\n#####\n\n>");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(203, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxRight_WhenHittingBoxWithBoxAndFreeSpaceBehind()
    {
        var sut = new WarehouseWoes("######\n#....#\n#@OO.#\n#....#\n#....#\n######\n\n>");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(407, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxUp_WhenHittingBoxWithFreeSpaceBehind()
    {
        var sut = new WarehouseWoes("######\n#....#\n#....#\n#.O..#\n#.@..#\n######\n\n^");
        sut.Execute();
        Assert.Equal((2, 3), sut.Position);
        Assert.Equal(202, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxUp_WhenHittingBoxWithBoxAndFreeSpaceBehind()
    {
        var sut = new WarehouseWoes("######\n#....#\n#.O..#\n#.O..#\n#.@..#\n######\n\n^");
        sut.Execute();
        Assert.Equal((2, 3), sut.Position);
        Assert.Equal(304, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxDown_WhenHittingBoxWithFreeSpaceBehind()
    {
        var sut = new WarehouseWoes("######\n#.@..#\n#.O..#\n#....#\n#....#\n######\n\nv");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(302, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxDown_WhenHittingBoxWithBoxAndFreeSpaceBehind()
    {
        var sut = new WarehouseWoes("######\n#.@..#\n#.O..#\n#.O..#\n#....#\n######\n\nv");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(704, sut.SumOfGpsCoordinates);
    }

    [Theory]
    [InlineData("<", 2, 2, 103+105+204+304+404+504)]
    [InlineData("<^", 2, 1, 103+105+204+304+404+504)]
    [InlineData("<^^", 2, 1, 103+105+204+304+404+504)]
    [InlineData("<^^>", 3, 1, 104+105+204+304+404+504)]
    [InlineData("<^^>>", 4, 1, 105+106+204+304+404+504)]
    [InlineData("<^^>>>", 4, 1, 105+106+204+304+404+504)]
    [InlineData("<^^>>>v", 4, 2, 105+106+304+404+504+604)]
    [InlineData("<^^>>>vv", 4, 2, 105+106+304+404+504+604)]
    [InlineData("<^^>>>v<", 3, 2, 105+106+304+404+504+604)]
    [InlineData("<^^>>>v<v", 3, 3, 105+106+304+404+504+604)]
    [InlineData("<^^>>>v<v>", 4, 3, 105+106+305+404+504+604)]
    [InlineData("<^^>>>v<v>>", 5, 3, 105+106+306+404+504+604)]
    [InlineData("<^^>>>v<v>>v", 5, 4, 105+106+306+404+504+604)]
    [InlineData("<^^>>>v<v>>v<", 4, 4, 105+106+306+403+504+604)]
    [InlineData("<^^>>>v<v>>v<<", 4, 4, 105+106+306+403+504+604)]
    public void ExecuteOneStepInSmallSimulationCorrectly(string movements, int expectedX, int expectedY, int expectedSum)
    {
        var sut = new WarehouseWoes(@$"########
#..O.O.#
##@.O..#
#...O..#
#.#.O..#
#...O..#
#......#
########

{movements}");
        sut.Execute();
        Assert.Equal((expectedX, expectedY), sut.Position);
        Assert.Equal(expectedSum, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void RunSimulationCorrectly()
    {
        var sut = new WarehouseWoes(SECOND_SAMPLE_INPUT);
        sut.Execute();
        Assert.Equal(2028, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new WarehouseWoes(SAMPLE_INPUT);
        sut.Execute();
        Assert.Equal(10092, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new WarehouseWoes(PUZZLE_INPUT);
        sut.Execute();
        Assert.Equal(1421727, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void GenerateWideMapCorrectly()
    {
        var sut = new WarehouseWoes(SAMPLE_INPUT, true);
        sut.CalculateSumOfGpsCoordinates();
        Assert.Equal((8, 4), sut.Position);
        Assert.Equal(106+112+116+214+304+306+312+316+406+414+502+510+602+608+614+704+706+710+714+716+810, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void MoveBigBoxLeftCorrectly()
    {
        var sut = new WarehouseWoes("#####\n#..O@#\n#####\n\n<", true);
        sut.Execute();
        Assert.Equal((7, 1), sut.Position);
        Assert.Equal(105, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void MoveBigBoxesLeftCorrectly_WhenThereIsRoomAvailable()
    {
        var sut = new  WarehouseWoes("#####\n#.OO@#\n#####\n\n<", true);
        sut.Execute();
        Assert.Equal((7, 1), sut.Position);
        Assert.Equal(208, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void MoveRightCorrectly()
    {
        var sut = new WarehouseWoes("#####\n#@O.#\n#####\n\n>", true);
        sut.Execute();
        Assert.Equal((3, 1), sut.Position);
        Assert.Equal(104, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void MoveBoxRightCorrectly()
    {
        var sut = new WarehouseWoes("#####\n#@O.#\n#####\n\n>>", true);
        sut.Execute();
        Assert.Equal((4, 1), sut.Position);
        Assert.Equal(105, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void MoveBigBoxesRightCorrectly_WhenThereIsRoomAvailable()
    {
        var sut = new WarehouseWoes("#####\n#.OO@#\n#####\n\n<", true);
        sut.Execute();
        Assert.Equal((7, 1), sut.Position);
        Assert.Equal(208, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void MoveBoxUp_WhenThereIsFreeRoom()
    {
        /*
            ##########
            ##......##
            ##..[]..##
            ##..@...##
            ##########
        */
        var sut = new WarehouseWoes("#####\n#...#\n#.O.#\n#.@.#\n#####\n\n^", true);
        sut.Execute();
        Assert.Equal((4, 2), sut.Position);
        Assert.Equal(104, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void MoveBoxUp_WhenThereIsFreeRoomAfterABox()
    {
        /*
            ##########
            ##......##
            ##..[]..##
            ##..[]..##
            ##..@...##
            ##########
        */
        var sut = new WarehouseWoes("#####\n#...#\n#.O.#\n#.O.#\n#.@.#\n#####\n\n^", true);
        sut.Execute();
        Assert.Equal((4, 3), sut.Position);
        Assert.Equal(104+204, sut.SumOfGpsCoordinates);
    }

}