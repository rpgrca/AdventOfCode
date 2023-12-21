using System.Security.Cryptography;
using Day21.Logic;
using static Day21.UnitTests.Constants;

namespace Day21.UnitTests;

public class StepCounterMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 11, 11)]
    [InlineData(PUZZLE_INPUT, 131, 131)]
    public void LoadInputCorrectly(string input, int expectedWidth, int expectedHeight)
    {
        var sut = new StepCounter(input);
        Assert.Equal(expectedWidth, sut.Width);
        Assert.Equal(expectedHeight, sut.Height);
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 5, 5)]
    [InlineData(PUZZLE_INPUT, 65, 65)]
    public void ParseInputCorrectly(string input, int expectedX, int expectedY)
    {
        var sut = new StepCounter(input);
        Assert.Equal(expectedX, sut.StartingX);
        Assert.Equal(expectedY, sut.StartingY);
    }

    [Fact]
    public void ExecuteOneStepCorrectly()
    {
        var sut = new StepCounter(SAMPLE_INPUT);
        sut.Step();
        Assert.Collection(sut.CurrentPositions,
            c1 => Assert.Equal((4, 5), c1),
            c2 => Assert.Equal((5, 4), c2));
    }

    [Fact]
    public void ExecuteTwoStepsCorrectly()
    {
        var sut = new StepCounter(SAMPLE_INPUT);
        sut.Step(2);
        Assert.Equal(4, sut.CurrentPositions.Count);
        Assert.Contains((3, 5), sut.CurrentPositions);
        Assert.Contains((4, 6), sut.CurrentPositions);
        Assert.Contains((5, 3), sut.CurrentPositions);
        Assert.Contains((5, 5), sut.CurrentPositions);
    }
}