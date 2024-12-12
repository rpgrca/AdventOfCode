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
                Assert.Equal(7, p1.Perimeter);
            },
            p2 => {
                Assert.Equal('B', p2.Plant);
                Assert.Equal(1, p2.Area);
                Assert.Equal(4, p2.Perimeter);
            });
    }
}