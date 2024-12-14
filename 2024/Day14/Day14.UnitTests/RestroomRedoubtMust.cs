using Day14.Logic;
using static Day14.UnitTests.Constants;

namespace Day14.UnitTests;

public class RestroomRedoubtMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 11, 7, 12)]
    [InlineData(PUZZLE_INPUT, 101, 103, 500)]
    public void LoadInputCorrectly(string input, int width, int height, int expectedCount)
    {
        var sut = new RestroomRedoubt(input, width, height);
        Assert.Equal(expectedCount, sut.RobotCount);
    }

    [Fact]
    public void SetupRobotCorrectly()
    {
        var sut = new RestroomRedoubt("p=2,4 v=2,-3", 11, 7);
        sut.CalculateAfter(0);
        Assert.Collection(sut.Robots,
            p1 => {
                Assert.Equal(new(new(2, 4), new(2, -3)), p1);
            });
    }

    [Fact]
    public void MoveRobotCorrectly_When1SecondElapsed()
    {
        var sut = new RestroomRedoubt("p=2,4 v=2,-3", 11, 7);
        sut.CalculateAfter(1);
        Assert.Collection(sut.Robots,
            p1 => {
                Assert.Equal(new(new(4, 1), new(2, -3)), p1);
            });
    }

    [Fact]
    public void MoveRobotCorrectly_When2SecondsElapsed()
    {
        var sut = new RestroomRedoubt("p=2,4 v=2,-3", 11, 7);
        sut.CalculateAfter(2);
        Assert.Collection(sut.Robots,
            p1 => {
                Assert.Equal(new(new(6, 5), new(2, -3)), p1);
            });
    }

    [Fact]
    public void MoveRobotCorrectly_When3SecondsElapsed()
    {
        var sut = new RestroomRedoubt("p=2,4 v=2,-3", 11, 7);
        sut.CalculateAfter(3);
        Assert.Collection(sut.Robots,
            p1 => {
                Assert.Equal(new(new(8, 2), new(2, -3)), p1);
            });
    }

    [Fact]
    public void MoveRobotCorrectly_When4SecondsElapsed()
    {
        var sut = new RestroomRedoubt("p=2,4 v=2,-3", 11, 7);
        sut.CalculateAfter(4);
        Assert.Collection(sut.Robots,
            p1 => {
                Assert.Equal(new(new(10, 6), new(2, -3)), p1);
            });
    }

    [Fact]
    public void MoveRobotCorrectly_When5SecondsElapsed()
    {
        var sut = new RestroomRedoubt("p=2,4 v=2,-3", 11, 7);
        sut.CalculateAfter(5);
        Assert.Collection(sut.Robots,
            p1 => {
                Assert.Equal(new(new(1, 3), new(2, -3)), p1);
            });
    }
}