using Day19.Logic;
using static Day19.UnitTests.Constants;

namespace Day19.UnitTests;

public class AplentyMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 11, 5)]
    [InlineData(PUZZLE_INPUT, 587, 200)]
    public void LoadDataCorrectly(string input, int expectedRuleCount, int expectedPartCount)
    {
        var sut = new Aplenty(input);
        Assert.Equal(expectedRuleCount, sut.RuleCount);
        Assert.Equal(expectedPartCount, sut.PartCount);
    }

    [Theory]
    [InlineData("ex{x>10:one,m<20:two,a>30:R,A}", "ex", 4)]
    [InlineData("px{a<2006:qkq,m>2090:A,rfg}", "px", 3)]
    [InlineData("pv{a>1716:R,A}", "pv", 2)]
    [InlineData("lnx{m>1548:A,A}", "lnx", 2)]
    [InlineData("rfg{s<537:gd,x>2440:R,A}", "rfg", 3)]
    [InlineData("qs{s>3448:A,lnx}", "qs", 2)]
    [InlineData("qkq{x<1416:A,crn}", "qkq", 2)]
    [InlineData("crn{x>2662:A,R}", "crn", 2)]
    [InlineData("in{s<1351:px,qqz}", "in", 2)]
    [InlineData("qqz{s>2770:qs,m<1801:hdj,R}", "qqz", 3)]
    [InlineData("gd{a>3333:R,R}", "gd", 2)]
    [InlineData("hdj{m>838:A,pv}", "hdj", 2)]
    public void ParseInputCorrectly(string input, string expectedName, int expectedFilterCount)
    {
        var sut = new Rule(input);
        Assert.Equal(expectedName, sut.Name);
        Assert.Equal(expectedFilterCount, sut.ExpectedFilterCount);
    }
}