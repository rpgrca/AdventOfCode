using System.Diagnostics.CodeAnalysis;
using Day17.Logic;
using Xunit.Sdk;
using static Day17.UnitTests.Constants;

namespace Day17.UnitTests;

public class ChronospatialComputerMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 729, 0, 0, 6)]
    [InlineData(PUZZLE_INPUT, 63281501, 0, 0, 16)]
    public void LoadInputCorrectly(string input, int expectedA, int expectedB, int expectedC, int expectedLength)
    {
        var sut = new ChronospatialComputer(input);
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
        Assert.Equal(expectedLength, sut.Length);
    }

    [Theory]
    [InlineData("Register A: 0\nRegister B: 0\nRegister C: 0\n\nProgram: 0,1", 0, 0, 0)]
    [InlineData("Register A: 64\nRegister B: 0\nRegister C: 0\n\nProgram: 0,1", 64, 0, 0)]
    [InlineData("Register A: 64\nRegister B: 0\nRegister C: 0\n\nProgram: 0,2", 32, 0, 0)]
    [InlineData("Register A: 64\nRegister B: 0\nRegister C: 0\n\nProgram: 0,3", 21, 0, 0)]
    [InlineData("Register A: 64\nRegister B: 2\nRegister C: 5\n\nProgram: 0,4", 1, 2, 5)]
    [InlineData("Register A: 64\nRegister B: 2\nRegister C: 5\n\nProgram: 0,5", 32, 2, 5)]
    [InlineData("Register A: 64\nRegister B: 2\nRegister C: 5\n\nProgram: 0,6", 12, 2, 5)]
    public void ExecuteOpcodeAdvCorrectly(string input, int expectedA, int expectedB, int expectedC)
    {
        var sut = new ChronospatialComputer(input);
        sut.Run();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
    }

    [Fact]
    public void ThrowException_WhenAdvOperandIs7()
    {
        var sut = new ChronospatialComputer("Register A: 0\nRegister B: 0\nRegister C: 0\n\nProgram: 0,7");
        var exception = Assert.Throws<ArgumentException>(() => sut.Run());
        Assert.Equal("Invalid operand 7", exception.Message);
    }
}