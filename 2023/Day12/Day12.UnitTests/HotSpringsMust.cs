using Day12.Logic;
using static Day12.UnitTests.Constants;

namespace Day12.UnitTests;

public class HotSpringsMust
{
    [Theory]
    [InlineData(SAMPLE_INPUT, 6)]
    [InlineData(PUZZLE_INPUT, 1000)]
    public void LoadInputCorrectly(string input, int expectedRows)
    {
        var sut  = new HotSprings(input);
        Assert.Equal(expectedRows, sut.RowCount);
    }

    [Theory]
    [MemberData(nameof(SingleLineFeeder))]
    public void ParseInputCorrectly(string input, string expectedMap, int[] expectedGroups)
    {
        var sut = new HotSprings(input);
        Assert.Collection(sut.Rows,
            r1 => {
                Assert.Equal(expectedMap, r1.Map);
                Assert.Equal(expectedGroups, r1.Groups);
            });
    }

    public static IEnumerable<object[]> SingleLineFeeder()
    {
        yield return new object[] { "???.### 1,1,3", "???.###", new[] { 1, 1, 3 } };
        yield return new object[] { "?#?#?#?#?#?#?#? 1,3,1,6", "?#?#?#?#?#?#?#?", new[] { 1,3,1,6 } };
        yield return new object[] { ".??..??...?##. 1,1,3", ".??..??...?##.", new[] { 1,1,3 } };
        yield return new object[] { "????.#...#... 4,1,1", "????.#...#...", new[] { 4, 1, 1 } };
        yield return new object[] { "????.######..#####. 1,6,5", "????.######..#####.", new[] { 1, 6, 5 } };
        yield return new object[] { "?###???????? 3,2,1", "?###????????", new[] { 3, 2, 1 } };
        yield return new object[] { ".#...#....###. 1,1,3", ".#...#....###.", new[] { 1,1,3 } };
        yield return new object[] { ".#.###.#.###### 1,3,1,6", ".#.###.#.######", new[] { 1,3,1,6 } };
        yield return new object[] { "####.#...#... 4,1,1", "####.#...#...", new[] { 4, 1, 1 } };
        yield return new object[] { "#....######..#####. 1,6,5", "#....######..#####.", new[] { 1, 6, 5 } };
        yield return new object[] { ".###.##....# 3,2,1", ".###.##....#", new[] { 3, 2, 1 } };
    }

    [Theory]
    [MemberData(nameof(SingleLineCombinationFeeder))]
    public void CalculatePossibleCombinationsCorrectly(string input, string[] expectedCombinations)
    {
        var sut = new HotSprings(input, true);
        Assert.True(expectedCombinations.SequenceEqual(sut.Combinations[0]));
    }

    public static IEnumerable<object[]> SingleLineCombinationFeeder()
    {
        yield return new object[] { "? 1", new[] { "#" } };
        //yield return new object[] { "?? 1", new[] { "#.", ".#" } };
        yield return new object[] { "#.#.### 1,1,3", new[] { "#.#.###" } };
        yield return new object[] { "???.### 1,1,3", new[] { "#.#.###" } };
        yield return new object[] { "####.#...#... 4,1,1", new[] { "####.#...#..." } };
        /*yield return new object[] { "?###???????? 3,2,1", new[] {
            ".###.##.#...",
            ".###.##..#..",
            ".###.##...#.",
            ".###.##....#",
            ".###..##.#..",
            ".###..##..#.",
            ".###..##...#",
            ".###...##.#.",
            ".###...##..#",
            ".###....##.#"
          } };*/
    }

