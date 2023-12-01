using Day01.Logic;
using static Day01.UnitTests.Constants;

namespace Day01.UnitTests;

public class CalibrationDocumentMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 4)]
    [InlineData(PUZZLE_INPUT, 1000)]
    public void LoadDataCorrectly(string input, int expectedLines)
    {
        var sut = new CalibrationDocument(input);
        Assert.Equal(expectedLines, sut.LineCount);
    }
}