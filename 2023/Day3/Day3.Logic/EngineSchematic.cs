

namespace Day3.Logic;

public class EngineSchematic
{
    private string _input;
    private readonly string[] _schematic;

    public int Width => _schematic[0].Length;
    public int Height => _schematic.Length;

    public int SumOfParts { get; private set; }

    public EngineSchematic(string input)
    {
        _input = input;
        _schematic = _input.Split("\n");

        Parse();
    }

    private void Parse()
    {
        for (var y = 0; y < Height; y++)
        {
            var nextToSymbol = false;
            var inNumber = false;
            var currentNumber = "";

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
                            nextToSymbol = nextToSymbol || IsSymbol(_schematic[y-1][x-1]);
                        }

                        nextToSymbol = nextToSymbol || IsSymbol(_schematic[y-1][x]);

                        if (x + 1 < Width)
                        {
                            nextToSymbol = nextToSymbol || IsSymbol(_schematic[y-1][x+1]);
                        }
                    }

                    if (x - 1 >= 0)
                    {
                        nextToSymbol = nextToSymbol || IsSymbol(_schematic[y][x-1]);
                    }

                    if (x + 1 < Width)
                    {
                        nextToSymbol = nextToSymbol || IsSymbol(_schematic[y][x+1]);
                    }

                    if (y + 1 < Height)
                    {
                        if (x - 1 >= 0)
                        {
                            nextToSymbol = nextToSymbol || IsSymbol(_schematic[y+1][x-1]);
                        }

                        nextToSymbol = nextToSymbol || IsSymbol(_schematic[y+1][x]);

                        if (x + 1 < Width)
                        {
                            nextToSymbol = nextToSymbol || IsSymbol(_schematic[y+1][x+1]);
                        }
                    }
                }
                else
                {
                    if (inNumber && nextToSymbol)
                    {
                        SumOfParts += int.Parse(currentNumber);
                    }

                    currentNumber = "";
                    inNumber = false;
                    nextToSymbol = false;
                }
            }
        }
    }

    private bool IsSymbol(char value)
    {
        return value != '.' && !char.IsDigit(value);
    }
}
