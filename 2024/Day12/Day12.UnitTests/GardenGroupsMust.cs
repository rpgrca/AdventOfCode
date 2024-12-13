using Day12.Logic;
using static Day12.UnitTests.Constants;

namespace Day12.UnitTests;

public class GardenGroupsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 4)]
    [InlineData(SECOND_SAMPLE_INPUT, 5)]
    [InlineData(THIRD_SAMPLE_INPUT, 10)]
    [InlineData(PUZZLE_INPUT, 140)]
    public void LoadInputCorrectly(string input, int expectedSize)
    {
        var sut = new GardenGroups(input);
        Assert.Equal(expectedSize, sut.Size);
    }

    [Fact]
    public void DivideIntoPlotsCorrectly_WhenPlotIs1x1()
    {
        var sut = new GardenGroups("A");
        Assert.Collection(sut.Plots,
            p1 => {
                Assert.Equal('A', p1.Plant);
                Assert.Equal(1, p1.Area);
                Assert.Equal(4, p1.Perimeter);
            });
    }

    [Fact]
    public void DivideIntoPlotsCorrectly_WhenPlotIs2x2()
    {
        var sut = new GardenGroups("AA\nAB");
        Assert.Collection(sut.Plots,
            p1 => {
                Assert.Equal('A', p1.Plant);
                Assert.Equal(3, p1.Area);
                Assert.Equal(8, p1.Perimeter);
            },
            p2 => {
                Assert.Equal('B', p2.Plant);
                Assert.Equal(1, p2.Area);
                Assert.Equal(4, p2.Perimeter);
            });
    }

    [Fact]
    public void DivideIntoPlotsCorrectly_WhenUsingSample()
    {
        var sut = new GardenGroups(SAMPLE_INPUT);
        Assert.Collection(sut.Plots,
            p1 => {
                Assert.Equal('A', p1.Plant);
                Assert.Equal(4, p1.Area);
                Assert.Equal(10, p1.Perimeter);
            },
            p2 => {
                Assert.Equal('B', p2.Plant);
                Assert.Equal(4, p2.Area);
                Assert.Equal(8, p2.Perimeter);
            },
            p3 => {
                Assert.Equal('C', p3.Plant);
                Assert.Equal(4, p3.Area);
                Assert.Equal(10, p3.Perimeter);
            },
            p4 => {
                Assert.Equal('D', p4.Plant);
                Assert.Equal(1, p4.Area);
                Assert.Equal(4, p4.Perimeter);
            },
            p5 => {
                Assert.Equal('E', p5.Plant);
                Assert.Equal(3, p5.Area);
                Assert.Equal(8, p5.Perimeter);
            });
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 140)]
    [InlineData(SECOND_SAMPLE_INPUT, 772)]
    [InlineData(THIRD_SAMPLE_INPUT, 1930)]
    public void CalculatePriceOfFencingCorrectly(string input, int expectedPrice)
    {
        var sut = new GardenGroups(input);
        Assert.Equal(expectedPrice, sut.PriceOfFencing);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new GardenGroups(PUZZLE_INPUT);
        Assert.Equal(1400386, sut.PriceOfFencing);
    }

    [Theory]
    [InlineData("AA\nAA", 16)]
    [InlineData(SAMPLE_INPUT, 80)]
    [InlineData(SECOND_SAMPLE_INPUT, 436)]
    public void ZoomInCorrectly(string input, int expectedPrice)
    {
        var sut = new GardenGroups(input, 3);
        Assert.Equal(expectedPrice, sut.PriceWithBulkDiscount);
/*
        Assert.Collection(sut.Plots,
            p1 => {
                Assert.Equal('A', p1.Plant);
                Assert.Equal(50, p1.Perimeter);
            },
            p2 => {
                Assert.Equal('B', p2.Plant);
                Assert.Equal(40, p2.Perimeter);
            },
            p3 => {
                Assert.Equal('C', p3.Plant);
                Assert.Equal(40, p3.Perimeter);
            },
            p4 => {
                Assert.Equal('D', p4.Plant);
                Assert.Equal(20, p4.Perimeter);
            },
            p5 => {
                Assert.Equal('E', p5.Plant);
                Assert.Equal(40, p5.Perimeter);
            });*/
    }
}