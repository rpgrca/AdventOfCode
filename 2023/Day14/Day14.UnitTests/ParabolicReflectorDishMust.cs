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
}