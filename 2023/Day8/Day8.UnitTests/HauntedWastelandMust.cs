using System.Runtime.Intrinsics.Arm;
using Day8.Logic;
using static Day8.UnitTests.Constants;

namespace Day8.UnitTests;

public class HauntedWastelandMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 2, 7)]
    [InlineData(PUZZLE_INPUT, 271, 798)]
    public void LoadInputCorrectly(string input, int expectedInstructions, int expectedStates)
    {
        var sut = new HauntedWasteland(input);
        Assert.Equal(expectedInstructions, sut.InstructionCount);
        Assert.Equal(expectedStates, sut.StateCount);
    }

    [Fact]
    public void ObtainInstructionsFromSampleCorrectly()
    {
        var sut = new HauntedWasteland(SAMPLE_INPUT);
        Assert.Collection(sut.Instructions,
            p1 => Assert.Equal('R', p1),
            p2 => Assert.Equal('L', p2));
    }

    [Fact]
    public void ObtainStepsFromSampleCorrectly()
    {
        var sut = new HauntedWasteland(SAMPLE_INPUT);
        Assert.Collection(sut.Steps,
            s1 => {
                Assert.Equal("AAA", s1.Key);
                Assert.Equal("BBB", s1.Value['L']);
                Assert.Equal("CCC", s1.Value['R']);
            },
            s2 => {
                Assert.Equal("BBB", s2.Key);
                Assert.Equal("DDD", s2.Value['L']);
                Assert.Equal("EEE", s2.Value['R']);
            },
            s3 => {
                Assert.Equal("CCC", s3.Key);
                Assert.Equal("ZZZ", s3.Value['L']);
                Assert.Equal("GGG", s3.Value['R']);
            },
            s4 => {
                Assert.Equal("DDD", s4.Key);
                Assert.Equal("DDD", s4.Value['L']);
                Assert.Equal("DDD", s4.Value['R']);
            },
            s5 => {
                Assert.Equal("EEE", s5.Key);
                Assert.Equal("EEE", s5.Value['L']);
                Assert.Equal("EEE", s5.Value['R']);
            },
            s6 => {
                Assert.Equal("GGG", s6.Key);
                Assert.Equal("GGG", s6.Value['L']);
                Assert.Equal("GGG", s6.Value['R']);
            },
            s7 => {
                Assert.Equal("ZZZ", s7.Key);
                Assert.Equal("ZZZ", s7.Value['L']);
                Assert.Equal("ZZZ", s7.Value['R']);
            });
    }
}