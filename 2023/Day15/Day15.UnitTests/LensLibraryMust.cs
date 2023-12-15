using Day15.Logic;
using static Day15.UnitTests.Constants;

namespace Day15.UnitTests;

public class LensLibraryMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 11)]
    [InlineData(PUZZLE_INPUT, 4000)]
    public void ParseInputCorrectly(string input, int expectedCount)
    {
        var sut = new LensLibrary(input);
        Assert.Equal(expectedCount, sut.SequenceCount);
    }

    [Theory]
    [InlineData("HASH", 52)]
    [InlineData("rn=1", 30)]
    [InlineData("cm-", 253)]
    [InlineData("qp=3", 97)]
    [InlineData("cm=2", 47)]
    [InlineData("qp-", 14)]
    [InlineData("pc=4", 180)]
    [InlineData("ot=9", 9)]
    [InlineData("ab=5", 197)]
    [InlineData("pc-", 48)]
    [InlineData("pc=6", 214)]
    [InlineData("ot=7", 231)]
    public void CalculateHashCorrectly(string input, int expectedSumOfHashes)
    {
        var sut = new LensLibrary(input);
        Assert.Equal(expectedSumOfHashes, sut.SumOfHashes);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new LensLibrary(SAMPLE_INPUT);
        Assert.Equal(1320, sut.SumOfHashes);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new LensLibrary(PUZZLE_INPUT);
        Assert.Equal(515495, sut.SumOfHashes);
    }


}