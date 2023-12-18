using Day18.Logic;
using static Day18.UnitTests.Constants;

namespace Day18.UnitTests;

public class LavaductLagoonMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 14)]
    [InlineData(PUZZLE_INPUT, 728)]
    public void LoadInputCorrectly(string input, int expectedLength)
    {
        var sut = new LavaductLagoon(input);
        Assert.Equal(expectedLength, sut.DigPlanLength);
    }

    [Theory]
    [InlineData("R 1 (#70c710)", 1)]
    [InlineData("R 6 (#70c710)\nD 5 (#70c710)\nL 5 (#70c710)\nU 4 (#70c710)", 20)]
    public void DigCorrectly(string input, int expectedPerimeter)
    {
        var sut = new LavaductLagoon(input);
        sut.Dig();
        Assert.Equal(expectedPerimeter, sut.TrenchPerimeter);
    }
}