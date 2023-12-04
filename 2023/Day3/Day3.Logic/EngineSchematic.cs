namespace Day3.Logic;

public class EngineSchematic
{
    private readonly string _input;
    private readonly string[] _schematic;
    private readonly Dictionary<(int X, int Y), List<int>> _gears;
    private readonly List<(int X, int Y)> _gearCoordinates;

    public int Width => _schematic[0].Length;
    public int Height => _schematic.Length;

    public int SumOfParts { get; private set; }
    public int SumOfGearRatios { get; private set; }

    public bool _isNumberNextToSymbol = false;

    public EngineSchematic(string input)
    {
        _input = input;
        _schematic = _input.Split("\n");
        _gearCoordinates = new List<(int X, int Y)>();
        _gears = new Dictionary<(int X, int Y), List<int>>();

        Parse();
        CalculateSumOfGearRatios();
    }

    private void CalculateSumOfGearRatios()
    {
        SumOfGearRatios = _gears
            .Select(p => p.Value.Distinct().ToList())
            .Where(d => d.Count == 2)
            .Aggregate(0, (t, i) => t + (i[0] * i[1]));
    }

    private void Parse()
    {
        for (var y = 0; y < Height; y++)
        {
            var inNumber = false;
            var currentNumber = "";
            _isNumberNextToSymbol = false;

            for (var x = 0; x < Width; x++)
            {
                var currentValue = _schematic[y][x];
                if (char.IsDigit(currentValue))
                {
                    currentNumber += currentValue;
                    inNumber = true;

                    CheckForNumberNearGear(x - 1, y - 1);
                    CheckForNumberNearGear(x, y - 1);
                    CheckForNumberNearGear(x + 1, y - 1);

                    CheckForNumberNearGear(x - 1, y);
                    CheckForNumberNearGear(x + 1, y);

                    CheckForNumberNearGear(x - 1, y + 1);
                    CheckForNumberNearGear(x, y + 1);
                    CheckForNumberNearGear(x + 1, y + 1);
                }
                else
                {

                    if (inNumber)
                    {
                        if (_isNumberNextToSymbol)
                        {
                            var value = int.Parse(currentNumber);
                            SumOfParts += value;
                            AddCoordinatesToGears(value);
                        }
                    }

                    currentNumber = string.Empty;
                    inNumber = false;
                    _isNumberNextToSymbol = false;
                    _gearCoordinates.Clear();
                }
            }

            if (inNumber)
            {
                if (_isNumberNextToSymbol)
                {
                    var value = int.Parse(currentNumber);
                    SumOfParts += value;
                    AddCoordinatesToGears(value);
                }
            }
        }
    }

    private void CheckForNumberNearGear(int x, int y)
    {
        if (y >= 0 && y < Height && x >= 0 && x < Width)
        {
            if (IsSymbol(_schematic[y][x]))
            {
                AddIfSymbolIsGear(x, y);
                _isNumberNextToSymbol = true;
            }
        }
    }

    private void AddCoordinatesToGears(int value)
    {
        foreach (var coordinates in _gearCoordinates)
        {
            if (!_gears.ContainsKey(coordinates))
            {
                _gears.Add(coordinates, new List<int>());
            }
            _gears[coordinates].Add(value);
        }
    }

    private void AddIfSymbolIsGear(int x, int y)
    {
        if (_schematic[y][x] == '*')
        {
            _gearCoordinates.Add((x, y));
        }
    }

    private bool IsSymbol(char value)
    {
        return value != '.' && !char.IsDigit(value);
    }
}
