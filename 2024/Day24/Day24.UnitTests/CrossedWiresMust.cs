using Day24.Logic;
using static Day24.UnitTests.Constants;

namespace Day24.UnitTests;

public class CrossedWiredMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 10, 36)]
    [InlineData(SECOND_SAMPLE_INPUT, 6, 3)]
    [InlineData(PUZZLE_INPUT, 90, 222)]
    public void LoadInputCorrectly(string input, int expectedWires, int expectedGates)
    {
        var sut = new CrossedWires(input);
        Assert.Equal(expectedWires, sut.WiresCount);
        Assert.Equal(expectedGates, sut.GatesCount);
    }
}