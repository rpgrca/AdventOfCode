using Day8.Logic;
using static Day8.UnitTests.Constants;

namespace Day8.UnitTests;

public class AntinodeMapMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 12)]
    [InlineData(SECOND_SAMPLE_INPUT, 10)]
    [InlineData(THIRD_SAMPLE_INPUT, 10)]
    [InlineData(PUZZLE_INPUT, 50)]
    public void LoadInputCorrectly(string input, int expectedSize)
    {
        var sut = AntinodeMap.CreateWithoutHarmonics(input);
        Assert.Equal(expectedSize, sut.Size);
    }

    [Theory]
    [InlineData(SECOND_SAMPLE_INPUT, 2)]
    [InlineData(THIRD_SAMPLE_INPUT, 4)]
    [InlineData(FOURTH_SAMPLE_INPUT, 4)]
    public void CalculateAntinodesCorrectly(string input, int expectedCount)
    {
        var sut = AntinodeMap.CreateWithoutHarmonics(input);
        Assert.Equal(expectedCount, sut.AntinodeCount);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = AntinodeMap.CreateWithoutHarmonics(SAMPLE_INPUT);
        Assert.Equal(14, sut.AntinodeCount);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = AntinodeMap.CreateWithoutHarmonics(PUZZLE_INPUT);
        Assert.Equal(398, sut.AntinodeCount);
    }

    [Fact]
    public void CalculateAntinodesCorrectly_WhenUsingResonantHarmonics()
    {
        var sut = AntinodeMap.CreateWithHarmonics(FIFTH_SAMPLE_INPUT);
        Assert.Equal(9, sut.AntinodeCount);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = AntinodeMap.CreateWithHarmonics(SAMPLE_INPUT);
        Assert.Equal(34, sut.AntinodeCount);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = AntinodeMap.CreateWithHarmonics(PUZZLE_INPUT);
        Assert.Equal(1333, sut.AntinodeCount);
    }
}