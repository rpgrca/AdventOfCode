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
        Assert.Equal(4UL, sut.CountCurrentPositions(2));
        Assert.Contains((3, 5), sut.CurrentPositions);
        Assert.Contains((4, 6), sut.CurrentPositions);
        Assert.Contains((5, 3), sut.CurrentPositions);
        Assert.Contains((5, 5), sut.CurrentPositions);
    }

    [Fact]
    public void ExecuteThreeStepsCorrectly()
    {
        var sut = new StepCounter(SAMPLE_INPUT);
        sut.Step(3);
        Assert.Equal(6UL, sut.CountCurrentPositions(3));
        Assert.Contains((6, 3), sut.CurrentPositions);
        Assert.Contains((3, 4), sut.CurrentPositions);
        Assert.Contains((5, 4), sut.CurrentPositions);
        Assert.Contains((4, 5), sut.CurrentPositions);
        Assert.Contains((3, 6), sut.CurrentPositions);
        Assert.Contains((4, 7), sut.CurrentPositions);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new StepCounter(SAMPLE_INPUT);
        sut.Step(6);
        Assert.Equal(16UL, sut.CountCurrentPositions(6));
        Assert.Contains((8, 2), sut.CurrentPositions);
        Assert.Contains((1, 3), sut.CurrentPositions);
        Assert.Contains((3, 3), sut.CurrentPositions);
        Assert.Contains((5, 3), sut.CurrentPositions);
        Assert.Contains((7, 3), sut.CurrentPositions);
        Assert.Contains((0, 4), sut.CurrentPositions);
        Assert.Contains((2, 4), sut.CurrentPositions);
        Assert.Contains((8, 4), sut.CurrentPositions);
        Assert.Contains((3, 5), sut.CurrentPositions);
        Assert.Contains((5, 5), sut.CurrentPositions);
        Assert.Contains((4, 6), sut.CurrentPositions);
        Assert.Contains((6, 6), sut.CurrentPositions);
        Assert.Contains((1, 7), sut.CurrentPositions);
        Assert.Contains((3, 7), sut.CurrentPositions);
        Assert.Contains((5, 7), sut.CurrentPositions);
        Assert.Contains((3, 9), sut.CurrentPositions);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new StepCounter(PUZZLE_INPUT);
        sut.Step(64);
        Assert.Equal(3770UL, sut.CountCurrentPositions(64));
    }

    [Theory]
    //[InlineData(6, 16)]
    //[InlineData(7, 22)]
    //[InlineData(8, 30)]
    //[InlineData(9, 41)]
    //[InlineData(10, 50)]
    //[InlineData(11, 63)]
    //[InlineData(12, 74)]
    //[InlineData(13, 89)] /*a)*/
    //[InlineData(14, 99)]
    //[InlineData(15, 115)]
    //[InlineData(16, 129)]
    //[InlineData(21, 234)]
    //[InlineData(22, 261)]
    //[InlineData(23, 294)]*/
    //[InlineData(50, 1594)]

    //[InlineData(100, 6536)]
    //[InlineData(500, 167004)]
    [InlineData(1000, 668697)]
    //[InlineData(5000, 16733044)]
    public void ExecuteStepsCorrectly_WhenUsingInfiniteMap(int steps, ulong expectedPlots)
    {
        var sut = new StepCounter(SAMPLE_INPUT);
        sut.Step(steps);
        //sut.Draw();
        Assert.Equal(expectedPlots, sut.CountCurrentPositions(steps));
    }
/*
    [Theory]
    [InlineData(6, 44)]
    [InlineData(10, 112)]
    [InlineData(20, 383)]
    [InlineData(30, 841)]
    [InlineData(50, 2290)]
    [InlineData(100, 9188)]
    public void Test1(int steps, ulong expectedPlots)
    {
        var sut = new StepCounter(PUZZLE_INPUT);
        sut.Step(steps);
        Assert.Equal(expectedPlots, sut.CountCurrentPositions());
    }*/
}