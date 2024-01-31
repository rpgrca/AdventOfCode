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
    public double SumOfArrangements { get; private set; }

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
                //CalculateCombinations(row, 0, string.Empty, combinations);
                CalculateCombinations3(row, 0, string.Empty, combinations);
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
/*
                (string, int[]) newRow = (string.Empty, Array.Empty<int>());
                if (row.Map[^1] == '?')
                {
                    newRow = (row.Map + '?', row.Groups);
                }
                else if (row.Map[^1] == '.')
                {
                    newRow = ('?' + row.Map, row.Groups);
                }
                else if (row.Map[0] == '?' && row.Map[^1] == '#')
                {
                    newRow = (row.Map + '?', row.Groups);
                }
                else if (row.Map[0] == '.' && row.Map[^1] == '#')
                {
                    newRow = (row.Map + '?', row.Groups); // TODO
                }
                else if (row.Map[0] == '#' && row.Map[^1] == '#')
                {
                    newRow = ('?' + row.Map, row.Groups); // TODO
                }*/


/*
                if (row.Map[^1] == '#')
                {
                    newRow = (row.Map + '?', row.Groups);
                }
                else if (row.Map[^1] == '.')
                {
                    newRow = ('?' + row.Map, row.Groups);
                }
                else if (row.Map[^1] == '?')
                {
                    newRow = (row.Map + '?', row.Groups);
                }*/

// A
// A? A? A? A? A

/*
                // A? A? A ?A ?A
                var combinations1 = new List<string>();
                var groups = new List<int>();
                groups.AddRange(row.Groups);
                groups.AddRange(row.Groups);
                var newRow1 = (row.Map + '?' + row.Map, groups.ToArray());
                CalculateCombinations2(newRow1, 0, string.Empty, combinations1);

                var combinations2 = new List<string>();
                var newRow2 = ('?' + row.Map + '?', row.Groups);
                CalculateCombinations2(newRow2, 0, string.Empty, combinations2);

                SumOfArrangements += (long)Math.Pow(combinations1.Count, 2) * combinations2.Count;
*/




//                var newRow1 = ('?' + row.Map, row.Groups);
//                var combinationsFirst = new List<string>();
//                var combi1 = new List<string>();
//                CalculateCombinations(newRow1, 0, string.Empty, combinationsFirst);
//
//                var validCombinations = 0;
//                foreach (var c2 in combinationsFirst)
//                {
//                    var invalid = false;
//
//                    foreach (var c1 in Combinations[index])
//                    {
//                        var splittedMap = (c1 + c2).Split(".").Where(p => !string.IsNullOrEmpty(p)).Select(p => p.Length).ToArray();
//                        var array = new List<int>();
//                        array.AddRange(row.Groups);
//                        array.AddRange(row.Groups);
//                        if (! splittedMap.SequenceEqual(array))
//                        {
//                            invalid = true;
//                            break;
//                        }
//                    }
//
//                    if (! invalid)
//                    {
//                        combi1.Add(c2);
//                        validCombinations++; // valid values for a?A
//                    }
//                }
//
//                var newRow2 = (row.Map + '?', row.Groups);
//                var combinationsSecond = new List<string>();
//                var combi2 = new List<string>();
//                CalculateCombinations(newRow2, 0, string.Empty, combinationsSecond);
//
//                var validCombinations2 = 0;
//
//                foreach (var c2 in combinationsSecond)
//                {
//                    var invalid = false;
//
//                    foreach (var c1 in Combinations[index])
//                    {
//                        var splittedMap = (c2 + c1).Split(".").Where(p => !string.IsNullOrEmpty(p)).Select(p => p.Length).ToArray();
//                        var array = new List<int>();
//                        array.AddRange(row.Groups);
//                        array.AddRange(row.Groups);
//                        if (! splittedMap.SequenceEqual(array))
//                        {
//                            invalid = true;
//                            break;
//                        }
//                    }
//
//                    if (! invalid)
//                    {
//                        combi2.Add(c2);
//                        validCombinations2++; //  valid values for A?a
//                    }
//                }
//
//
//                // A? A? A? A? A?
//                // A? A
///*
//                var values = combi1.SelectMany(p => Combinations[index], (n, p) => p + n).ToList();
//                var values2 = combi2.SelectMany(p => Combinations[index], (n, p) => n + p).ToList();
//                var union = values.Union(values2).Count();
//                SumOfArrangements += Combinations[index].Length * (long)Math.Pow(union, 3);
//*/
//
//
//                if (validCombinations > validCombinations2)
//                {
//                    SumOfArrangements += (long)Math.Pow(validCombinations, 4) * Combinations[index].Length;
//                }
//                else
//                {
//                    SumOfArrangements += (long)Math.Pow(validCombinations2, 4) * Combinations[index].Length;
//                }

                var validCombinations = 0;
                var validCombinations2 = 0;

                if (row.Map.Length == (row.Groups.Sum() + row.Groups.Length - 1))
                {
                    validCombinations = validCombinations2 = 1;
                }
                else
                {
                    var newRow1 = ('?' + row.Map, row.Groups);
                    CalculateCombinations2(newRow1, 0, string.Empty, ref validCombinations);

                    var combinations = new List<string>();
                    CalculateCombinations3(newRow1, 0, string.Empty, combinations);

                    var newRow2 = (row.Map + '?', row.Groups);
                    CalculateCombinations2(newRow2, 0, string.Empty, ref validCombinations2);

                    CalculateCombinations3(newRow2, 0, string.Empty, combinations);

                    combinations = combinations.Distinct().ToList();
                }


                if (validCombinations > validCombinations2)
                {
                    SumOfArrangements += Math.Pow(validCombinations, 4) * Combinations[index].Length;
                }
                else
                {
                    SumOfArrangements += Math.Pow(validCombinations2, 4) * Combinations[index].Length;
                }
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

    private void CalculateCombinations3((string Map, int[] Groups) row, int currentIndex, string currentCombination, List<string> combinations)
    {
        currentIndex = 0;

        var combs = new List<string> { "" };
        while (currentIndex < row.Map.Length)
        {
            if (row.Map[currentIndex] == '?')
            {
                var temp = new List<string>();
                temp.AddRange(combs.Select(p => p + '#'));
                temp.AddRange(combs.Select(p => p + '.'));
                combs = temp;
            }
            else
            {
                var temp = new List<string>();
                temp.AddRange(combs.Select(p => p + row.Map[currentIndex]));
                combs = temp;
            }
            currentIndex++;
        }

        combinations.AddRange(combs
            .Select(p => new { Original = p, Groups = p.Split(".").Where(q => !string.IsNullOrEmpty(q)).Select(r => r.Length).ToArray() })
            .Where(p => p.Groups.SequenceEqual(row.Groups))
            .Select(p => p.Original));
    }

    private void CalculateCombinations2((string Map, int[] Groups) row, int currentIndex, string currentCombination, ref int validCombinations)
    {
        while (currentIndex < row.Map.Length && row.Map[currentIndex] != '?')
        {
            currentCombination += row.Map[currentIndex];
            currentIndex++;
        }

        if (currentIndex < row.Map.Length)
        {
            CalculateCombinations2(row, currentIndex + 1, currentCombination + '#', ref validCombinations);
            CalculateCombinations2(row, currentIndex + 1, currentCombination + ".", ref validCombinations);
            return;
        }

        var splittedMap = currentCombination
            .Split(".")
            .Where(p => !string.IsNullOrEmpty(p))
            .Select(p => p.Length)
            .ToArray();

        if (splittedMap.SequenceEqual(row.Groups))
        {
            validCombinations++;
        }
    }

}
