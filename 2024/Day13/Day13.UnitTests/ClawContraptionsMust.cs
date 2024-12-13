using Day13.Logic;
using static Day13.UnitTests.Constants;

namespace Day13.UnitTests;

public class ClawContraptionsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 4)]
    [InlineData(PUZZLE_INPUT, 320)]
    public void LoadInputCorrectly(string input, int expectedCount)
    {
        var sut = new ClawContraptions(input);
        Assert.Equal(expectedCount, sut.Count);
    }

    [Fact]
    public void ParseInputCorrectly()
    {
        var sut = new ClawContraptions(SAMPLE_INPUT);
        Assert.Collection(sut.Contraptions,
            p1 => {
                Assert.Equal((94, 34), p1.A);
                Assert.Equal((22, 67), p1.B);
                Assert.Equal((8400, 5400), p1.Prize);
            },
            p2 => {
                Assert.Equal((26, 66), p2.A);
                Assert.Equal((67, 21), p2.B);
                Assert.Equal((12748, 12176), p2.Prize);
            },
            p3 => {
                Assert.Equal((17, 86), p3.A);
                Assert.Equal((84, 37), p3.B);
                Assert.Equal((7870, 6450), p3.Prize);
            },
            p1 => {
                Assert.Equal((69, 23), p1.A);
                Assert.Equal((27, 71), p1.B);
                Assert.Equal((18641, 10279), p1.Prize);
            });
    }

    [Theory]
    [InlineData("Button A: X+94, Y+34\nButton B: X+22, Y+67\nPrize: X=8400, Y=5400", 280)]
    [InlineData("Button A: X+17, Y+86\nButton B: X+84, Y+37\nPrize: X=7870, Y=6450", 200)]
    public void FindBestCombination(string input, long expectedWin)
    {
        var sut = new ClawContraptions(input);
        Assert.Equal(expectedWin, sut.CheapestWin);
    }

    [Theory]
    [InlineData("Button A: X+26, Y+66\nButton B: X+67, Y+21\nPrize: X=12748, Y=12176")]
    [InlineData("Button A: X+69, Y+23\nButton B: X+27, Y+71\nPrize: X=18641, Y=10279")]
    public void ReturnZero_WhenNoCombinationHasBeenFound(string input)
    {
        var sut = new ClawContraptions(input);
        Assert.Equal(0, sut.CheapestWin);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new ClawContraptions(SAMPLE_INPUT);
        Assert.Equal(480, sut.CheapestWin);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new ClawContraptions(PUZZLE_INPUT);
        Assert.Equal(28059, sut.CheapestWin);
    }

    [Fact]
    public void ParseAdjustedInputCorrectly()
    {
        var sut = new ClawContraptions(SAMPLE_INPUT, 10000000000000);
        Assert.Collection(sut.Contraptions,
            p1 => {
                Assert.Equal((94, 34), p1.A);
                Assert.Equal((22, 67), p1.B);
                Assert.Equal((10000000008400, 10000000005400), p1.Prize);
            },
            p2 => {
                Assert.Equal((26, 66), p2.A);
                Assert.Equal((67, 21), p2.B);
                Assert.Equal((10000000012748, 10000000012176), p2.Prize);
            },
            p3 => {
                Assert.Equal((17, 86), p3.A);
                Assert.Equal((84, 37), p3.B);
                Assert.Equal((10000000007870, 10000000006450), p3.Prize);
            },
            p1 => {
                Assert.Equal((69, 23), p1.A);
                Assert.Equal((27, 71), p1.B);
                Assert.Equal((10000000018641, 10000000010279), p1.Prize);
            });
    }

    [Theory]
    [InlineData("Button A: X+94, Y+34\nButton B: X+22, Y+67\nPrize: X=8400, Y=5400")]
    [InlineData("Button A: X+17, Y+86\nButton B: X+84, Y+37\nPrize: X=7870, Y=6450")]
    public void ReturnZero_WhenAdjustedNoCombinationHasBeenFound(string input)
    {
        var sut = new ClawContraptions(input, 10000000000000);
        Assert.Equal(0, sut.CheapestWin);
    }

    [Theory]
    [InlineData("Button A: X+26, Y+66\nButton B: X+67, Y+21\nPrize: X=12748, Y=12176", 459236326669)]
    [InlineData("Button A: X+69, Y+23\nButton B: X+27, Y+71\nPrize: X=18641, Y=10279", 416082282239)]
    public void FindBestCombination_WhenAdjustingInput(string input, long expectedWin)
    {
        var sut = new ClawContraptions(input, 10000000000000);
        Assert.Equal(expectedWin, sut.CheapestWin);
    }

    [Fact]
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = new ClawContraptions(PUZZLE_INPUT, 10000000000000);
        Assert.Equal(102255878088512, sut.CheapestWin);
    }
}