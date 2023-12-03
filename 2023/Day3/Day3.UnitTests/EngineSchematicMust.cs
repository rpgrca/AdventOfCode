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

    [Theory]
    [InlineData(@"467..114..
...*......", 467)]
    [InlineData(@"617*......
.....+.58.
..592.....", 1209)]
    public void CalculateSumOfPartsCorrectly(string input, int expectedSum)
    {
        var sut = new EngineSchematic(input);
        Assert.Equal(expectedSum, sut.SumOfParts);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new EngineSchematic(SAMPLE_INPUT);
        Assert.Equal(4361, sut.SumOfParts);
    }
}