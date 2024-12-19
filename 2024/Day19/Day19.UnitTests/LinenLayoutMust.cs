using Day19.Logic;
using static Day19.UnitTests.Constants;

namespace Day19.UnitTests;

public class LinenLayoutMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 8, 8)]
    [InlineData(PUZZLE_INPUT, 447, 400)]
    public void LoadInputCorrectly(string input, int expectedTowels, int expectedDesigns)
    {
        var sut = new LinenLayout(input);
        Assert.Equal(expectedTowels, sut.TowelsCount);
        Assert.Equal(expectedDesigns, sut.DesignsCount);
    }

    [Theory]
    [InlineData("r\n\nr", 1)]
    [InlineData("r\n\nr\nrr", 2)]
    public void ValidateDesignCorrectly(string input, int expectedCount)
    {
        var sut = new LinenLayout(input);
        sut.Validate();
        Assert.Equal(expectedCount, sut.ValidDesignsCount);
    }
}