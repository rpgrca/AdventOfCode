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
}