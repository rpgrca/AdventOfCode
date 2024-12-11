using Day11.Logic;
using static Day11.UnitTests.Constants;

namespace Day11.UnitTests;

public class PlutonianPebblesMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 2)]
    public void LoadInputCorrectly(string input, int expectedCount)
    {
        var sut = new PlutonianPebbles(input);
        Assert.Equal(expectedCount, sut.Count);
    }
}