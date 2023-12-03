using Day3.Logic;
using static Day3.UnitTests.Constants;

namespace Day3.UnitTests;

public class EngineSchematicMust
{
    [Fact]
    public void LoadInputCorrectly()
    {
        var sut = new EngineSchematic(SAMPLE_INPUT);
        Assert.Equal(10, sut.Width);
        Assert.Equal(10, sut.Height);
    }
}