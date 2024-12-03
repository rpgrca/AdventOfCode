using Day3.Logic;
using static Day3.UnitTests.Constants;

namespace Day3.UnitTests;

public class ProgramMemoryMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 71)]
    [InlineData(PUZZLE_INPUT, 20187)]
    public void LoadDataCorrectly(string input, int expectedLength)
    {
        var sut = new ProgramMemory(input);
        Assert.Equal(expectedLength, sut.Length);
    }

    [Theory]
    [InlineData("mul(44,46)", 2024)]
    [InlineData("mul(123,4)", 492)]
    [InlineData("mul(4*, mul(6,9!, ?(12,34)", 0)]
    [InlineData("mul ( 2 , 4 )", 0)]
    [InlineData("mul(44,46)mul(44,46)", 4048)]
    public void CalculateMultiplicationCorrectly(string input, int expectedResult)
    {
        var sut = new ProgramMemory(input);
        Assert.Equal(expectedResult, sut.SumOfMultiplications);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new ProgramMemory(SAMPLE_INPUT);
        Assert.Equal(161, sut.SumOfMultiplications);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new ProgramMemory(PUZZLE_INPUT);
        Assert.Equal(173517243, sut.SumOfMultiplications);
    }

    [Fact]
    public void HandleDontCorrectly()
    {
        var sut = new ProgramMemory("don't()_mul(5,5)");
        Assert.Equal(0, sut.SumOfEnabledMultiplications);
    }

    [Fact]
    public void HandleDoCorrectly()
    {
         var sut = new ProgramMemory("don't()_do()mul(5,5)");
        Assert.Equal(25, sut.SumOfEnabledMultiplications);
    }
}