using Day6.Logic;
using static Day6.UnitTests.Constants;

namespace Day6.UnitTests;

public class ToyBoatMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 3)]
    [InlineData(PUZZLE_INPUT, 4)]
    public void LoadInputCorrectly(string input, int expectedRaces)
    {
        var sut = new ToyBoat(input);
        Assert.Equal(expectedRaces, sut.RaceCount);
    }
}