    [Theory]
    [InlineData("?? 1", 2)]
    [InlineData("????? 1,1", 6)]
    [InlineData("???????? 1,1,1", 20)]
    [InlineData("??????????? 1,1,1,1", 70)]
    [InlineData("?????????????? 1,1,1,1,1", 252)]
    [InlineData(".?#....??? 2,1", 3)]
    [InlineData("?.?#....??? 2,1", 3)]
    [InlineData(".?#....???? 2,1", 4)]
    [InlineData(".?#....????.?#....??? 2,1,2,1", 13)]
    [InlineData(".?#....????.?#....????.?#....??? 2,1,2,1,2,1", 61)]
    [InlineData(".?#....????.?#....????.?#....????.?#....??? 2,1,2,1,2,1,2,1", 298)]
    //[InlineData(".?#....????.?#....????.?#....????.?#....????.?#....??? 2,1,2,1,2,1,2,1,2,1", 1489)] // 16seg
    [InlineData("?###???????? 3,2,1", 10)]
    [InlineData("?###????????? 3,2,1", 15)]
    [InlineData("??###???????? 3,2,1", 10)]
    [InlineData("?###??????????###???????? 3,2,1,3,2,1", 150)]
    [InlineData(".??#???.??? 3,1,1", 12)]
    [InlineData(".??#???.???? 3,1,1", 21)]
    [InlineData("?.??#???.??? 3,1,1", 12)]
    [InlineData(".??..??...?##. 1,1,3", 4)]
    [InlineData(".??..??...?##.? 1,1,3", 4)]
    [InlineData("?.??..??...?##. 1,1,3", 8)]
    //[InlineData("???.###????.###????.###????.###????.### 1,1,3,1,1,3,1,1,3,1,1,3,1,1,3", 1)] // 1 seg
    [InlineData(".??..??...?##.?.??..??...?##. 1,1,3,1,1,3", 32)]
    [InlineData(".??..??...?##.?.??..??...?##.?.??..??...?##. 1,1,3,1,1,3,1,1,3", 256)]
    //[InlineData(".??..??...?##.?.??..??...?##.?.??..??...?##.?.??..??...?##. 1,1,3,1,1,3,1,1,3,1,1,3", 2048)] // 9seg
    public void Test1(string input, int expectedResult)
    {
        var sut = new HotSprings(input, true);
        Assert.Equal(expectedResult, sut.SumOfArrangements);
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 6)]
    [InlineData(SECOND_SAMPLE_INPUT, 21)]
    public void SolveFirstSampleCorrectly(string input, int expectedSum)
    {
        var sut = new HotSprings(input, true);
        Assert.Equal(expectedSum, sut.SumOfArrangements);
    }

    [Fact]
    public void SolveFirstPuzzleCorrectly()
    {
        var sut = new HotSprings(PUZZLE_INPUT, true);
        Assert.Equal(6935, sut.SumOfArrangements);
    }

    [Theory]
    [InlineData("???.### 1,1,3", 1)]
    [InlineData(".??..??...?##. 1,1,3", 16384)]
    [InlineData("????.#...#... 4,1,1", 16)]
    [InlineData("?#?#?#?#?#?#?#? 1,3,1,6", 1)]
    [InlineData("????.######..#####. 1,6,5", 2500)]
    [InlineData("?###???????? 3,2,1", 506250)]
    [InlineData(".??#???.??? 3,1,1", 2333772)]
    [InlineData(".?#....??? 2,1", 768)] // TODO: Cannot be 768
    public void SolveExampleCorrectly_WhenUnfoldingMap(string input, int expectedResult)
    {
        var sut = new HotSprings(input, true, true);
        Assert.Equal(expectedResult, sut.SumOfArrangements);
    }

    [Fact]
    public void SolveSecondSampleCorrectly()
    {
        var sut = new HotSprings(SECOND_SAMPLE_INPUT, true, true);
        Assert.Equal(525152, sut.SumOfArrangements);
    }

    [Fact(Skip = "TODO")] // 13 seg
    public void SolveSecondPuzzleCorrectly()
    {
        var sut = new HotSprings(PUZZLE_INPUT, true, true);
        /*Assert.True(878755040584 < sut.SumOfArrangements);
        Assert.True(878760112338 < sut.SumOfArrangements);
        Assert.True(892719656484 < sut.SumOfArrangements);
        Assert.NotEqual(899719656484, sut.SumOfArrangements);*/
        Assert.Equal(0, sut.SumOfArrangements);
    }
}
