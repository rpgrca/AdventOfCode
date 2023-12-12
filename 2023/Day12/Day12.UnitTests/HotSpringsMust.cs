using System.Security.Cryptography;
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
        yield return new object[] { "?? 1", new[] { "#.", ".#" } };
        yield return new object[] { "#.#.### 1,1,3", new[] { "#.#.###" } };
        yield return new object[] { "???.### 1,1,3", new[] { "#.#.###" } };
        yield return new object[] { "####.#...#... 4,1,1", new[] { "####.#...#..." } };
        yield return new object[] { "?###???????? 3,2,1", new[] {
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
          } };
    }

    [Theory]
    [InlineData(SAMPLE_INPUT, 6)]
    [InlineData(SECOND_SAMPLE_INPUT, 21)]
    public void SolveFirstSampleCorrectly(string input, int expectedSum)
    {
        var sut = new HotSprings(input, true);
        Assert.Equal(expectedSum, sut.SumOfArrangements);
    }


}