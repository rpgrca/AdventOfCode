using Day7.Logic;
using static Day7.UnitTests.Constants;

namespace Day7.UnitTests;

public class CalibrationEquationsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 9)]
    [InlineData(PUZZLE_INPUT, 850)]
    public void LoadInputCorrectly(string input, int expectedCount)
    {
        var sut = CalibrationEquations.WithoutConcatenation(input);
        Assert.Equal(expectedCount, sut.Count);
    }

    [Theory]
    [InlineData("190: 10 19", 190)]
    [InlineData("83: 17 5", 0)]
    [InlineData("3267: 81 40 27", 3267)]
    public void ReturnCorrectTotalCalibration(string input, int expectedResult)
    {
        var sut = CalibrationEquations.WithoutConcatenation(input);
        Assert.Equal(expectedResult, sut.TotalCalibration);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = CalibrationEquations.WithoutConcatenation(SAMPLE_INPUT);
        Assert.Equal(3749, sut.TotalCalibration);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = CalibrationEquations.WithoutConcatenation(PUZZLE_INPUT);
        Assert.Equal(8401132154762, sut.TotalCalibration);
    }

    [Theory]
    [InlineData("156: 15 6", 156)]
    [InlineData("4948000293: 5 173 5 4 7 286 10 2 81", 4948000293)]
    public void ConcatenateCorrectly(string input, long expectedResult)
    {
        var sut = CalibrationEquations.WithConcatenation(input);
        Assert.Equal(expectedResult, sut.TotalCalibration);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = CalibrationEquations.WithConcatenation(SAMPLE_INPUT);
        Assert.Equal(11387, sut.TotalCalibration);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = CalibrationEquations.WithConcatenation(PUZZLE_INPUT);
        Assert.Equal(95297119227552, sut.TotalCalibration);
    }
}