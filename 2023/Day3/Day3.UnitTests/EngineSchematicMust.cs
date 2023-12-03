using Day3.Logic;
using static Day3.UnitTests.Constants;

namespace Day3.UnitTests;

public class EngineSchematicMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 10)]
    [InlineData(PUZZLE_INPUT, 140)]
    public void LoadInputCorrectly(string input, int expectedValue)
    {
        var sut = new EngineSchematic(input);
        Assert.Equal(expectedValue, sut.Width);
        Assert.Equal(expectedValue, sut.Height);
    }
}