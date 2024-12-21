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

    [Theory]
    [InlineData("029A", 12 * 29)]
    public void CalculateShortestSequenceFor029ACorrectly(string input, int expectedSum)
    {
        var sut = new KeypadConundrum(input, KeypadTyping.CreateNumericKeypad());
        Assert.Equal(expectedSum, sut.SumOfComplexities);
    }

    [Theory]
    [InlineData("029A", 28 * 29)]
    public void CalculateShortestSequenceForTwoKeypads(string input, int expectedSum)
    {
        var sut = new KeypadConundrum(input, new CombinedKeypadTyping(new() {
             KeypadTyping.CreateNumericKeypad(),
             KeypadTyping.CreateDirectionalKeypad()
        }));

        Assert.Equal(expectedSum, sut.SumOfComplexities);
    }

    [Theory]
    [InlineData("029A", 68 * 29)]
    [InlineData("980A", 60 * 980)]
    [InlineData("179A", 68 * 179)]
    [InlineData("456A", 64 * 456)]
    [InlineData("379A", 64 * 379)]
    public void CalculateShortestSequenceForThreeKeypads(string input, int expectedSum)
    {
        var sut = new KeypadConundrum(input, new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        }));

        Assert.Equal(expectedSum, sut.SumOfComplexities);
    }
}
