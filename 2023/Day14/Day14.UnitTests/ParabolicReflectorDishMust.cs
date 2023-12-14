using System.Numerics;
using System.Security.Cryptography;
using Day14.Logic;
using static Day14.UnitTests.Constants;

namespace Day14.UnitTests;

public class ParabolicReflectorDishMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 10, 10)]
    [InlineData(PUZZLE_INPUT, 100, 100)]
    public void LoadInputCorrectly(string input, int expectedWidth, int expectedHeight)
    {
        var sut = new ParabolicReflectorDish(input);
        Assert.Equal(expectedWidth, sut.Width);
        Assert.Equal(expectedHeight, sut.Height);
    }

    [Theory]
    [InlineData("#", '#')]
    [InlineData("O", 'O')]
    [InlineData(".", '.')]
    public void DoNotMoveCubeRocks_WhenMapHasOneCubeRock(string input, char expectedFirst)
    {
        var sut = new ParabolicReflectorDish(input);
        sut.TiltNorth();
        Assert.Collection(sut.CurrentMap,
            m1 => Assert.Collection(m1,
                c1 => Assert.Equal(expectedFirst, c1)));
    }

    [Theory]
    [InlineData("#\n.", '#', '.')]
    [InlineData("#\nO", '#', 'O')]
    [InlineData("#\n#", '#', '#')]
    [InlineData("O\n#", 'O', '#')]
    [InlineData(".\n#", '.', '#')]
    public void DoNotMoveCubeRocks_WhenColumnHasOneCubeRock(string input, char expectedFirst, char expectedSecond)
    {
        var sut = new ParabolicReflectorDish(input);
        sut.TiltNorth();
        Assert.Collection(sut.CurrentMap,
            m1 => Assert.Collection(m1, c1 => Assert.Equal(expectedFirst, c1)),
            m2 => Assert.Collection(m2, c2 => Assert.Equal(expectedSecond, c2)));
    }

    [Fact]
    public void MoveRoundRocks_WhenColumnHasNoBlockUntilEdge()
    {
        var sut = new ParabolicReflectorDish(".\nO");
        sut.TiltNorth();
        Assert.Collection(sut.CurrentMap,
            m1 => Assert.Collection(m1, c1 => Assert.Equal('O', c1)),
            m2 => Assert.Collection(m2, c2 => Assert.Equal('.', c2)));
    }

    [Fact]
    public void MoveRoundRocks_WhenColumnHasRoomToMove()
    {
        var sut = new ParabolicReflectorDish("..\n.O\nO.");
        sut.TiltNorth();
        Assert.Collection(sut.CurrentMap,
            m1 => Assert.Collection(m1,
                c1 => Assert.Equal('O', c1),
                c2 => Assert.Equal('O', c2)),
            m2 => Assert.Collection(m2,
                c1 => Assert.Equal('.', c1),
                c2 => Assert.Equal('.', c2)),
            m3 => Assert.Collection(m3,
                c1 => Assert.Equal('.', c1),
                c2 => Assert.Equal('.', c2)));
    }

    [Fact]
    public void BlockRoundedRock_WhenHittingCubeRock()
    {
        var sut = new ParabolicReflectorDish(".#\n..\nOO");
        sut.TiltNorth();
        Assert.Collection(sut.CurrentMap,
            m1 => Assert.Collection(m1,
                c1 => Assert.Equal('O', c1),
                c2 => Assert.Equal('#', c2)),
            m2 => Assert.Collection(m2,
                c1 => Assert.Equal('.', c1),
                c2 => Assert.Equal('O', c2)),
            m3 => Assert.Collection(m3,
                c1 => Assert.Equal('.', c1),
                c2 => Assert.Equal('.', c2)));
    }

    [Fact]
    public void RollRoundedRock_WhenColumnHasMultipleGaps()
    {
        var sut = new ParabolicReflectorDish("..\n..\nO#\n..\n..\nOO");
        sut.TiltNorth();
        Assert.Collection(sut.CurrentMap,
            m1 => Assert.Collection(m1,
                c1 => Assert.Equal('O', c1),
                c2 => Assert.Equal('.', c2)),
            m2 => Assert.Collection(m2,
                c1 => Assert.Equal('O', c1),
                c2 => Assert.Equal('.', c2)),
            m3 => Assert.Collection(m3,
                c1 => Assert.Equal('.', c1),
                c2 => Assert.Equal('#', c2)),
            m4 => Assert.Collection(m4,
                c1 => Assert.Equal('.', c1),
                c2 => Assert.Equal('O', c2)),
            m5 => Assert.Collection(m5,
                c1 => Assert.Equal('.', c1),
                c2 => Assert.Equal('.', c2)),
            m6 => Assert.Collection(m6,
                c1 => Assert.Equal('.', c1),
                c2 => Assert.Equal('.', c2)));
    }
}