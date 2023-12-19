using Day18.Logic;
using static Day18.UnitTests.Constants;

namespace Day18.UnitTests;

public class LavaductLagoonMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 14)]
    [InlineData(PUZZLE_INPUT, 728)]
    public void LoadInputCorrectly(string input, int expectedLength)
    {
        var sut = new LavaductLagoon(input);
        Assert.Equal(expectedLength, sut.DigPlanLength);
    }

    [Theory]
    [InlineData("R 1 (#70c710)", 1)]
    [InlineData("R 5 (#70c710)\nD 5 (#70c710)\nL 5 (#70c710)\nU 5 (#70c710)", 20)]
    [InlineData(SAMPLE_INPUT, 38)]
    [InlineData(PUZZLE_INPUT, 3770)]
    public void CalculatePerimeterCorrectly(string input, int expectedPerimeter)
    {
        var sut = new LavaductLagoon(input, 700);
        sut.Dig();
        sut.CalculatePerimeter();
        Assert.Equal(expectedPerimeter, sut.TrenchPerimeter);
    }

    [Theory]
    [InlineData("R 5 (#70c710)\nD 5 (#70c710)\nL 5 (#70c710)\nU 5 (#70c710)", 36)]
    public void CalculateAreaCorrectly(string input, int expectedArea)
    {
        var sut = new LavaductLagoon(input, 80);
        sut.Dig();
        sut.CalculateArea();
        Assert.Equal(expectedArea, sut.TrenchArea);
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new LavaductLagoon(SAMPLE_INPUT, 80);
        sut.Dig();
        sut.CalculateArea();
        Assert.Equal(62, sut.TrenchArea);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new LavaductLagoon(PUZZLE_INPUT, 700);
        sut.Dig();
        sut.CalculateArea();
        Assert.Equal(48400, sut.TrenchArea);
    }

    [Theory]
    [InlineData("R 6 (#70c710)", 'R', 461937)]
    [InlineData("D 5 (#0dc571)", 'D', 56407)]
    [InlineData("L 2 (#5713f0)", 'R', 356671)]
    [InlineData("D 2 (#d2c081)", 'D', 863240)]
    [InlineData("R 2 (#59c680)", 'R', 367720)]
    [InlineData("D 2 (#411b91)", 'D', 266681)]
    [InlineData("L 5 (#8ceee2)", 'L', 577262)]
    [InlineData("U 2 (#caa173)", 'U', 829975)]
    [InlineData("L 1 (#1b58a2)", 'L', 112010)]
    [InlineData("U 2 (#caa171)", 'D', 829975)]
    [InlineData("R 2 (#7807d2)", 'L', 491645)]
    [InlineData("U 3 (#a77fa3)", 'U', 686074)]
    [InlineData("L 2 (#015232)", 'L', 5411)]
    [InlineData("U 2 (#7a21e3)", 'U', 500254)]
    public void DecodeColorsCorrectly(string input, char expectedDirection, int expectedLength)
    {
        var sut = new LavaductLagoon(input, create: false);
        sut.Decode();
        Assert.Collection(sut.RealInstructions,
            i1 => {
                Assert.Equal(expectedLength, i1.Length);
                Assert.Equal(expectedDirection, i1.Direction);
            });
    }

    [Fact]
    public void SolveFirstSampleWithDecodingCorrectly()
    {
        var sut = new LavaductLagoon(SAMPLE_INPUT, 10_000, create: false);
        sut.CalculateArea2();
        Assert.Equal(62, sut.TrenchArea);
    }

/*
    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new LavaductLagoon(SAMPLE_INPUT, 2_500_000, create: false);
        sut.Decode();
        sut.CalculateArea2();
        Assert.Equal(952408144115, sut.TrenchArea);
    }*/
}