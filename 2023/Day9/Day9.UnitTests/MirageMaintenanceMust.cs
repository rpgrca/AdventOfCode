using Day9.Logic;
using static Day9.UnitTests.Constants;

namespace Day9.UnitTests;

public class MirageMaintenanceMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 3)]
    [InlineData(PUZZLE_INPUT, 200)]
    public void LoadInputCorrectly(string input, int expectedHistoryCount)
    {
        var sut = new MirageMaintenance(input);
        Assert.Equal(expectedHistoryCount, sut.HistoryCount);
    }
}