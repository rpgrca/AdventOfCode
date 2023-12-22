using Day22.Logic;
using static Day22.UnitTests.Constants;

namespace Day22.UnitTests;

public class SandSlabsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 7)]
    [InlineData(PUZZLE_INPUT, 1250)]
    public void LoadInputCorrectly(string input, int expectedCount)
    {
        var sut = new SandSlabs(input);
        Assert.Equal(expectedCount, sut.BrickCount);
    }

    [Fact]
    public void ParseInputCorrectly()
    {
        var sut = new SandSlabs("1,0,1~1,2,1");
        Assert.Collection(sut.Bricks,
            b1 => {
                Assert.Equal((1, 0, 1), b1.Start);
                Assert.Equal((1, 2, 1), b1.End);
            });
    }

    [Fact]
    public void DoNotDropBricks_WhenBrickIsResting()
    {
        var sut = new SandSlabs("1,0,1~1,2,1\n0,0,2~2,0,2");
        sut.Drop();
        Assert.Collection(sut.Bricks,
            b1 => {
                Assert.Equal((1, 0, 1), b1.Start);
                Assert.Equal((1, 2, 1), b1.End);
            },
            b2 => {
                Assert.Equal((0, 0, 2), b2.Start);
                Assert.Equal((2, 0, 2), b2.End);
            });
    }

    [Fact]
    public void DropBricksCorrectly_WhenBricksHaveGapBelow()
    {
        var sut = new SandSlabs("1,0,1~1,2,1\n0,0,2~2,0,2\n0,2,3~2,2,3");
        var result = sut.Drop();

        Assert.True(result);
        Assert.Collection(sut.Bricks,
              b1 => {
                Assert.Equal((1, 0, 1), b1.Start);
                Assert.Equal((1, 2, 1), b1.End);
            },
            b2 => {
                Assert.Equal((0, 0, 2), b2.Start);
                Assert.Equal((2, 0, 2), b2.End);
            },
            b3 => {
                Assert.Equal((0, 2, 2), b3.Start);
                Assert.Equal((2, 2, 2), b3.End);
            });
    }

    [Fact]
    public void DoNotDropBricks_WhenEveryBrickIsResting()
    {
        var sut = new SandSlabs("1,0,1~1,2,1\n0,0,2~2,0,2\n0,2,2~2,2,2");
        var result = sut.Drop();

        Assert.False(result);
        Assert.Collection(sut.Bricks,
              b1 => {
                Assert.Equal((1, 0, 1), b1.Start);
                Assert.Equal((1, 2, 1), b1.End);
            },
            b2 => {
                Assert.Equal((0, 0, 2), b2.Start);
                Assert.Equal((2, 0, 2), b2.End);
            },
            b3 => {
                Assert.Equal((0, 2, 2), b3.Start);
                Assert.Equal((2, 2, 2), b3.End);
            });
    }

    [Fact]
    public void DropBricksCorrectlyUntilResting()
    {
        var sut = new SandSlabs(SAMPLE_INPUT);
        sut.DropUntilRest();
    }
}