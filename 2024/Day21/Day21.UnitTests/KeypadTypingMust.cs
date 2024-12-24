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
    //[InlineData("029A", "<A^A>^^AvvvA")] // one of the bests for one directional, worse for +3
    [InlineData("029A", "<A^A^^>AvvvA")]
    [InlineData("379A", "^A<<^^A>>AvvvA")]
    public void CalculateShortestSequenceFor029ACorrectly(string input, string expectedResult)
    {
        var sut = KeypadTyping.CreateNumericKeypad();
        var result = sut.CalculateShortestSequence(input);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData("029A", 28 * 29)]
    public void CountShortestPathInDirectionalAndNumericKeypads(string input, int expectedResult)
    {
        var memoization = new Dictionary<string, long>();
        var sut = new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateNumericKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        });

        sut.CountShortestSequence(input, memoization);

        var shortestSequenceLength = memoization.Select(p => p.Key.Length * p.Value).Sum();
        var result = shortestSequenceLength * int.Parse(input[..^1]);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(68 * 29)]
    public void CountShortestPathInTwoDirectionalKeypads(int expectedResult)
    {
        var memoization = new Dictionary<string, long>
        {
            { "<A", 1 },
            { "^A", 1 },
            { "^^>A", 1},
            { "vvvA", 1}
        };
        var sut = new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        });

        sut.CountShortestSequence("", memoization);

        var shortestSequenceLength = memoization.Select(p => p.Key.Length * p.Value).Sum();
        var result = shortestSequenceLength * 29;
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
    [InlineData("<vA", 9)]
    [InlineData("v<A", 9)]
    [InlineData("<^A", 9)]
    [InlineData("^<A", 9)]
    [InlineData(">vA", 7)]
    [InlineData("v>A", 7)]
    [InlineData(">^A", 7)]
    [InlineData("^>A", 7)]
    [InlineData("<<^^A", 11)]
    [InlineData("^^<<A", 11)]
    [InlineData("<<^A", 10)]
    [InlineData("<^<A", 14)]
    [InlineData("^<<A", 10)]
    [InlineData("<<vA", 10)]
    [InlineData("<v<A", 12)]
    [InlineData("v<<A", 10)]
    [InlineData(">>^A", 8)]
    [InlineData(">^>A", 10)]
    [InlineData("^>>A", 8)]
    [InlineData(">>vA", 8)]
    [InlineData(">v>A", 8)]
    [InlineData("v>>A", 8)]
    [InlineData("vv<A", 10)]
    [InlineData("<vvA", 10)]
    [InlineData("vv>A", 8)]
    [InlineData(">vvA", 8)]
    [InlineData(">>vvvA", 10)]
    [InlineData(">v>vvA", 12)]
    [InlineData(">vv>vA", 12)]
    [InlineData(">vvv>A", 10)]
    [InlineData("v>>vvA", 12)]
    [InlineData("v>v>vA", 14)]
    [InlineData("v>vv>A", 12)]
    [InlineData("vv>>vA", 12)]
    [InlineData("vv>v>A", 12)]
    public void CalculateBestOption_WhenGoingFromAtoDown(string input, int expectedCount)
    {
        var sut = new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateDirectionalKeypad()
        });

        var result = sut.CalculateShortestSequence(input);
        Assert.Equal(expectedCount, result.Length);
    }

    [Theory]
    [InlineData("<vA", 21)]
    [InlineData("v<A", 25)]
    [InlineData("<^A", 21)]
    [InlineData("^<A", 25)]
    [InlineData(">vA", 21)] // 7
    [InlineData("v>A", 17)] // 7
    [InlineData(">^A", 19)] // 7
    [InlineData("^>A", 19)] // 7
    [InlineData("<<^^A", 23)]
    [InlineData("^^<<A", 27)]
    [InlineData("<<^A", 22)] // 10, 22
    [InlineData("<^<A", 34)] // 14, 34
    [InlineData("^<<A", 26)] // 10, 26
    [InlineData("<<vA", 22)] // 10, 22
    [InlineData("<v<A", 30)] // 12, 30
    [InlineData("v<<A", 26)] // 10, 26
    [InlineData(">>^A", 20)] // 8
    [InlineData(">^>A", 26)] // 10
    [InlineData("^>>A", 20)] // 8
    [InlineData(">>vA", 22)] // 8
    [InlineData(">v>A", 22)] // 8
    [InlineData("v>>A", 18)] // 8
    [InlineData("vv<A", 26)] // 10
    [InlineData("<vvA", 22)] // 10
    [InlineData("vv>A", 18)] // 8
    [InlineData(">vvA", 22)] // 8
    [InlineData(">>vvvA", 24)]
    [InlineData(">v>vvA", 34)]
    [InlineData(">vv>vA", 34)]
    [InlineData(">vvv>A", 24)]
    [InlineData("v>>vvA", 30)]
    [InlineData("v>v>vA", 40)]
    [InlineData("v>vv>A", 30)]
    [InlineData("vv>>vA", 30)]
    [InlineData("vv>v>A", 30)]
    public void CalculateBestOption_WhenGoingFromAtoDownTwice(string input, int expectedCount)
    {
        var sut = new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        });

        var result = sut.CalculateShortestSequence(input);
        Assert.Equal(expectedCount, result.Length);
    }

    [Theory]
    [InlineData("<vA", 55)]
    [InlineData("v<A", 59)]

    [InlineData("<^A", 55)]
    [InlineData("^<A", 63)]

    [InlineData(">vA", 53)] // 7, 21, 53
    [InlineData("v>A", 43)] // 7, 17, 43

    [InlineData(">^A", 47)] // 7, 19, 47
    [InlineData("^>A", 47)] // 7, 19, 47

    [InlineData("<<^A", 56)] // 10, 22
    [InlineData("<^<A", 90)] // 14, 34
    [InlineData("^<<A", 64)] // 10, 26

    [InlineData("<<vA", 56)] // 10, 22
    [InlineData("<v<A", 74)] // 12, 30
    [InlineData("v<<A", 60)] // 10, 26

    [InlineData("vv<A", 60)] // 10, 26
    [InlineData("<vvA", 56)] // 10, 22
    [InlineData("vv>A", 44)] // 8, 18
    [InlineData("v>vA", 68)]
    [InlineData(">vvA", 54)] // 8, 22

    [InlineData(">>^A", 48)]  // 8, 20, 48
    [InlineData(">^>A", 66)] // 10, 26, 66
    [InlineData("^>>A", 48)]  // 8, 20, 48

    [InlineData(">>vA", 54)]  // 8, 22, 54
    [InlineData(">v>A", 56)]  // 8, 22, 56
    [InlineData("v>>A", 44)]  // 8, 18, 44

    [InlineData(">>vvvA", 56)]
    [InlineData(">v>vvA", 82)]
    [InlineData(">vv>vA", 82)]
    [InlineData(">vvv>A", 58)]
    [InlineData("v>>vvA", 70)]
    [InlineData("v>v>vA", 96)]
    [InlineData("v>vv>A", 72)]
    [InlineData("vv>>vA", 70)]
    [InlineData("vv>v>A", 72)]

    [InlineData("^^^<<A", 66)]
    [InlineData("^^<^<A", 108)]
    [InlineData("^^<<^A", 74)]
    [InlineData("^<^^<A", 108)]
    [InlineData("^<^<^A", 116)]
    [InlineData("^<<^^A", 74)]
    [InlineData("<^<^^A", 100)]
    [InlineData("<^^<^A", 100)]
    [InlineData("<^^^<A", 92)]

    [InlineData("^^^<A", 65)]
    [InlineData("^^<^A", 73)]
    [InlineData("^<^^A", 73)]
    [InlineData("<^^^A", 57)]

    [InlineData(">>vvA", 55)]
    [InlineData(">v>vA", 81)]
    [InlineData(">vv>A", 57)]
    [InlineData("v>>vA", 69)]
    [InlineData("v>v>A", 71)]

    [InlineData("vvv>A", 45)]
    [InlineData("vv>vA", 69)]
    [InlineData("v>vvA", 69)]
    [InlineData(">vvvA", 55)]

    [InlineData("vvv<A", 61)]
    [InlineData("v<vvA", 69)]
    [InlineData("vv<vA", 69)]
    [InlineData("<vvvA", 57)]

    [InlineData("^^^>A", 49)]
    [InlineData("^^>^A", 67)]
    [InlineData("^>^^A", 67)]
    [InlineData(">^^^A", 49)]
    public void CalculateBestOption_WhenGoingFromAtoDownThrice(string input, int expectedCount)
    {
        var sut = new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        });

        var result = sut.CalculateShortestSequence(input);
        Assert.Equal(expectedCount, result.Length);
    }

    [Theory]
    [InlineData(">^A", 123)] // 7, 19, 47
    [InlineData("^>A", 117)] // 7, 19, 47
    [InlineData(">>^A", 124)]
    [InlineData("^>>A", 118)]
    [InlineData("^^^>A", 119)]
    [InlineData(">^^^A", 125)]
    [InlineData("^^<A", 154)]
    [InlineData("^<^A", 180)]
    [InlineData("<^^A", 136)]
    [InlineData("vv<<A", 151)]
    [InlineData("v<v<A", 223)]
    [InlineData("v<<vA", 177)]
    [InlineData("<vv<A", 183)]
    [InlineData("<v<vA", 209)]
    [InlineData("<<vvA", 137)]
    [InlineData("^^<<A", 155)]
    [InlineData("^<^<A", 259)]
    [InlineData("^<<^A", 181)]
    [InlineData("<^^<A", 215)]
    [InlineData("<^<^A", 241)]
    [InlineData("<<^^A", 137)]
    [InlineData("^^>A", 118)]
    [InlineData("^>^A", 172)]
    [InlineData(">^^A", 124)]
    [InlineData("^^>>A", 119)]
    [InlineData("^>^>A", 215)]
    [InlineData("^>>^A", 173)]
    [InlineData(">^^>A", 167)]
    [InlineData(">^>^A", 221)]
    [InlineData(">>^^A", 125)]
    public void CalculateBestOption_WhenGoingFromAtoDownFour(string input, int expectedCount)
    {
        var sut = new CombinedKeypadTyping(new()
        {
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad(),
            KeypadTyping.CreateDirectionalKeypad()
        });

        var result = sut.CalculateShortestSequence(input);
        Assert.Equal(expectedCount, result.Length);
    }

    [Theory]
    //[InlineData("029A", "v<<A>>^A<A>AvA<^AA>A<vAAA>^A")]  //
    //[InlineData("379A", "<A>Av<<AA>^AA>AvAA^A<vAAA>^A")]  // >^A is good with 2 directionals, worse with more
    [InlineData("029A", "v<<A>>^A<A>A<AAv>A^A<vAAA^>A")]
    [InlineData("379A", "<A>Av<<AA>^AA>AvAA^A<vAAA^>A")]
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