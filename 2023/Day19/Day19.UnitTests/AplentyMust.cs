using System.Security;
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

    [Theory]
    [InlineData("{x=787,m=2655,a=1222,s=2876}", 787, 2655, 1222, 2876)]
    [InlineData("{x=1679,m=44,a=2067,s=496}", 1679, 44, 2067, 496)]
    [InlineData("{x=2036,m=264,a=79,s=2244}", 2036, 264, 79, 2244)]
    [InlineData("{x=2461,m=1339,a=466,s=291}", 2461, 1339, 466, 291)]
    [InlineData("{x=2127,m=1623,a=2188,s=1013}", 2127, 1623, 2188, 1013)]
    public void ParsePartCorrectly(string input, int expectedX, int expectedM, int expectedA, int expectedS)
    {
        var sut = new Part(input);
        Assert.Equal(expectedX, sut.X);
        Assert.Equal(expectedM, sut.M);
        Assert.Equal(expectedA, sut.A);
        Assert.Equal(expectedS, sut.S);
    }

    [Theory]
    [InlineData(@"px{a<2006:qkq,m>2090:A,rfg}
pv{a>1716:R,A}
lnx{m>1548:A,A}
rfg{s<537:gd,x>2440:R,A}
qs{s>3448:A,lnx}
qkq{x<1416:A,crn}
crn{x>2662:A,R}
in{s<1351:px,qqz}
qqz{s>2770:qs,m<1801:hdj,R}
gd{a>3333:R,R}
hdj{m>838:A,pv}

{x=787,m=2655,a=1222,s=2876}", 7540)]
    [InlineData(@"px{a<2006:qkq,m>2090:A,rfg}
pv{a>1716:R,A}
lnx{m>1548:A,A}
rfg{s<537:gd,x>2440:R,A}
qs{s>3448:A,lnx}
qkq{x<1416:A,crn}
crn{x>2662:A,R}
in{s<1351:px,qqz}
qqz{s>2770:qs,m<1801:hdj,R}
gd{a>3333:R,R}
hdj{m>838:A,pv}

{x=1679,m=44,a=2067,s=496}", 0)]
    public void ExecuteWorkflowCorrectly(string input, int expectedSum)
    {
        var sut = new Aplenty(input);
        sut.Execute();
        Assert.Equal(expectedSum, sut.SumOfAcceptedParts);
    }
}