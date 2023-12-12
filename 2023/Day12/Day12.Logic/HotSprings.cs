
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
    public int SumOfArrangements { get; private set; }

    public HotSprings(string input, bool combine = false)
    {
        _input = input;
        _lines = _input.Split("\n");
        Rows = new List<(string Map, int[] Groups)>();
        Combinations = new List<string[]>();

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
            // TODO: return?
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
