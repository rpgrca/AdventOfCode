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

    [Fact]
    public void MoveRobotsCorrectly_When100SecondsElapsed()
    {
        var sut = new RestroomRedoubt(SAMPLE_INPUT, 11, 7);
        sut.CalculateAfter(100);
        Assert.Collection(sut.Robots,
            p1 => Assert.Equal(new(new(3, 5), new(3, -3)), p1),
            p2 => Assert.Equal(new(new(5, 4), new(-1, -3)), p2),
            p3 => Assert.Equal(new(new(9, 0), new(-1, 2)), p3),
            p4 => Assert.Equal(new(new(4, 5), new(2, -1)), p4),
            p5 => Assert.Equal(new(new(1, 6), new(1, 3)), p5),
            p6 => Assert.Equal(new(new(1, 3), new(-2, -2)), p6),
            p7 => Assert.Equal(new(new(6, 0), new(-1, -3)), p7),
            p8 => Assert.Equal(new(new(2, 3), new(-1, -2)), p8),
            p9 => Assert.Equal(new(new(0, 2), new(2, 3)), p9),
            p10 => Assert.Equal(new(new(6, 0), new(-1, 2)), p10),
            p11 => Assert.Equal(new(new(4, 5), new(2, -3)), p11),
            p12 => Assert.Equal(new(new(6, 6), new(-3, -3)), p12));
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new RestroomRedoubt(SAMPLE_INPUT, 11, 7);
        sut.CalculateAfter(100);
        sut.CalculateSafetyFactor();
        Assert.Equal(12, sut.SafetyFactor);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new RestroomRedoubt(PUZZLE_INPUT, 101, 103);
        sut.CalculateAfter(100);
        sut.CalculateSafetyFactor();
        Assert.Equal(224554908, sut.SafetyFactor);
    }
}