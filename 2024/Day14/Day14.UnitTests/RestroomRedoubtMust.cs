using System.Security.Cryptography;
using Day14.Logic;
using NuGet.Frameworks;
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
        Assert.Collection(sut.Robots,
            p1 => {
                Assert.Equal(((2, 4), (2, -3)), p1);
            });
    }


}