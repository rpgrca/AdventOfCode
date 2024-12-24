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

    [Theory]
    [InlineData("x00: 1\nx01: 1\n\nx00 AND x01 -> z00", 1)]
    [InlineData("x00: 1\nx01: 0\n\nx00 AND x01 -> z00", 0)]
    [InlineData("x00: 0\nx01: 1\n\nx00 AND x01 -> z00", 0)]
    [InlineData("x00: 0\nx01: 0\n\nx00 AND x01 -> z00", 0)]
    public void ExecuteAndGateCorrectly(string input, ulong expectedResult)
    {
        var sut = new CrossedWires(input);
        sut.Execute();
        Assert.Equal(expectedResult, sut.OutputAsDecimalNumber);
    }

    [Theory]
    [InlineData("x00: 1\nx01: 1\n\nx00 OR x01 -> z00", 1)]
    [InlineData("x00: 1\nx01: 0\n\nx00 OR x01 -> z00", 1)]
    [InlineData("x00: 0\nx01: 1\n\nx00 OR x01 -> z00", 1)]
    [InlineData("x00: 0\nx01: 0\n\nx00 OR x01 -> z00", 0)]
    public void ExecuteOrGateCorrectly(string input, ulong expectedResult)
    {
        var sut = new CrossedWires(input);
        sut.Execute();
        Assert.Equal(expectedResult, sut.OutputAsDecimalNumber);
    }

    [Theory]
    [InlineData("x00: 1\nx01: 1\n\nx00 XOR x01 -> z00", 0)]
    [InlineData("x00: 1\nx01: 0\n\nx00 XOR x01 -> z00", 1)]
    [InlineData("x00: 0\nx01: 1\n\nx00 XOR x01 -> z00", 1)]
    [InlineData("x00: 0\nx01: 0\n\nx00 XOR x01 -> z00", 0)]
    public void ExecuteXorGateCorrectly(string input, ulong expectedResult)
    {
        var sut = new CrossedWires(input);
        sut.Execute();
        Assert.Equal(expectedResult, sut.OutputAsDecimalNumber);
    }

    [Theory]
    [InlineData(SECOND_SAMPLE_INPUT, 4)]
    [InlineData(SAMPLE_INPUT, 2024)]
    public void SolveFirstSamplesCorrectly(string input, ulong expectedResult)
    {
        var sut = new CrossedWires(input);
        sut.Execute();
        Assert.Equal(expectedResult, sut.OutputAsDecimalNumber);
    }
}