using Day21.Logic;

namespace Day21.UnitTests;

public class KeypadTypingMust
{
    [Theory]
    [InlineData('A', '0', "<A>A")]
    [InlineData('A', '1', "^<<A>>vA")]
    public void CalculateShortestPathInNumericKeypad(char start, char end, string expectedSequence)
    {
        var sut = KeypadTyping.CreateNumericKeypad();
        var result = sut.CalculateShortestSequence(start, $"{end}A");
        Assert.Equal(expectedSequence, result);
    }

    [Fact]
    public void CalculateShortestSequenceFor029ACorrectly()
    {
        var sut = KeypadTyping.CreateNumericKeypad();
        var result = sut.CalculateShortestSequence('A', "029A");
        Assert.Equal("<A^A>^^AvvvA", result);
    }

    [Theory]
    [InlineData('A', '<', "v<<A>>^A")]
    public void CalculateShortestPathInDirectionalPath(char start, char end, string expectedSequence)
    {
        var sut = KeypadTyping.CreateDirectionalKeypad();
        var result = sut.CalculateShortestSequence(start, $"{end}A");
        Assert.Equal(expectedSequence, result);
    }

    [Fact]
    public void CalculateShortestPathInDirectionalAndNumericKeypads()
    {
        var sut = new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        });

        var result = sut.CalculateShortestSequence('A', "029A");
        Assert.Equal("v<<A>>^A<A>AvA<^AA>A<vAAA>^A", result);
    }
}