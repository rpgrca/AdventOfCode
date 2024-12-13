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
                Assert.Equal((94, 34), p1.ButtonA);
                Assert.Equal((22, 67), p1.ButtonB);
                Assert.Equal((8400, 5400), p1.Prize);
            },
            p2 => {
                Assert.Equal((26, 66), p2.ButtonA);
                Assert.Equal((67, 21), p2.ButtonB);
                Assert.Equal((12748, 12176), p2.Prize);
            },
            p3 => {
                Assert.Equal((17, 86), p3.ButtonA);
                Assert.Equal((84, 37), p3.ButtonB);
                Assert.Equal((7870, 6450), p3.Prize);
            },
            p1 => {
                Assert.Equal((69, 23), p1.ButtonA);
                Assert.Equal((27, 71), p1.ButtonB);
                Assert.Equal((18641, 10279), p1.Prize);
            });
    }

    [Theory]
    [InlineData("Button A: X+94, Y+34\nButton B: X+22, Y+67\nPrize: X=8400, Y=5400", 280)]
    [InlineData("Button A: X+17, Y+86\nButton B: X+84, Y+37\nPrize: X=7870, Y=6450", 200)]
    public void FindBestCombination(string input, int expectedWin)
    {
        var sut = new ClawContraptions(input);
        Assert.Equal(expectedWin, sut.CheapestWin);
    }
}