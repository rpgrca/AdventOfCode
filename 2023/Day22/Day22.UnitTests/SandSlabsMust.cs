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
                Assert.Equal((1,0,1), b1.Start);
                Assert.Equal((1,2,1), b1.End);
            });
    }
}