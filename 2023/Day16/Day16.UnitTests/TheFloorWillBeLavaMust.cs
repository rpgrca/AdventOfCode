using Day16.Logic;
using static Day16.UnitTests.Constants;

namespace Day16.UnitTests;

public class TheFloorWillBeLavaMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 10, 10)]
    [InlineData(PUZZLE_INPUT, 110, 110)]
    public void LoadInputCorrectly(string input, int expectedWidth, int expectedHeight)
    {
        var sut = new TheFloorWillBeLava(input);
        Assert.Equal(expectedWidth, sut.Width);
        Assert.Equal(expectedHeight, sut.Height);
    }

    [Fact]
    public void TransverseCorrectly_WhenTileIsEmpty()
    {
        var sut = new TheFloorWillBeLava(".....");
        sut.Energize();
        Assert.Equal("#####", sut.GetEnergizedMap());
    }

    [Fact]
    public void TransverseCorrectly_WhenMapHasTwoEmptyDimensions()
    {
        var sut = new TheFloorWillBeLava(".....\n.....\n.....\n.....\n.....");
        sut.Energize();
        Assert.Equal("#####\n.....\n.....\n.....\n.....", sut.GetEnergizedMap());
    }

    [Fact]
    public void BounceInvertedMirrorCorrectly_WhenHittingFromLeft()
    {
        var sut = new TheFloorWillBeLava("..\\..\n.....\n.....\n.....\n.....");
        sut.Energize();
        Assert.Equal("###..\n..#..\n..#..\n..#..\n..#..", sut.GetEnergizedMap());
    }

    [Fact]
    public void BounceInvertedMirrorCorrectly_WhenHittingFromAbove()
    {
        var sut = new TheFloorWillBeLava("..\\..\n.....\n..\\..\n.....\n.....");
        sut.Energize();
        Assert.Equal("###..\n..#..\n..###\n.....\n.....", sut.GetEnergizedMap());
    }

    [Fact]
    public void BounceInvertedMirrorCorrectly_WhenHittingFromBelow()
    {
        var sut = new TheFloorWillBeLava("....\\\n.....\n..\\..\n.....\n..\\./");
        sut.Energize();
        Assert.Equal("#####\n....#\n###.#\n..#.#\n..###", sut.GetEnergizedMap());
    }

    [Fact]
    public void BounceNormalMirrorCorrectly_WhenHittingFromLeft()
    {
        var sut = new TheFloorWillBeLava("../..\n.....\n.....\n.....\n.....");
        sut.Energize();
        Assert.Equal("###..\n.....\n.....\n.....\n.....", sut.GetEnergizedMap());
    }

    [Fact]
    public void BounceNormalMirrorCorrectly_WhenHittingFromAbove()
    {
        var sut = new TheFloorWillBeLava("..\\..\n.....\n../..\n.....\n.....");
        sut.Energize();
        Assert.Equal("###..\n..#..\n###..\n.....\n.....", sut.GetEnergizedMap());
    }

    [Fact]
    public void BounceNormalMirrorCorrectly_WhenHittingFromRight()
    {
        var sut = new TheFloorWillBeLava("..\\..\n.....\n/./..\n.....\n.....");
        sut.Energize();
        Assert.Equal("###..\n..#..\n###..\n#....\n#....", sut.GetEnergizedMap());
    }

    [Fact]
    public void BounceNormalMirrorCorrectly_WhenHittingFromBelow()
    {
        var sut = new TheFloorWillBeLava("....\\\n.....\n../..\n.....\n..\\./");
        sut.Energize();
        Assert.Equal("#####\n....#\n..###\n..#.#\n..###", sut.GetEnergizedMap());
    }

    [Fact]
    public void TransverseVerticalSplitterCorrectly_WhenHittingFromAbove()
    {
        var sut = new TheFloorWillBeLava("..|..\n.....\n..|..\n.....\n.....");
        sut.Energize();
        Assert.Equal("###..\n..#..\n..#..\n..#..\n..#..", sut.GetEnergizedMap());
    }

    [Fact]
    public void TransverseVerticalSplitterCorrectly_WhenHittingFromBelow()
    {
        var sut = new TheFloorWillBeLava("....\\\n.....\n../..\n..|..\n..\\./");
        sut.Energize();
        Assert.Equal("#####\n....#\n..###\n..#.#\n..###", sut.GetEnergizedMap());
    }

    [Fact]
    public void SplitBeamCorrectly_WhenHittingVerticalSplitterFromLeft()
    {
        var sut = new TheFloorWillBeLava("..|..\n.....\n.....\n.....\n.....");
        sut.Energize();
        Assert.Equal("###..\n..#..\n..#..\n..#..\n..#..", sut.GetEnergizedMap());
    }

    [Fact]
    public void SplitBeamCorrectly_WhenHittingVerticalSplitterFromRight()
    {
        var sut = new TheFloorWillBeLava("....\\\n.....\n\\....\n.....\n..|./");
        sut.Energize();
        Assert.Equal("#####\n..#.#\n..#.#\n..#.#\n..###", sut.GetEnergizedMap());
    }

    [Fact]
    public void TransverseHorizontalSplitterCorrectly_WhenHittingFromLeft()
    {
        var sut = new TheFloorWillBeLava("..-..\n.....\n.....\n.....\n.....");
        sut.Energize();
        Assert.Equal("#####\n.....\n.....\n.....\n.....", sut.GetEnergizedMap());
    }

    [Fact]
    public void TransverseHorizontalSplitterCorrectly_WhenHittingFromRight()
    {
        var sut = new TheFloorWillBeLava("....\\\n.....\n.-../\n.....\n.....");
        sut.Energize();
        Assert.Equal("#####\n....#\n#####\n.....\n.....", sut.GetEnergizedMap());
    }

    [Fact]
    public void SplitBeamCorrectly_WhenHittingHorizontalSplitterFromAbove()
    {
        var sut = new TheFloorWillBeLava("....\\\n.....\n....-\n.....\n.....");
        sut.Energize();
        Assert.Equal("#####\n....#\n#####\n.....\n.....", sut.GetEnergizedMap());
    }

    [Fact]
    public void SplitBeamCorrectly_WhenHittingHorizontalSplitterFromBelow()
    {
        var sut = new TheFloorWillBeLava("....\\\n.....\n-....\n.....\n\\.../");
        sut.Energize();
        Assert.Equal("#####\n....#\n#####\n#...#\n#####", sut.GetEnergizedMap());
    }

    [Fact]
    public void SplitBeamCorrectly_WhenHittingVerticalSplitterFromAbove()
    {
        var sut = new TheFloorWillBeLava("..\\..\n.....\n..-..\n.....\n.....");
        sut.Energize();
        Assert.Equal("###..\n..#..\n#####\n.....\n.....", sut.GetEnergizedMap());
    }

    [Fact]
    public void SplitBeamCorrectly_WhenHittingVerticalSplitterFromBelow()
    {
        var sut = new TheFloorWillBeLava("\\....\n.....\n..-..\n.....\n\\./..");
        sut.Energize();
        Assert.Equal("#....\n#....\n#####\n#.#..\n###..", sut.GetEnergizedMap());
    }

    [Fact]
    public void SplitBeamCorrectly_WhenHittingHorizontalSplitterFromLeft()
    {
        var sut = new TheFloorWillBeLava("\\....\n.....\n\\.|.\n.....\n......");
        sut.Energize();
        Assert.Equal("#.#..\n#.#..\n###..\n..#..\n..#..", sut.GetEnergizedMap());
    }

    [Fact]
    public void SplitBeamCorrectly_WhenHittingHorizontalSplitterFromRight()
    {
        var sut = new TheFloorWillBeLava("....\\\n.....\n..|./\n.....\n......");
        sut.Energize();
        Assert.Equal("#####\n..#.#\n..###\n..#..\n..#..", sut.GetEnergizedMap());
    }

    [Fact]
    public void SolveFirstSampleCorrectly()
    {
        var sut = new TheFloorWillBeLava(SAMPLE_INPUT);
        sut.Energize(33);
        Assert.Equal(46, sut.EnergizedTilesCount);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new TheFloorWillBeLava(PUZZLE_INPUT);
        sut.Energize(662);
        Assert.Equal(7728, sut.EnergizedTilesCount);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new TheFloorWillBeLavaScanner(SAMPLE_INPUT);
        sut.TestConfigurations();
        Assert.Equal(51, sut.BestEnergizedTilesCount);
    }
}