using Day21.Logic;

namespace Day21.UnitTests;

public class KeypadTypingMust
{
    [Theory]
    [InlineData('0', "<A>A")]
    [InlineData('1', "^<<A>>vA")]
    public void CalculateShortestPathInNumericKeypad(char end, string expectedSequence)
    {
        var sut = KeypadTyping.CreateNumericKeypad();
        var result = sut.CalculateShortestSequence($"{end}A");
        Assert.Equal(expectedSequence, result);
    }

    [Theory]
    [InlineData("029A", "<A^A>^^AvvvA")]
    [InlineData("379A", "^A<<^^A>>AvvvA")]
    public void CalculateShortestSequenceFor029ACorrectly(string input, string expectedResult)
    {
        var sut = KeypadTyping.CreateNumericKeypad();
        var result = sut.CalculateShortestSequence(input);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData('<', "v<<A>>^A")]
    public void CalculateShortestPathInDirectionalPath(char end, string expectedSequence)
    {
        var sut = KeypadTyping.CreateDirectionalKeypad();
        var result = sut.CalculateShortestSequence($"{end}A");
        Assert.Equal(expectedSequence, result);
    }

    [Theory]
    [InlineData("029A", "v<<A>>^A<A>AvA<^AA>A<vAAA>^A")]
    [InlineData("379A", "<A>Av<<AA>^AA>AvAA^A<vAAA>^A")]
    public void CalculateShortestPathInDirectionalAndNumericKeypads(string input, string expectedResult)
    {
        var sut = new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        });

        var result = sut.CalculateShortestSequence(input);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("029A", "<vA<AA>>^AvAA<^A>A<v<A>>^AvA^A<vA>^A<v<A>^A>AAvA^A<v<A>A>^AAAvA<^A>A")]
    [InlineData("379A", "v<<A>>^AvA^A<vA<AA>>^AAvA<^A>AAvA^A<vA>^AA<A>Av<<A>A>^AAAvA<^A>A")]
    public void CalculateShortestPathInDirectionalx2AndNumericKeypads(string input, string expectedResult)
    {
        var sut = new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        });

        var result = sut.CalculateShortestSequence(input);
        Assert.Equal(expectedResult.Length, result.Length);
    }
}