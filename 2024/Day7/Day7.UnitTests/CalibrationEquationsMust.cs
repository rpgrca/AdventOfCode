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
        var sut = new CalibrationEquations(input);
        Assert.Equal(expectedCount, sut.Count);
    }

    [Theory]
    [InlineData("190: 10 19", 190)]
    [InlineData("83: 17 5", 0)]
    [InlineData("3267: 81 40 27", 3267)]
    public void ReturnCorrectTotalCalibration(string input, int expectedResult)
    {
        var sut = new CalibrationEquations(input);
        Assert.Equal(expectedResult, sut.TotalCalibration);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new CalibrationEquations(SAMPLE_INPUT);
        Assert.Equal(3749, sut.TotalCalibration);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new CalibrationEquations(PUZZLE_INPUT);
        Assert.Equal(8401132154762, sut.TotalCalibration);
    }

    [Theory]
    [InlineData("156: 15 6", 156)]
    public void ConcatenateCorrectly(string input, int expectedResult)
    {
        var sut = new CalibrationEquations(input, true);
        Assert.Equal(expectedResult, sut.TotalCalibration);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new CalibrationEquations(SAMPLE_INPUT, true);
        Assert.Equal(11387, sut.TotalCalibration);
    }

}