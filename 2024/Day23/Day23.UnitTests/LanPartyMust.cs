using Day23.Logic;
using static Day23.UnitTests.Constants;

namespace Day23.UnitTests;

public class LanPartyMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 32)]
    [InlineData(PUZZLE_INPUT, 3380)]
    public void LoadInputCorrectly(string input, int expectedCount)
    {
        var sut = new LanParty(input);
        Assert.Equal(expectedCount, sut.Count);
    }

    [Fact]
    public void FindThreeComputerPartiesCorrectly()
    {
        var sut = new LanParty(SAMPLE_INPUT);
        var list = sut.FindPartiesOf(3);
        Assert.Collection(list,
            p1 => Assert.Equal("aq,cg,yn", p1),
            p1 => Assert.Equal("aq,vc,wq", p1),
            p1 => Assert.Equal("co,de,ka", p1),
            p1 => Assert.Equal("co,de,ta", p1),
            p1 => Assert.Equal("co,ka,ta", p1),
            p1 => Assert.Equal("de,ka,ta", p1),
            p1 => Assert.Equal("kh,qp,ub", p1),
            p1 => Assert.Equal("qp,td,wh", p1),
            p1 => Assert.Equal("tb,vc,wq", p1),
            p1 => Assert.Equal("tc,td,wh", p1),
            p1 => Assert.Equal("td,wh,yn", p1),
            p1 => Assert.Equal("ub,vc,wq", p1));
    }
}