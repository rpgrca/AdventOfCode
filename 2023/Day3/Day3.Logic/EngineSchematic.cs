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
        SumOfGearRatios = dictionary
            .Select(p => p.Value.Distinct().ToList())
            .Where(d => d.Count == 2)
            .Aggregate(0, (t, i) => t + (i[0] * i[1]));
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
                                    list.Add((x-1, y-1));
                                }
                                nextToSymbol = true;
                            }
                        }

                        if (IsSymbol(_schematic[y-1][x]))
                        {
                            if (_schematic[y-1][x] == '*')
                            {
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
                                    list.Add((x-1, y+1));
                                }

                                nextToSymbol = true;
                            }
                        }

                        if (IsSymbol(_schematic[y+1][x]))
                        {
                            if (_schematic[y+1][x] == '*')
                            {
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
                            if (!dictionary.ContainsKey(coordinates))
                            {
                                dictionary.Add(coordinates, new List<int>());
                            }
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
                        if (!dictionary.ContainsKey(coordinates))
                        {
                            dictionary.Add(coordinates, new List<int>());
                        }
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
