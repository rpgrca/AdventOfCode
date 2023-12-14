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
    public void DoNotMoveCubeRocks_WhenVerticalMapHasOneCubeRock(string input, char expectedFirst, char expectedSecond)
    {
        var sut = new ParabolicReflectorDish(input);
        sut.TiltNorth();
        Assert.Collection(sut.CurrentMap,
            m1 => Assert.Collection(m1, c1 => Assert.Equal(expectedFirst, c1)),
            m2 => Assert.Collection(m2, c2 => Assert.Equal(expectedSecond, c2)));
    }

}