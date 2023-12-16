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
        Assert.Collection(sut.EnergizedMap,
            l1 => Assert.Equal("#####", l1));
    }

    [Fact]
    public void TransverseCorrectly_WhenMapHasTwoEmptyDimensions()
    {
        var sut = new TheFloorWillBeLava(".....\n.....\n.....\n.....\n.....");
        sut.Energize();
        Assert.Collection(sut.EnergizedMap,
            l1 => Assert.Equal("#####", l1),
            l2 => Assert.Equal(".....", l2),
            l3 => Assert.Equal(".....", l3),
            l4 => Assert.Equal(".....", l4),
            l5 => Assert.Equal(".....", l5)
        );
    }
}