using Day21.Logic;
using static Day21.UnitTests.Constants;

namespace Day21.UnitTests;

public class KeypadConundrumMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 29, 980, 179, 456, 379)]
    [InlineData(PUZZLE_INPUT, 789, 540, 285, 140, 189)]
    public void LoadInputCorrectly(string input, int expectedA, int expectedB, int expectedC, int expectedD, int expectedE)
    {
        var sut = new KeypadConundrum(input, KeypadTyping.CreateNumericKeypad());
        Assert.Collection(sut.Codes,
            p1 => Assert.Equal(expectedA, p1),
            p2 => Assert.Equal(expectedB, p2),
            p3 => Assert.Equal(expectedC, p3),
            p4 => Assert.Equal(expectedD, p4),
            p5 => Assert.Equal(expectedE, p5));
    }

    [Fact]
    public void CalculateShortestSequenceFor029ACorrectly()
    {
        var sut = new KeypadConundrum("029A", KeypadTyping.CreateNumericKeypad());
        Assert.Equal(12 * 29, sut.SumOfComplexities);
    }

    [Fact]
    public void CalculateShortestSequenceForTwoKeypads()
    {
        var sut = new KeypadConundrum("029A", new CombinedKeypadTyping(new() {
             KeypadTyping.CreateNumericKeypad(),
             KeypadTyping.CreateDirectionalKeypad()
        }));
        //Assert.Equal()
    }
}
