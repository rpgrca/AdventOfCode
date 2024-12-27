using System.Reflection;
using Day25.Logic;
using static Day25.UnitTests.Constants;

namespace Day25.UnitTests;

public class CodeChronicleMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 2, 3)]
    [InlineData(PUZZLE_INPUT, 250, 250)]
    public void LoadInputCorrectly(string input, int expectedLocks, int expectedKeys)
    {
        var sut = new CodeChronicle(input);
        Assert.Equal(expectedLocks, sut.Locks);
        Assert.Equal(expectedKeys, sut.Keys);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new CodeChronicle(SAMPLE_INPUT);
        Assert.Equal(3, sut.UniqueWorkingPairs);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new CodeChronicle(PUZZLE_INPUT);
        Assert.Equal(2835, sut.UniqueWorkingPairs);
    }
}