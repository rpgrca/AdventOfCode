using Day9.Logic;
using static Day9.UnitTests.Constants;

namespace Day9.UnitTests;

public class DiskFragmenterMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 19)]
    [InlineData(SECOND_SAMPLE_INPUT, 5)]
    [InlineData(PUZZLE_INPUT, 19999)]
    public void LoadInputCorrectly(string input, int expectedLength)
    {
        var sut = new DiskFragmenter(input);
        Assert.Equal(expectedLength, sut.Length);
    }
}