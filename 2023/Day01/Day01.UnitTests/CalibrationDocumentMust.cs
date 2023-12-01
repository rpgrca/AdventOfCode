using Day01.Logic;
using static Day01.UnitTests.Constants;

namespace Day01.UnitTests;

public class CalibrationDocumentMust
{
    [Fact]
    public void LoadDataCorrectly()
    {
        var sut = new CalibrationDocument(SAMPLE_INPUT);
        Assert.Equal(4, sut.LineCount);
    }
}