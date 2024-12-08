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
        var sut = new AntinodeMap(input);
        Assert.Equal(expectedSize, sut.Size);
    }
}