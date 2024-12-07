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
    public void ReturnCorrectTotalCalibration(string input, int expectedResult)
    {
        var sut = new CalibrationEquations(input);
        Assert.Equal(expectedResult, sut.TotalCalibration);
    }
}