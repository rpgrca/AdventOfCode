using System.Collections;
using System.Data;

namespace Day18.Logic;

public class LavaductLagoon
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly char[][] _map;
    private readonly int _length;
    private readonly int _initialX;
    private readonly int _initialY;

    public int DigPlanLength => _lines.Length;

    public int TrenchPerimeter { get; private set; }
    public long TrenchArea { get; private set; }
    public List<(int Length, char Direction)> RealInstructions { get; }

    public LavaductLagoon(string input, int length = 100, bool create = true)
    {
        _input = input;
        _lines = _input.Split("\n");
        _length = length;
        _initialX = _length / 3;
        _initialY = _length / 3;
        RealInstructions = new List<(int, char)>();

        if (create)
        {
            _map = new char[length][];
            for (var index = 0; index < _length; index++)
            {
                _map[index] = new string('.', _length).ToCharArray();
            }
        }
    }

    public void Decode()
    {
        foreach (var line in _lines)
        {
            var command = line.Split(" ");
            var hex = command[2][1..^1];
            var direction = hex[^1] switch {
                '0' => 'R',
                '1' => 'D',
                '2' => 'L',
                _ => 'U'
            };
            var length = Convert.ToInt32(hex[1..^1], 16);

            RealInstructions.Add((length, direction));
        }
    }

    public void Dig()
    {
        int steps;
        var currentX = _initialX;
        var currentY = _initialY;

        foreach (var line in _lines)
        {
            var command = line.Split(" ");
            steps = int.Parse(command[1]);

            switch (command[0])
            {
                case "R":
                    steps += currentX;
                    while (currentX < steps)
                    {
                        _map[currentY][currentX++] = '#';
                    }
                    break;

                case "D":
                    steps += currentY;
                    while (currentY < steps)
                    {
                        _map[currentY++][currentX] = '#';
                    }
                    break;

                case "L":
                    steps = currentX - steps;
                    while (currentX > steps)
                    {
                        _map[currentY][currentX--] = '#';
                    }
                    break;

                case "U":
                    steps = currentY - steps;
                    while (currentY > steps)
                    {
                        _map[currentY--][currentX] = '#';
                    }
                    break;
            }
        }
    }

    public void Draw()
    {
        foreach (var row in _map)
        {
            Console.WriteLine(string.Join("", row.Select(c => c)));
        }
    }

    public void CalculatePerimeter()
    {
        TrenchPerimeter = 0;
        for (var y = 0; y < _length; y++)
        {
            for (var x = 0; x < _length; x++)
            {
                if (_map[y][x] == '#')
                {
                    TrenchPerimeter++;
                }
            }
        }
    }

    public void CalculateArea()
    {
        FillArea(_initialX + 1, _initialY + 1);
        TrenchArea = 0;
        for (var y = 0; y < _length; y++)
        {
            for (var x = 0; x < _length; x++)
            {
                if (_map[y][x] == '#')
                {
                    TrenchArea++;
                }
            }
        }
    }

    private void FillArea(int x, int y)
    {
        var visited = new HashSet<(int, int)>();
        if (visited.Contains((x, y)))
        {
            return;
        }

        visited.Add((x, y));
        if (_map[y][x] == '.')
        {
            _map[y][x] = '#';
            if (x + 1 < _length && !visited.Contains((x + 1, y)))
            {
                FillArea(x + 1, y); // r
            }

            if (x - 1 >= 0 && !visited.Contains((x - 1, y)))
            {
                FillArea(x - 1, y); // l
            }

            if (y + 1 < _length && !visited.Contains((x, y + 1)))
            {
                FillArea(x, y + 1); // d
            }

            if (y - 1 >= 0 && !visited.Contains((x, y - 1)))
            {
                FillArea(x, y - 1); // u
            }
        }
    }

    public void CalculateArea2()
    {
        var array = Enumerable.Range(0, 5_000_000).Select(p => new SortedList<int, (int Begin, int End)>()).ToArray();
        var currentX = _initialX;
        var currentY = _initialY;

        foreach (var instruction in RealInstructions)
        {
            switch (instruction.Direction)
            {
                case '0': // r
                    array[currentY].Add(currentX, (currentX, currentX + instruction.Length));
                    currentX += instruction.Length;
                    break;

                case '1': // d
                    for (var index = currentY; index < currentY + instruction.Length; index++)
                    {
                        array[index].Add(currentX, (currentX, currentX));
                    }
                    currentY += instruction.Length;
                    break;

                case '2': // l
                    var previous = currentX - instruction.Length;
                    array[currentY].Add(previous, (previous, currentX));
                    currentX = previous;
                    break;

                case '3': // u
                    for (var index = currentY; index > currentY - instruction.Length; index--)
                    {
                        array[index].Add(currentX, (currentX, currentX));
                    }
                    currentY -= instruction.Length;
                    break;
            }
        }
    }
}
