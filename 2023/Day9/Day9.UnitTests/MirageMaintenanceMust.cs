using Day9.Logic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Host;
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

    [Fact]
    public void ParseInputCorrectly()
    {
        var sut = new MirageMaintenance(SAMPLE_INPUT);
        Assert.Collection(sut.Histories,
            p1 => Assert.Equal(new[] { 0, 3, 6, 9, 12, 15 }, p1),
            p2 => Assert.Equal(new[] { 1, 3, 6, 10, 15, 21 }, p2),
            p3 => Assert.Equal(new[] { 10, 13, 16, 21, 30, 45 }, p3));
    }
}