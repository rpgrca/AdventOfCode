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
    [InlineData("029A", false, 12 * 29)]
    [InlineData("029A", true, 12 * 29)]
    public void CalculateShortestSequenceFor029ACorrectly(string input, bool onlySum, int expectedSum)
    {
        var sut = new KeypadConundrum(input, KeypadTyping.CreateNumericKeypad(), onlySum);
        Assert.Equal(expectedSum, sut.SumOfComplexities);
    }

    [Theory]
    [InlineData("029A", false, 28 * 29)]
    [InlineData("029A", true, 28 * 29)]
    public void CalculateShortestSequenceForTwoKeypads(string input, bool onlySum, int expectedSum)
    {
        var sut = new KeypadConundrum(input, new CombinedKeypadTyping(new() {
             KeypadTyping.CreateNumericKeypad(),
             KeypadTyping.CreateDirectionalKeypad()
        }), onlySum);

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
        }), true);

        Assert.Equal(expectedSum, sut.SumOfComplexities);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new KeypadConundrum(SAMPLE_INPUT, new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        }));

        Assert.Equal(126384, sut.SumOfComplexities);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new KeypadConundrum(PUZZLE_INPUT, new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        }));

        Assert.True(137420 > sut.SumOfComplexities);
        Assert.Equal(134120, sut.SumOfComplexities);
    }

    [Fact]
    public void SolveSumOfComplexities_WhenThereAre3DirectionalKeypads()
    {
        var sut = new KeypadConundrum(PUZZLE_INPUT, new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        }));

        Assert.Equal(335394, sut.SumOfComplexities);
    }

    [Fact]
    public void SolveSumOfComplexities_WhenThereAre4DirectionalKeypads()
    {
        var sut = new KeypadConundrum(PUZZLE_INPUT, new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        }));

        Assert.Equal(818240, sut.SumOfComplexities);
    }

    [Fact]
    public void SolveSumOfComplexities_WhenThereAre5DirectionalKeypads()
    {
        var sut = new KeypadConundrum(PUZZLE_INPUT, new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        }));

        Assert.Equal(2042304, sut.SumOfComplexities);
    }

    [Fact]
    public void SolveSumOfComplexities_WhenThereAre6DirectionalKeypads()
    {
        var sut = new KeypadConundrum(PUZZLE_INPUT, new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        }));

        Assert.Equal(5051610, sut.SumOfComplexities);
    }

    [Fact]
    public void SolveSumOfComplexities_WhenThereAre7DirectionalKeypads()
    {
        var sut = new KeypadConundrum(PUZZLE_INPUT, new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        }));

        Assert.Equal(12589980, sut.SumOfComplexities);
    }

    [Fact]
    public void SolveSumOfComplexities_WhenThereAre8DirectionalKeypads()
    {
        var sut = new KeypadConundrum(PUZZLE_INPUT, new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        }));

        Assert.Equal(31283240, sut.SumOfComplexities);
    }

    [Fact]
    public void SolveSumOfComplexities_WhenThereAre9DirectionalKeypads()
    {
        var sut = new KeypadConundrum(PUZZLE_INPUT, new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        }));

        Assert.Equal(77841448, sut.SumOfComplexities);
    }

    [Fact(Skip = "9 seconds")]
    public void SolveSumOfComplexities_WhenThereAre10DirectionalKeypads()
    {
        var sut = new KeypadConundrum(PUZZLE_INPUT, new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        }));

        Assert.Equal(193631162, sut.SumOfComplexities);
    }

    /*[Fact]
    public void RepeatTypingCorrectly()
    {
        var sut = new KeypadConundrum("0A", new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        }));

        Assert.Equal(0, sut.SumOfComplexities);
    }*/

/*
    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = new KeypadConundrum(PUZZLE_INPUT, new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        }));

        Assert.Equal(0, sut.SumOfComplexities);
    }*/
}
