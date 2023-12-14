
using System.ComponentModel;
using System.Data;

namespace Day12.Logic;

public class HotSprings
{
    private readonly string _input;
    private readonly string[] _lines;
    public int RowCount => _lines.Length;
    public List<(string Map, int[] Groups)> Rows { get; private set; }
    public List<string[]> Combinations { get; private set; }
    public List<int> CombinationCount { get; private set; }
    public long SumOfArrangements { get; private set; }

    public HotSprings(string input, bool combine = false, bool unfold = false)
    {
        _input = input;
        _lines = _input.Split("\n");
        Rows = new List<(string Map, int[] Groups)>();
        Combinations = new List<string[]>();
        CombinationCount = new List<int>();

        foreach (var line in _lines)
        {
            var values = line.Split(" ");
            Rows.Add((values[0], values[1].Split(",").Select(int.Parse).ToArray()));
        }

        if (combine)
        {
            foreach (var row in Rows)
            {
                var combinations = new List<string>();
                CalculateCombinations(row, 0, string.Empty, combinations);
                Combinations.Add(combinations.ToArray());
            }

            SumOfArrangements = Combinations.Sum(p => p.Length);
        }


        if (unfold)
        {
            SumOfArrangements = 0;
            for (var index = 0; index < Rows.Count; index++)
            {
                var row = Rows[index];

                (string, int[]) newRow = (string.Empty, Array.Empty<int>());
                if (row.Map[^1] == '#')
                {
                    newRow = (row.Map + '?', row.Groups);
                }
                else if (row.Map[^1] == '.')
                {
                    newRow = ('?' + row.Map, row.Groups);
                }

                var combinationsFirst = new List<string>();
                CalculateCombinations(newRow, 0, string.Empty, combinationsFirst);
                SumOfArrangements += (long)Math.Pow(combinationsFirst.Count, 4) * Combinations[index].Length;
            }
        }
    }

    private void CalculateCombinations((string Map, int[] Groups) row, int currentIndex, string currentCombination, List<string> combinations)
    {
        while (currentIndex < row.Map.Length && row.Map[currentIndex] != '?')
        {
            currentCombination += row.Map[currentIndex];
            currentIndex++;
        }

        if (currentIndex < row.Map.Length)
        {
            CalculateCombinations(row, currentIndex + 1, currentCombination + '#', combinations);
            CalculateCombinations(row, currentIndex + 1, currentCombination + ".", combinations);
            return;
        }

        if (currentCombination.Length == row.Map.Length)
        {
            var splittedMap = currentCombination.Split(".").Where(p => !string.IsNullOrEmpty(p)).Select(p => p.Length).ToArray();
            if (splittedMap.SequenceEqual(row.Groups))
            {
                combinations.Add(currentCombination);
            }
        }
    }
}
