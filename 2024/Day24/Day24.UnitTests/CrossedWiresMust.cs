using System.Runtime.CompilerServices;
using Day24.Logic;
using Xunit.Sdk;
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

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new CrossedWires(PUZZLE_INPUT);
        sut.Execute();
        Assert.Equal(65635066541798UL, sut.OutputAsDecimalNumber);
    }

    [Fact]
    public void CalculateExpectedResultForZ()
    {
        var sut = new CrossedWires(THIRD_SAMPLE_INPUT);
        var value = sut.CalculateExpectedResultWith((x, y) => x & y);
        Assert.Equal( /* 0b101000 */ 40UL, value);
    }

    [Fact]
    public void CalculateDifferenceWithExpectedResult()
    {
        var sut = new CrossedWires(THIRD_SAMPLE_INPUT);
        var difference = sut.CalculateDifferenceWithExpected((x, y) => x & y);
        Assert.Equal(40UL, difference);
    }

    [Fact]
    public void ReturnZero_WhenAndNeverFailsWithAll1()
    {
        var sut = new CrossedWires(THIRD_SAMPLE_INPUT, new() {
            { "x00", 1 }, { "x01", 1 }, { "x02", 1 }, { "x03", 1 }, { "x04", 1 }, { "x05", 1 },
            { "y00", 1 }, { "y01", 1 }, { "y02", 1 }, { "y03", 1 }, { "y04", 1 }, { "y05", 1 },
        });

        sut.Execute();
        var difference = sut.CalculateDifferenceWithExpected((x, y) => x & y);
        Assert.Equal(0UL, difference);
    }

    [Fact]
    public void ReturnZero_WhenAndNeverFailsWithAll0()
    {
        var sut = new CrossedWires(THIRD_SAMPLE_INPUT, new() {
            { "x00", 0 }, { "x01", 0 }, { "x02", 0 }, { "x03", 0 }, { "x04", 0 }, { "x05", 0 },
            { "y00", 0 }, { "y01", 0 }, { "y02", 0 }, { "y03", 0 }, { "y04", 0 }, { "y05", 0 },
        });

        sut.Execute();
        var difference = sut.CalculateDifferenceWithExpected((x, y) => x & y);
        Assert.Equal(0UL, difference);
    }


/*
    [Fact]
    public void FixCircuitryCorrectly()
    {
        var sut = new CrossedWires(THIRD_SAMPLE_INPUT);
        var result = sut.GetFixedWireNames((x, y) => x & y);
        Assert.Equal("z00,z01,z02,z05", result);
    }*/
}