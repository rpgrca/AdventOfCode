using Day13.Logic;
using static Day13.UnitTests.Constants;

namespace Day13.UnitTests;

public class PointOfIncidenceMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 2)]
    public void LoadInputCorrectly(string input, int expectedMaps)
    {
        var sut = new PointOfIncidence(input);
        Assert.Equal(expectedMaps, sut.MapCount);
    }
}