using Day3.Logic;
using static Day3.UnitTests.Constants;

namespace Day3.UnitTests;

public class EngineSchematicMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 10)]
    [InlineData(PUZZLE_INPUT, 140)]
    public void LoadInputCorrectly(string input, int expectedValue)
    {
        var sut = new EngineSchematic(input);
        Assert.Equal(expectedValue, sut.Width);
        Assert.Equal(expectedValue, sut.Height);
    }

    [Theory]
    [InlineData(@"467..114..
...*......", 467)]
    [InlineData(@"617*......
.....+.58.
..592.....", 1209)]
    [InlineData(@".........
.150*693.
.........", 843)]
    [InlineData(@"..........
.../192...
.........+", 192)]
    [InlineData(@"........
......99
.359....
.....922
&.......", 0)]
    [InlineData(@".....*........
.40.347...640.
..............", 347)]
    [InlineData("1......\n.......\n.......", 0)]
    [InlineData("1......\n=......\n.......", 1)]
    [InlineData("1......\n.=.....\n.......", 1)]
    [InlineData(".1.....\n.......\n.......", 0)]
    [InlineData(".1.....\n=......\n.......", 1)]
    [InlineData(".1.....\n.=.....\n.......", 1)]
    [InlineData(".1.....\n..=....\n.......", 1)]
    [InlineData("......1\n.......\n.......", 0)]
    [InlineData("......1\n.....=.\n.......", 1)]
    public void CalculateSumOfPartsCorrectly(string input, int expectedSum)
    {
        var sut = new EngineSchematic(input);
        Assert.Equal(expectedSum, sut.SumOfParts);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new EngineSchematic(SAMPLE_INPUT);
        Assert.Equal(4361, sut.SumOfParts);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new EngineSchematic(PUZZLE_INPUT);
        Assert.True(506273 < sut.SumOfParts);
        Assert.Equal(507214, sut.SumOfParts);
    }

    [Theory]
    [InlineData("111*3", 333)]
    [InlineData("111*111", 12321, Skip = "case not found in test samples")]
    [InlineData("186.48\n...*..", 8928)]
    public void CalculateSumOfGearRatiosCorrectly(string input, int expectedValue)
    {
        var sut = new EngineSchematic(input);
        Assert.Equal(expectedValue, sut.SumOfGearRatios);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new EngineSchematic(SAMPLE_INPUT);
        Assert.Equal(467835, sut.SumOfGearRatios);
    }

    [Fact]
    public void SolveSecondPuzzle()
    {
        var sut = new EngineSchematic(PUZZLE_INPUT);
        Assert.True(85767650 > sut.SumOfGearRatios);
        Assert.Equal(72553319, sut.SumOfGearRatios);
    }
}