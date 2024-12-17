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
    [InlineData("Register A: 64\nRegister B: 0\nRegister C: 0\n\nProgram: 0,1", 32, 0, 0)]
    [InlineData("Register A: 64\nRegister B: 0\nRegister C: 0\n\nProgram: 0,2", 16, 0, 0)]
    [InlineData("Register A: 64\nRegister B: 0\nRegister C: 0\n\nProgram: 0,3", 8, 0, 0)]
    [InlineData("Register A: 64\nRegister B: 2\nRegister C: 5\n\nProgram: 0,4", 0, 2, 5)]
    [InlineData("Register A: 64\nRegister B: 2\nRegister C: 5\n\nProgram: 0,5", 16, 2, 5)]
    [InlineData("Register A: 64\nRegister B: 2\nRegister C: 5\n\nProgram: 0,6", 2, 2, 5)]
    public void DivideAByOperand_WhenExecutingAdvOpcode(string input, int expectedA, int expectedB, int expectedC)
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

    [Theory]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,0", 2, 15, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,1", 2, 14, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,2", 2, 13, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,3", 2, 12, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,4", 2, 11, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,5", 2, 10, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,6", 2, 9, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,7", 2, 8, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,8", 2, 7, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,9", 2, 6, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,10", 2, 5, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,11", 2, 4, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,12", 2, 3, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,13", 2, 2, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,14", 2, 1, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 1,15", 2, 0, 3)]
    public void ExecuteBxlOpcodeCorrectly(string input, int expectedA, int expectedB, int expectedC)
    {
        var sut = new ChronospatialComputer(input);
        sut.Run();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
    }

    [Theory]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 2,0", 2, 0, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 2,1", 2, 1, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 2,2", 2, 2, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 2,3", 2, 3, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 2,4", 2, 2, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 2,5", 2, 7, 3)]
    [InlineData("Register A: 2\nRegister B: 15\nRegister C: 3\n\nProgram: 2,6", 2, 3, 3)]
    public void ExecuteBstOpcodeCorrectly(string input, int expectedA, int expectedB, int expectedC)
    {
        var sut = new ChronospatialComputer(input);
        sut.Run();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
    }

    [Theory]
    [InlineData("Register A: 0\nRegister B: 15\nRegister C: 3\n\nProgram: 3,4,0,2", 0, 15, 3)]
    [InlineData("Register A: 64\nRegister B: 15\nRegister C: 3\n\nProgram: 3,4,0,2", 64, 15, 3)]
    public void ExecuteJnzOpcodeCorrectly(string input, int expectedA, int expectedB, int expectedC)
    {
        var sut = new ChronospatialComputer(input);
        sut.Run();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
    }

    [Theory]
    [InlineData("Register A: 64\nRegister B: 15\nRegister C: 15\n\nProgram: 4,1", 64, 0, 15)]
    [InlineData("Register A: 64\nRegister B: 15\nRegister C: 1\n\nProgram: 4,2", 64, 14, 1)]
    public void SetRegisterBWithRegisterBXorRegisterA_WhenExecutingBxcOpcodeCorrectly(string input, int expectedA, int expectedB, int expectedC)
    {
        var sut = new ChronospatialComputer(input);
        sut.Run();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
    }

    [Theory]
    [InlineData("Register A: 64\nRegister B: 25\nRegister C: 36\n\nProgram: 5,0", 64, 25, 36, "0")]
    [InlineData("Register A: 64\nRegister B: 25\nRegister C: 36\n\nProgram: 5,1", 64, 25, 36, "1")]
    [InlineData("Register A: 64\nRegister B: 25\nRegister C: 36\n\nProgram: 5,2", 64, 25, 36, "2")]
    [InlineData("Register A: 64\nRegister B: 25\nRegister C: 36\n\nProgram: 5,3", 64, 25, 36, "3")]
    [InlineData("Register A: 64\nRegister B: 25\nRegister C: 36\n\nProgram: 5,4", 64, 25, 36, "0")]
    [InlineData("Register A: 64\nRegister B: 25\nRegister C: 36\n\nProgram: 5,5", 64, 25, 36, "1")]
    [InlineData("Register A: 64\nRegister B: 25\nRegister C: 36\n\nProgram: 5,6", 64, 25, 36, "4")]
    public void ReturnResult_WhenUsingOutOpcode(string input, int expectedA, int expectedB, int expectedC, string expectedOutput)
    {
        var sut = new ChronospatialComputer(input);
        sut.Run();
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedB, sut.B);
        Assert.Equal(expectedC, sut.C);
        Assert.Equal(expectedOutput, sut.OUT);
    }
}