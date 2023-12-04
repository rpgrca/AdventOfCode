using System.Reflection;

namespace Day3.Logic;

public class EngineSchematic
{
    private string _input;
    private readonly string[] _schematic;
    private Dictionary<(int X, int Y), List<int>> dictionary = new();

    public int Width => _schematic[0].Length;
    public int Height => _schematic.Length;

    public int SumOfParts { get; private set; }
    public int SumOfGearRatios { get; private set; }

    public EngineSchematic(string input)
    {
        _input = input;
        _schematic = _input.Split("\n");

        Parse();
        CalculateSumOfGearRatios();
    }

    private void CalculateSumOfGearRatios()
    {
        SumOfGearRatios = dictionary.Where(d => d.Value.Distinct().Count() == 2).Aggregate(0, (t, i) => t + (i.Value[0] * i.Value[1]));
/*
        var list = new List<string>();
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var currentValue = _schematic[y][x];
                if (currentValue == '*')
                {
                    list.Clear();
                    var possibleNumber = "";

                    if (y - 1 >= 0)
                    {
                    }

                    if (x - 1 >= 0)
                    {
                        if (char.IsDigit(_schematic[y][x-1]))
                        {
                            if (x - 2 >= 0)
                            {
                                if (char.IsDigit(_schematic[y][x-2]))
                                {
                                    if (x - 3 >= 0)
                                    {
                                        if (char.IsDigit(_schematic[y][x-3]))
                                        {
                                            possibleNumber = $"{_schematic[y][x-3]}{_schematic[y][x-2]}{_schematic[y][x-1]}";
                                        }
                                        else
                                        {
                                            possibleNumber = $"{_schematic[y][x-2]}{_schematic[y][x-1]}";
                                        }
                                    }
                                    else
                                    {
                                        possibleNumber = $"{_schematic[y][x-2]}{_schematic[y][x-1]}";
                                    }
                                }
                                else
                                {
                                    possibleNumber = $"{_schematic[y][x-1]}";
                                }
                            }
                            else
                            {
                                possibleNumber = $"{_schematic[y][x-1]}";
                            }
                        }
                    }

                    if (! string.IsNullOrEmpty(possibleNumber))
                    {
                        list.Add(possibleNumber);
                    }

                    possibleNumber = "";
                    if (x + 1 < Width)
                    {
                        if (char.IsDigit(_schematic[y][x+1]))
                        {
                            if (x + 2 < Width)
                            {
                                if (char.IsDigit(_schematic[y][x+2]))
                                {
                                    if (x + 3 < Width)
                                    {
                                        if (char.IsDigit(_schematic[y][x+3]))
                                        {
                                            possibleNumber = $"{_schematic[y][x+1]}{_schematic[y][x+2]}{_schematic[y][x+3]}";
                                        }
                                        else
                                        {
                                            possibleNumber = $"{_schematic[y][x+1]}{_schematic[y][x+2]}";
                                        }
                                    }
                                    else
                                    {
                                        possibleNumber = $"{_schematic[y][x+1]}{_schematic[y][x+2]}";
                                    }
                                }
                                else
                                {
                                    possibleNumber = $"{_schematic[y][x+1]}";
                                }
                            }
                            else
                            {
                                possibleNumber = $"{_schematic[y][x+1]}";
                            }
                        }
                    }

                    if (! string.IsNullOrEmpty(possibleNumber))
                    {
                        list.Add(possibleNumber);
                    }

                    if (y + 1 < Height)
                    {
                    }

                    if (list.Count > 1)
                    {
                        if (list.Count == 2)
                        {
                            SumOfGearRatios = int.Parse(list[0]) * int.Parse(list[1]);
                        }
                        else
                        {
                            throw new IndexOutOfRangeException("More than two gears found");
                        }
                    }
                }
            }
        }*/
    }

