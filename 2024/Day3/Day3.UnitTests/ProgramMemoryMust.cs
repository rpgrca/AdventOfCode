using Day3.Logic;
using static Day3.UnitTests.Constants;

namespace Day3.UnitTests;

public class ProgramMemoryMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 71)]
    [InlineData(PUZZLE_INPUT, 20187)]
    public void LoadDataCorrectly(string input, int expectedLength)
    {
        var sut = new ProgramMemory(input);
        Assert.Equal(expectedLength, sut.Length);
    }
}