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
        var sut = WarehouseWoes.Create(input);
        Assert.Equal(expectedSize, sut.Height);
        Assert.Equal(expectedMoves, sut.Count);
    }

    [Fact]
    public void MoveRobotCorrectly_WhenFacingLeft()
    {
        var sut = WarehouseWoes.Create("#####\n#...#\n#.@.#\n#...#\n#####\n\n<");
        sut.Execute();
        Assert.Equal((1, 2), sut.Position);
    }

    [Fact]
    public void MoveRobotCorrectly_WhenFacingUp()
    {
        var sut = WarehouseWoes.Create("#####\n#...#\n#.@.#\n#...#\n#####\n\n^");
        sut.Execute();
        Assert.Equal((2, 1), sut.Position);
    }

    [Fact]
    public void MoveRobotCorrectly_WhenFacingRight()
    {
        var sut = WarehouseWoes.Create("#####\n#...#\n#.@.#\n#...#\n#####\n\n>");
        sut.Execute();
        Assert.Equal((3, 2), sut.Position);
    }

    [Fact]
    public void MoveRobotCorrectly_WhenFacingDown()
    {
        var sut = WarehouseWoes.Create("#####\n#...#\n#.@.#\n#...#\n#####\n\nv");
        sut.Execute();
        Assert.Equal((2, 3), sut.Position);
    }

    [Fact]
    public void StayInPosition_WhenWallBlocksLeft()
    {
        var sut = WarehouseWoes.Create("#####\n#...#\n#@...#\n#...#\n#####\n\n<");
        sut.Execute();
        Assert.Equal((1, 2), sut.Position);
    }

    [Fact]
    public void StayInPosition_WhenWallBlocksBoxLeft()
    {
        var sut = WarehouseWoes.Create("#####\n#...#\n#O@.#\n#...#\n#####\n\n<");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(201, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void StayInPosition_WhenWallBlocksUp()
    {
        var sut = WarehouseWoes.Create("#####\n#.@.#\n#...#\n#...#\n#####\n\n^");
        sut.Execute();
        Assert.Equal((2, 1), sut.Position);
    }

    [Fact]
    public void StayInPosition_WhenWallBlocksBoxUp()
    {
        var sut = WarehouseWoes.Create("#####\n#.O.#\n#.@.#\n#...#\n#####\n\n^");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(102, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void StayInPosition_WhenWallBlocksRight()
    {
        var sut = WarehouseWoes.Create("#####\n#...#\n#..@#\n#...#\n#####\n\n>");
        sut.Execute();
        Assert.Equal((3, 2), sut.Position);
    }

    [Fact]
    public void StayInPosition_WhenWallBlocksBoxRight()
    {
        var sut = WarehouseWoes.Create("#####\n#...#\n#.@O#\n#...#\n#####\n\n>");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(203, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void SayInPosition_WhenWallBlocksDown()
    {
        var sut = WarehouseWoes.Create("#####\n#...#\n#...#\n#.@.#\n#####\n\nv");
        sut.Execute();
        Assert.Equal((2, 3), sut.Position);
    }

    [Fact]
    public void SayInPosition_WhenWallBlocksBoxDown()
    {
        var sut = WarehouseWoes.Create("#####\n#...#\n#.@.#\n#.O.#\n#####\n\nv");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(302, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxLeft_WhenHittingBoxWithFreeSpaceBehind()
    {
        var sut = WarehouseWoes.Create("#####\n#...#\n#.O@#\n#...#\n#####\n\n<");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(201, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxLeft_WhenHittingBoxWithBoxAndFreeSpaceBehind()
    {
        var sut = WarehouseWoes.Create("######\n#....#\n#.OO@#\n#....#\n#....#\n######\n\n<");
        sut.Execute();
        Assert.Equal((3, 2), sut.Position);
        Assert.Equal(403, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxRight_WhenHittingBoxWithFreeSpaceBehind()
    {
        var sut = WarehouseWoes.Create("#####\n#...#\n#@O.#\n#...#\n#####\n\n>");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(203, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxRight_WhenHittingBoxWithBoxAndFreeSpaceBehind()
    {
        var sut = WarehouseWoes.Create("######\n#....#\n#@OO.#\n#....#\n#....#\n######\n\n>");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(407, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxUp_WhenHittingBoxWithFreeSpaceBehind()
    {
        var sut = WarehouseWoes.Create("######\n#....#\n#....#\n#.O..#\n#.@..#\n######\n\n^");
        sut.Execute();
        Assert.Equal((2, 3), sut.Position);
        Assert.Equal(202, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxUp_WhenHittingBoxWithBoxAndFreeSpaceBehind()
    {
        var sut = WarehouseWoes.Create("######\n#....#\n#.O..#\n#.O..#\n#.@..#\n######\n\n^");
        sut.Execute();
        Assert.Equal((2, 3), sut.Position);
        Assert.Equal(304, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxDown_WhenHittingBoxWithFreeSpaceBehind()
    {
        var sut = WarehouseWoes.Create("######\n#.@..#\n#.O..#\n#....#\n#....#\n######\n\nv");
        sut.Execute();
        Assert.Equal((2, 2), sut.Position);
        Assert.Equal(302, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void PushBoxDown_WhenHittingBoxWithBoxAndFreeSpaceBehind()
    {
        var sut = WarehouseWoes.Create("######\n#.@..#\n#.O..#\n#.O..#\n#....#\n######\n\nv");
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
        var sut = WarehouseWoes.Create(@$"########
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
        var sut = WarehouseWoes.Create(SECOND_SAMPLE_INPUT);
        sut.Execute();
        Assert.Equal(2028, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = WarehouseWoes.Create(SAMPLE_INPUT);
        sut.Execute();
        Assert.Equal(10092, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = WarehouseWoes.Create(PUZZLE_INPUT);
        sut.Execute();
        Assert.Equal(1421727, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void GenerateWideMapCorrectly()
    {
        var sut = WarehouseWoes.CreateWiderMap(SAMPLE_INPUT);
        sut.CalculateSumOfGpsCoordinates();
        Assert.Equal((8, 4), sut.Position);
        Assert.Equal(106+112+116+214+304+306+312+316+406+414+502+510+602+608+614+704+706+710+714+716+810, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void MoveBigBoxLeftCorrectly()
    {
        var sut = WarehouseWoes.CreateWiderMap("#####\n#..O@#\n#####\n\n<");
        sut.Execute();
        Assert.Equal((7, 1), sut.Position);
        Assert.Equal(105, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void MoveBigBoxesLeftCorrectly_WhenThereIsRoomAvailable()
    {
        var sut = WarehouseWoes.CreateWiderMap("#####\n#.OO@#\n#####\n\n<");
        sut.Execute();
        Assert.Equal((7, 1), sut.Position);
        Assert.Equal(208, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void MoveRightCorrectly()
    {
        var sut = WarehouseWoes.CreateWiderMap("#####\n#@O.#\n#####\n\n>");
        sut.Execute();
        Assert.Equal((3, 1), sut.Position);
        Assert.Equal(104, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void MoveBoxRightCorrectly()
    {
        var sut = WarehouseWoes.CreateWiderMap("#####\n#@O.#\n#####\n\n>>");
        sut.Execute();
        Assert.Equal((4, 1), sut.Position);
        Assert.Equal(105, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void MoveBigBoxesRightCorrectly_WhenThereIsRoomAvailable()
    {
        var sut = WarehouseWoes.CreateWiderMap("#####\n#.OO@#\n#####\n\n<");
        sut.Execute();
        Assert.Equal((7, 1), sut.Position);
        Assert.Equal(208, sut.SumOfGpsCoordinates);
    }

    [Theory]
    [InlineData("#####\n#...#\n#.O.#\n#.@.#\n#####\n\n^", 4)]
    [InlineData("#####\n#...#\n#.O@#\n#...#\n#####\n\nv<^", 5)]
    public void MoveBoxUp_WhenThereIsFreeRoom(string input, int expectedX)
    {
        /*
            ##########   ##########
            ##......##   ##......##
            ##..[]..##   ##..[]@.##
            ##..@...##   ##......##
            ##########   ##########
        */
        var sut = WarehouseWoes.CreateWiderMap(input);
        sut.Execute();
        Assert.Equal((expectedX, 2), sut.Position);
        Assert.Equal(104, sut.SumOfGpsCoordinates);
    }

    [Theory]
    [InlineData("#####\n#...#\n#.O.#\n#.O.#\n#.@.#\n#####\n\n^", 4)]
    [InlineData("#####\n#...#\n#.O.#\n#.O@#\n#...#\n#####\n\nv<^", 5)]
    public void MoveBoxUp_WhenThereIsFreeRoomAfterABox(string input, int expectedX)
    {
        /*
            ##########   ##########
            ##......##   ##......##
            ##..[]..##   ##..[]..##
            ##..[]..##   ##..[]@.##
            ##..@...##   ##......##
            ##########   ##########
        */
        var sut = WarehouseWoes.CreateWiderMap(input);
        sut.Execute();
        Assert.Equal((expectedX, 3), sut.Position);
        Assert.Equal(104+204, sut.SumOfGpsCoordinates);
    }

    [Theory]
    [InlineData("#####\n#.O.#\n#.O.#\n#.@.#\n#####\n\n^", 4)]
    [InlineData("#####\n#.O.#\n#.O@#\n#...#\n#####\n\nv<^", 5)]
    public void DoNotMoveBoxUp_WhenThereIsAWall(string input, int expectedX)
    {
        /*
            ##########   ##########
            ##..[]..##   ##..[]..##
            ##..[]..##   ##..[]@.##
            ##..@...##   ##......##
            ##########   ##########
        */
        var sut = WarehouseWoes.CreateWiderMap(input);
        sut.Execute();
        Assert.Equal((expectedX, 3), sut.Position);
        Assert.Equal(104+204, sut.SumOfGpsCoordinates);
    }

    [Theory]
    [InlineData("#####\n#.O.#\n#.O@#\n#...#\n#####\n\n<v<^", 4, 104+203)]
    [InlineData("#####\n#.O.#\n#@O.#\n#...#\n#####\n\n>>v>^", 5, 104+205)]
    public void DoNotMoveBoxUp_WhenThereIsAWallOnOneSide(string input, int expectedX, int expectedResult)
    {
        /*
            ##########   ##########
            ##..[]..##   ##..[]..##
            ##..[]@.##   ##@.[]..##
            ##......##   ##......##
            ##########   ##########
        */

        var sut = WarehouseWoes.CreateWiderMap(input);
        sut.Execute();
        Assert.Equal((expectedX, 3), sut.Position);
        Assert.Equal(expectedResult, sut.SumOfGpsCoordinates);
    }

    [Theory]
    [InlineData("#####\n##..#\n#OO.#\n#.O@#\n#...#\n#####\n\n<v<^")]
    [InlineData("#####\n#.#.#\n#OO.#\n#.O@#\n#...#\n#####\n\n<v<^")]
    public void DoNotMoveBoxUp_WhenLeftUpperBoxIsBlocked(string input)
    {
        /*
            ##########   ##########
            ####....##   ##..##..##
            ##[][]..##   ##[][]..##
            ##..[]@.##   ##..[]@.##
            ##......##   ##......##
            ##########   ##########
        */
        var sut = WarehouseWoes.CreateWiderMap(input);
        sut.Execute();
        Assert.Equal((4, 4), sut.Position);
        Assert.Equal(202+204+303, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void MoveBoxUp_WhenThereIsFreeRoomAfterBoxes()
    {
        /*
            ##########
            ##......##
            ##[][]..##
            ##..[]@.##
            ##......##
            ##########
        */
        var sut = WarehouseWoes.CreateWiderMap("#####\n#...#\n#OO.#\n#.O@#\n#...#\n#####\n\n<v<^");
        sut.Execute();
        Assert.Equal((4, 3), sut.Position);
        Assert.Equal(102+104+203, sut.SumOfGpsCoordinates);
    }

    [Theory]
    [InlineData("#####\n#.@.#\n#.O.#\n#...#\n#####\n\nv", 4)]
    [InlineData("#####\n#...#\n#.O@#\n#...#\n#####\n\n^<v", 5)]
    public void MoveBoxDown_WhenThereIsFreeRoom(string input, int expectedX)
    {
        /*
            ##########   ##########
            ##..@...##   ##......##
            ##..[]..##   ##..[]@.##
            ##......##   ##......##
            ##########   ##########
        */
        var sut = WarehouseWoes.CreateWiderMap(input);
        sut.Execute();
        Assert.Equal((expectedX, 2), sut.Position);
        Assert.Equal(304, sut.SumOfGpsCoordinates);
    }

    [Theory]
    [InlineData("#####\n#.@.#\n#.O.#\n#.O.#\n#...#\n#####\n\nv", 4)]
    [InlineData("#####\n#...#\n#.O@#\n#.O.#\n#...#\n#####\n\n^<v", 5)]
    public void MoveBoxDown_WhenThereIsFreeRoomAfterABox(string input, int expectedX)
    {
        /*
            ##########   ##########
            ##..@...##   ##......##
            ##..[]..##   ##..[]@.##
            ##..[]..##   ##..[]..##
            ##......##   ##......##
            ##########   ##########
        */
        var sut = WarehouseWoes.CreateWiderMap(input);
        sut.Execute();
        Assert.Equal((expectedX, 2), sut.Position);
        Assert.Equal(304+404, sut.SumOfGpsCoordinates);
    }

    [Theory]
    [InlineData("#####\n#.@.#\n#.O.#\n#.O.#\n#####\n\nv", 4)]
    [InlineData("#####\n#...#\n#.O@#\n#.O.#\n#####\n\n^<v", 5)]
    public void DoNotMoveBoxDown_WhenThereIsAWall(string input, int expectedX)
    {
        /*
            ##########   ##########
            ##..@...##   ##......##
            ##..[]..##   ##..[]@.##
            ##..[]..##   ##..[]..##
            ##########   ##########
        */
        var sut = WarehouseWoes.CreateWiderMap(input);
        sut.Execute();
        Assert.Equal((expectedX, 1), sut.Position);
        Assert.Equal(204+304, sut.SumOfGpsCoordinates);
    }

    [Theory]
    [InlineData("#####\n#...#\n#.O@#\n#.O.#\n#####\n\n<^<v", 4, 203+304)]
    [InlineData("#####\n#...#\n#@O.#\n#.O.#\n#####\n\n>>^>v", 5, 205+304)]
    public void DoNotMoveBoxDown_WhenThereIsAWallOnOneSide(string input, int expectedX, int expectedResult)
    {
        /*
            ##########   ##########
            ##......##   ##......##
            ##..[]@.##   ##@.[]..##
            ##..[]..##   ##..[]..##
            ##########   ##########
        */

        var sut = WarehouseWoes.CreateWiderMap(input);
        sut.Execute();
        Assert.Equal((expectedX, 1), sut.Position);
        Assert.Equal(expectedResult, sut.SumOfGpsCoordinates);
    }

    [Theory]
    [InlineData("#####\n#...#\n#.O@#\n#OO.#\n##..#\n#####\n\n<^<v")]
    [InlineData("#####\n#...#\n#.O@#\n#OO.#\n#.#.#\n#####\n\n<^<v")]
    public void DoNotMoveBoxDown_WhenBottomLeftBoxIsBlocked(string input)
    {
        /*
            ##########   ##########
            ##......##   ##......##
            ##..[]@.##   ##..[]@.##
            ##[][]..##   ##[][]..##
            ####....##   ##..##..##
            ##########   ##########
        */
        var sut = WarehouseWoes.CreateWiderMap(input);
        sut.Execute();
        Assert.Equal((4, 1), sut.Position);
        Assert.Equal(203+302+304, sut.SumOfGpsCoordinates);
    }

    [Theory]
    [InlineData("#####\n#...#\n#.O@#\n#OO.#\n#...#\n#####\n\n<^<v", 4)]
    [InlineData("#####\n#...#\n#.O@#\n#OO.#\n#...#\n#####\n\n<^<<v", 3)]
    public void MoveBoxDown_WhenThereIsFreeRoomAfterBoxes(string input, int expectedX)
    {
        /*
            ##########   ##########
            ##......##   ##......##
            ##..[]@.##   ##..[]@.##
            ##[][]..##   ##[][]..##
            ##......##   ##......##
            ##########   ##########
        */
        var sut = WarehouseWoes.CreateWiderMap(input);
        sut.Execute();
        Assert.Equal((expectedX, 2), sut.Position);
        Assert.Equal(303+402+404, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void SolveSecondMiniSampleCorrectly()
    {
        var sut = WarehouseWoes.CreateWiderMap(@"#######
#...#.#
#.....#
#..OO@#
#..O..#
#.....#
#######

<vv<<^^<<^^");
        sut.Execute();
        Assert.Equal((5, 2), sut.Position);
        Assert.Equal(105+207+306, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void MoveDown_WhenBoxesHaveRoomAndAreStackedRight()
    {
        /*
            ##########
            ##......##
            ##@.[]..##
            ##....[]##
            ##......##
            ##########
        */
        var sut = WarehouseWoes.CreateWiderMap("#####\n#...#\n#@O.#\n#..O#\n#...#\n######\n\n>>^>v");
        sut.Execute();
        Assert.Equal((5, 2), sut.Position);
        Assert.Equal(305+406, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = WarehouseWoes.CreateWiderMap(SAMPLE_INPUT);
        sut.Execute();
        Assert.Equal(9021, sut.SumOfGpsCoordinates);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = WarehouseWoes.CreateWiderMap(PUZZLE_INPUT);
        sut.Execute();
        Assert.Equal(1463160, sut.SumOfGpsCoordinates);
    }
}