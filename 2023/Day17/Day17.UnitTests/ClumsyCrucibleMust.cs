using Day17.Logic;
using static Day17.UnitTests.Constants;

namespace Day17.UnitTests;

public class ClumsyCrucibleMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 13, 13)]
    [InlineData(PUZZLE_INPUT, 141, 141)]
    public void LoadInputCorrectly(string input, int expectedWidth, int expectedHeight)
    {
        var sut = new ClumsyCrucible(input);
        Assert.Equal(expectedWidth, sut.Width);
        Assert.Equal(expectedHeight, sut.Height);
    }

    [Theory]
    [InlineData(SAMPLE_INPUT)]
    [InlineData(PUZZLE_INPUT)]
    public void CalculateEntranceCorrectly(string input)
    {
        var sut = new ClumsyCrucible(input);
        Assert.Equal((0, 0), sut.Entrance);
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 12, 12)]
    [InlineData(PUZZLE_INPUT, 140, 140)]
    public void CalculateGoalCorrectly(string input, int expectedX, int expectedY)
    {
        var sut = new ClumsyCrucible(input);
        Assert.Equal((expectedX, expectedY), sut.Goal);
    }

    [Theory]
    [InlineData("1234\n5678", 17)]
    [InlineData("123\n456", 11)]
    [InlineData("5678\n1234", 10)]
    [InlineData("1289\n8345", 14)]
    public void CalculateBestPathCorrectly(string input, int expectedHeatLoss)
    {
        var sut = new ClumsyCrucible(input);
        sut.FindBestRoute();
        Assert.Equal(expectedHeatLoss, sut.HeatLoss);
    }
}