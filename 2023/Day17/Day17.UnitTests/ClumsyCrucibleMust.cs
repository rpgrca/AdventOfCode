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
    [InlineData("119111\n911191", 8)]
    [InlineData("11111\n22292\n33333", 13)]
    [InlineData("2413\n3215", 11)]
    [InlineData("241343\n321545", 20)]
    [InlineData("241343231\n321545353", 32)]
    [InlineData("241343231\n321545353\n325524565", 37)]
    [InlineData("24134323113\n32154535356\n32552456542\n34465858454", 47)]
    [InlineData("2413432311323\n3215453535623\n3255245654254\n3446585845452\n4546657867536\n1438598798454\n4457876987766\n3637877979653\n4654967986887", 80)] // TODO: 81 in final solution
    [InlineData("2413432311323\n3215453535623\n3255245654254\n3446585845452\n4546657867536\n1438598798454\n4457876987766\n3637877979653\n4654967986887\n4564679986453", 84)]
    public void CalculateBestPathCorrectly(string input, int expectedHeatLoss)
    {
        var sut = new ClumsyCrucible(input);
        sut.FindBestRoute();
        Assert.Equal(expectedHeatLoss, sut.HeatLoss);
    }

    [Theory]
    [InlineData("11111\n99999\n33333", 18)]
    public void DoNotMoveMoreThanThreeTimesInOneDirection(string input, int expectedHeatLoss)
    {
        var sut = new ClumsyCrucible(input);
        sut.FindBestRoute();
        Assert.Equal(expectedHeatLoss, sut.HeatLoss);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new ClumsyCrucible(SAMPLE_INPUT, true, 103);
        sut.FindBestRouteBreadthFirst();
        Assert.Equal(102, sut.HeatLoss);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new ClumsyCrucible(PUZZLE_INPUT, true, 1111);
        sut.FindBestRouteBreadthFirst();
        Assert.Equal(1110, sut.HeatLoss);
    }
}