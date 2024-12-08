using System.Security.Cryptography;
using Day8.Logic;
using Microsoft.VisualStudio.TestPlatform.ObjectModel.Host;
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
        var sut = new AntinodeMap(input);
        Assert.Equal(expectedSize, sut.Size);
    }

    [Fact]
    public void ParseMapCorrectly()
    {
        var sut = new AntinodeMap(SAMPLE_INPUT);
        Assert.Collection(sut.Antennas,
            p1 => Assert.Equal(new('0', 8, 1), p1),
            p2 => Assert.Equal(new('0', 5, 2), p2),
            p3 => Assert.Equal(new('0', 7, 3), p3),
            p4 => Assert.Equal(new('0', 4, 4), p4),
            p5 => Assert.Equal(new('A', 6, 5), p5),
            p6 => Assert.Equal(new('A', 8, 8), p6),
            p7 => Assert.Equal(new('A', 9, 9), p7));
    }

    [Theory]
    [InlineData(SECOND_SAMPLE_INPUT, 2)]
    [InlineData(THIRD_SAMPLE_INPUT, 4)]
    [InlineData(FOURTH_SAMPLE_INPUT, 4)]
    public void CalculateAntinodesCorrectly(string input, int expectedCount)
    {
        var sut = new AntinodeMap(input);
        Assert.Equal(expectedCount, sut.AntinodeCount);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new AntinodeMap(SAMPLE_INPUT);
        Assert.Equal(14, sut.AntinodeCount);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new AntinodeMap(PUZZLE_INPUT);
        Assert.Equal(398, sut.AntinodeCount);
    }

    [Fact]
    public void CalculateAntinodesCorrectly_WhenUsingResonantHarmonics()
    {
        var sut = new AntinodeMap(FIFTH_SAMPLE_INPUT, true);
        Assert.Equal(9, sut.AntinodeCount);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new AntinodeMap(SAMPLE_INPUT, true);
        Assert.Equal(34, sut.AntinodeCount);
    }
}