



using System.Numerics;

namespace Day13.Logic;
public class PointOfIncidence
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<(List<string> Pattern, List<int> Vertical, List<int> Horizontal)> _maps;

    public PointOfIncidence(string input, bool smudgeCorrection = false)
    {
        _input = input;
        _lines = _input.Split("\n");
        _maps = new List<(List<string> Pattern, List<int> Horizontal, List<int> Vertical)>();

        var currentMap = new List<string>();
        foreach (var line in _lines)
        {
            if (string.IsNullOrEmpty(line))
            {

                _maps.Add((currentMap, GenerateVerticalNumbering(currentMap), GenerateHorizontalNumbering(currentMap)));
                currentMap = new List<string>();
            }
            else
            {
                currentMap.Add(line);
            }
        }

        _maps.Add((currentMap, GenerateVerticalNumbering(currentMap), GenerateHorizontalNumbering(currentMap)));

        PatternSummary = 0;

        if (! smudgeCorrection)
        {
            foreach (var map in _maps)
            {
                var lastValue = -1;
                for (var column = 0; column < map.Vertical.Count; column++)
                {
                    if (map.Vertical[column] == lastValue)
                    {
                        if (CheckMirroring(map.Vertical, column))
                        {
                            PatternSummary += column;
                            break;
                        }
                    }

                    lastValue = map.Vertical[column];
                }

                lastValue = -1;
                for (var row = 0; row < map.Horizontal.Count; row++)
                {
                    if (map.Horizontal[row] == lastValue)
                    {
                        if (CheckMirroring(map.Horizontal, row))
                        {
                            PatternSummary += row * 100;
                            break;
                        }
                    }

                    lastValue = map.Horizontal[row];
                }
            }
        }
        else
        {
            foreach (var map in _maps)
            {
                for (var column = 0; column < map.Vertical.Count - 1; column++)
                {
                    for (var innerColumn = column + 1; innerColumn < map.Vertical.Count; innerColumn++)
                    {
                        var difference = map.Vertical[column] ^ map.Vertical[innerColumn];
                        if (BitOperations.IsPow2(difference))
                        {
                            var oldColumn = map.Vertical[column];
                            map.Vertical[column] =  map.Vertical[innerColumn];

                            var possibleColumn = (column + innerColumn + 1) / 2;
                            if (CheckMirroring(map.Vertical, possibleColumn))
                            {
                                PatternSummary += column;
                                goto CheckForRow;
                            }

                            map.Vertical[column] = oldColumn;
                        }
                    }
                }

            CheckForRow:
                for (var row = 0; row < map.Horizontal.Count - 1; row++)
                {
                    for (var innerRow = row + 1; innerRow < map.Horizontal.Count; innerRow++)
                    {
                        var difference = map.Horizontal[row] ^ map.Horizontal[innerRow];
                        if (BitOperations.IsPow2(difference))
                        {
                            var oldRow = map.Horizontal[row];
                            map.Horizontal[row] = map.Horizontal[innerRow];

                            var possibleRow = (row + innerRow + 1) / 2;
                            if (CheckMirroring(map.Horizontal, possibleRow))
                            {
                                PatternSummary += possibleRow * 100;
                                goto Correct;
                            }

                            map.Horizontal[row] = oldRow;
                        }
                    }
                }

                Correct:;
            }

        }
    }

    private bool CheckMirroring(List<int> map, int reflection)
    {
        int previous;
        int next;

        for (previous = reflection - 2, next = reflection + 1; previous >= 0 && next < map.Count; previous--, next++)
        {
            if (map[previous] != map[next])
            {
                return false;
            }
        }

        return true;
    }

    private List<int> GenerateHorizontalNumbering(List<string> currentMap)
    {
        var horizontalNumbering = new List<int>();
        for (var y = 0; y < currentMap.Count; y++)
        {
            var code = 0;
            for (var x = 0; x < currentMap[y].Length; x++)
            {
                code = (code << 1) | (currentMap[y][x] == '.'? 0 : 1);
            }

            horizontalNumbering.Add(code);
        }

        return horizontalNumbering;
    }

    private List<int> GenerateVerticalNumbering(List<string> currentMap)
    {
        var verticalNumbering = new List<int>();
        for (var x = 0; x < currentMap[0].Length; x++)
        {
            var code = 0;
            for (var y = 0; y < currentMap.Count; y++)
            {
                code = (code << 1) | (currentMap[y][x] == '.'? 0 : 1);
            }

            verticalNumbering.Add(code);
        }

        return verticalNumbering;
    }

    public int MapCount => _maps.Count;

    public int PatternSummary { get; private set; }
}
