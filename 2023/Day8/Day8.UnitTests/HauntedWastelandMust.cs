using Day8.Logic;
using static Day8.UnitTests.Constants;

namespace Day8.UnitTests;

public class HauntedWastelandMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 2, 7)]
    [InlineData(PUZZLE_INPUT, 271, 798)]
    public void LoadInputCorrectly(string input, int expectedInstructions, int expectedStates)
    {
        var sut = new HauntedWasteland(input);
        Assert.Equal(expectedInstructions, sut.InstructionCount);
        Assert.Equal(expectedStates, sut.StateCount);
    }
}