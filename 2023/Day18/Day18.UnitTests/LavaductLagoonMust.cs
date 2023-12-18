using Day18.Logic;
using static Day18.UnitTests.Constants;

namespace Day18.UnitTests;

public class LavaductLagoonMust
{
    /*
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
    [InlineData("R 5 (#70c710)\nD 5 (#70c710)\nL 5 (#70c710)\nU 5 (#70c710)", 20)]
    [InlineData(SAMPLE_INPUT, 38)]
    [InlineData(PUZZLE_INPUT, 3770)]
    public void CalculatePerimeterCorrectly(string input, int expectedPerimeter)
    {
        var sut = new LavaductLagoon(input, 700);
        sut.Dig();
        Assert.Equal(expectedPerimeter, sut.TrenchPerimeter);
    }
*/
    [Theory]
    //[InlineData("R 1 (#70c710)", 1)]
    //[InlineData("R 5 (#70c710)\nD 5 (#70c710)\nL 5 (#70c710)\nU 5 (#70c710)", 36)]
    [InlineData(SAMPLE_INPUT, 62)]
    public void CalculateAreaCorrectly(string input, int expectedArea)
    {
        var sut = new LavaductLagoon(input, 80);
        sut.Dig();
        sut.Draw();
        Assert.Equal(expectedArea, sut.TrenchArea);
    }
}