using Day13.Logic;
using static Day13.UnitTests.Constants;

namespace Day13.UnitTests;

public class ClawContraptionsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 4)]
    [InlineData(PUZZLE_INPUT, 100)]
    public void LoadInputCorrectly(string input, int expectedCount)
    {
        var sut = new ClawContraptions(input);
        Assert.Equal(expectedCount, sut.Count);
    }
}