using Day2.Logic;
using static Day2.UnitTests.Constants;

namespace Day2.UnitTests;

public class ReportsMust
{
    [Fact]
    public void LoadInputCorrectly()
    {
        var sut = new Reports(SAMPLE_INPUT);
        Assert.Equal(6, sut.Length);
    }
}