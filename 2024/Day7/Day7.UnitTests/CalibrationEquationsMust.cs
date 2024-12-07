using Day7.Logic;
using static Day7.UnitTests.Constants;

namespace Day7.UnitTests;

public class CalibrationEquationsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 9)]
    public void LoadInputCorrectly(string input, int expectedCount)
    {
        var sut = new CalibrationEquations(input);
        Assert.Equal(expectedCount, sut.Count);
    }
}