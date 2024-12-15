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
        Assert.Equal(1, sut.RobotX);
        Assert.Equal(2, sut.RobotY);
    }

    [Fact]
    public void MoveRobotCorrectly_WhenFacingUp()
    {
        var sut = new WarehouseWoes("#####\n#...#\n#.@.#\n#...#\n#####\n\n^");
        sut.Execute();
        Assert.Equal(2, sut.RobotX);
        Assert.Equal(1, sut.RobotY);
    }

}