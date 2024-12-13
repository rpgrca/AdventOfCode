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
                Assert.Equal((94UL, 34UL), p1.ButtonA);
                Assert.Equal((22UL, 67UL), p1.ButtonB);
                Assert.Equal((8400UL, 5400UL), p1.Prize);
            },
            p2 => {
                Assert.Equal((26UL, 66UL), p2.ButtonA);
                Assert.Equal((67UL, 21UL), p2.ButtonB);
                Assert.Equal((12748UL, 12176UL), p2.Prize);
            },
            p3 => {
                Assert.Equal((17UL, 86UL), p3.ButtonA);
                Assert.Equal((84UL, 37UL), p3.ButtonB);
                Assert.Equal((7870UL, 6450UL), p3.Prize);
            },
            p1 => {
                Assert.Equal((69UL, 23UL), p1.ButtonA);
                Assert.Equal((27UL, 71UL), p1.ButtonB);
                Assert.Equal((18641UL, 10279UL), p1.Prize);
            });
    }

    [Theory]
    [InlineData("Button A: X+94, Y+34\nButton B: X+22, Y+67\nPrize: X=8400, Y=5400", 280)]
    [InlineData("Button A: X+17, Y+86\nButton B: X+84, Y+37\nPrize: X=7870, Y=6450", 200)]
    public void FindBestCombination(string input, ulong expectedWin)
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
        Assert.Equal(0UL, sut.CheapestWin);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new ClawContraptions(SAMPLE_INPUT);
        Assert.Equal(480UL, sut.CheapestWin);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new ClawContraptions(PUZZLE_INPUT);
        Assert.Equal(28059UL, sut.CheapestWin);
    }

    [Fact]
    public void ParseAdjustedInputCorrectly()
    {
        var sut = new ClawContraptions(SAMPLE_INPUT, 10000000000000);
        Assert.Collection(sut.Contraptions,
            p1 => {
                Assert.Equal((94UL, 34UL), p1.ButtonA);
                Assert.Equal((22UL, 67UL), p1.ButtonB);
                Assert.Equal((10000000008400UL, 10000000005400UL), p1.Prize);
            },
            p2 => {
                Assert.Equal((26UL, 66UL), p2.ButtonA);
                Assert.Equal((67UL, 21UL), p2.ButtonB);
                Assert.Equal((10000000012748UL, 10000000012176UL), p2.Prize);
            },
            p3 => {
                Assert.Equal((17UL, 86UL), p3.ButtonA);
                Assert.Equal((84UL, 37UL), p3.ButtonB);
                Assert.Equal((10000000007870UL, 10000000006450UL), p3.Prize);
            },
            p1 => {
                Assert.Equal((69UL, 23UL), p1.ButtonA);
                Assert.Equal((27UL, 71UL), p1.ButtonB);
                Assert.Equal((10000000018641UL, 10000000010279UL), p1.Prize);
            });

    }
}