    private void Parse()
    {
        for (var y = 0; y < Height; y++)
        {
            var nextToSymbol = false;
            var inNumber = false;
            var currentNumber = "";
            var list = new List<(int X, int Y)>();

            for (var x = 0; x < Width; x++)
            {
                var currentValue = _schematic[y][x];
                if (char.IsDigit(currentValue))
                {
                    currentNumber += currentValue;
                    inNumber = true;
                    if (y - 1 >= 0)
                    {
                        if (x - 1 >= 0)
                        {
                            if (IsSymbol(_schematic[y-1][x-1]))
                            {
                                if (_schematic[y-1][x-1] == '*')
                                {
                                    if (!dictionary.ContainsKey((x-1, y-1)))
                                    {
                                        dictionary.Add((x-1, y-1), new List<int>());
                                    }
                                    list.Add((x-1, y-1));
                                }
                                nextToSymbol = true;
                            }
                        }

                        if (IsSymbol(_schematic[y-1][x]))
                        {
                            if (_schematic[y-1][x] == '*')
                            {
                                if (!dictionary.ContainsKey((x, y-1)))
                                {
                                    dictionary.Add((x, y-1), new List<int>());
                                }
                                list.Add((x, y-1));
                            }

                            nextToSymbol = true;
                        }

                        if (x + 1 < Width)
                        {
                            if (IsSymbol(_schematic[y-1][x+1]))
                            {
                                if (_schematic[y-1][x+1] == '*')
                                {
                                    if (!dictionary.ContainsKey((x+1, y-1)))
                                    {
                                        dictionary.Add((x+1, y-1), new List<int>());
                                    }
                                    list.Add((x+1, y-1));
                                }

                                nextToSymbol = true;
                            }
                        }
                    }

                    if (x - 1 >= 0)
                    {
                        if (IsSymbol(_schematic[y][x-1]))
                        {
                            if (_schematic[y][x-1] == '*')
                            {
                                if (!dictionary.ContainsKey((x-1, y)))
                                {
                                    dictionary.Add((x-1, y), new List<int>());
                                }
                                list.Add((x-1, y));
                            }

                            nextToSymbol = true;
                        }
                    }

                    if (x + 1 < Width)
                    {
                        if (IsSymbol(_schematic[y][x+1]))
                        {
                            if (_schematic[y][x+1] == '*')
                            {
                                if (!dictionary.ContainsKey((x+1, y)))
                                {
                                    dictionary.Add((x+1, y), new List<int>());
                                }
                                list.Add((x+1, y));
                            }

                            nextToSymbol = true;
                        }
                    }

                    if (y + 1 < Height)
                    {
                        if (x - 1 >= 0)
                        {
                            if (IsSymbol(_schematic[y+1][x-1]))
                            {
                                if (_schematic[y+1][x-1] == '*')
                                {
                                    if (!dictionary.ContainsKey((x-1, y+1)))
                                    {
                                        dictionary.Add((x-1, y+1), new List<int>());
                                    }
                                    list.Add((x-1, y+1));
                                }

                                nextToSymbol = true;
                            }
                        }

                        if (IsSymbol(_schematic[y+1][x]))
                        {
                            if (_schematic[y+1][x] == '*')
                            {
                                if (!dictionary.ContainsKey((x, y+1)))
                                {
                                    dictionary.Add((x, y+1), new List<int>());
                                }
                                list.Add((x, y+1));
                            }

                            nextToSymbol = true;
                        }

                        if (x + 1 < Width)
                        {
                            if (IsSymbol(_schematic[y+1][x+1]))
                            {
                                if (_schematic[y+1][x+1] == '*')
                                {
                                    if (!dictionary.ContainsKey((x+1, y+1)))
                                    {
                                        dictionary.Add((x+1, y+1), new List<int>());
                                    }
                                    list.Add((x+1, y+1));
                                }

                                nextToSymbol = true;
                            }
                        }
                    }
                }
                else
                {
                    if (inNumber)
                    {
                        if (nextToSymbol)
                        {
                            SumOfParts += int.Parse(currentNumber);
                        }

                        foreach (var coordinates in list)
                        {
                            dictionary[coordinates].Add(int.Parse(currentNumber));
                        }
                    }

                    currentNumber = "";
                    inNumber = false;
                    nextToSymbol = false;
                    list.Clear();
                }
            }

            if (inNumber)
            {
                if (nextToSymbol)
                {
                    SumOfParts += int.Parse(currentNumber);

                    foreach (var coordinates in list)
                    {
                        dictionary[coordinates].Add(int.Parse(currentNumber));
                    }
                }
            }
        }
    }

    private bool IsSymbol(char value)
    {
        return value != '.' && !char.IsDigit(value);
    }
}
