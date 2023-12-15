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
}