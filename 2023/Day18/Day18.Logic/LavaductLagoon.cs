using System.Data;
using System.Runtime.CompilerServices;

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
    public int TrenchArea { get; private set; }

    public LavaductLagoon(string input, int length = 100)
    {
        _input = input;
        _lines = _input.Split("\n");
        _map = new char[length][];
        _length = length;
        _initialX = _length / 3;
        _initialY = _length / 3;

        for (var index = 0; index < _length; index++)
        {
            _map[index] = new string('.', _length).ToCharArray();
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

        CalculatePerimeter();
        Draw();
        CalculateArea();
        Draw();
    }

    public void Draw()
    {
        foreach (var row in _map)
        {
            Console.WriteLine(string.Join("", row.Select(c => c)));
        }
    }

    private void CalculatePerimeter()
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

    private void CalculateArea()
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
        if (_map[y][x] == '.')
        {
            _map[y][x] = '#';
            if (x + 1 < _length)
            {
                FillArea(x + 1, y); // r
            }

            if (x - 1 >= 0)
            {
                FillArea(x - 1, y); // l
            }

            if (y + 1 < _length)
            {
                FillArea(x, y + 1); // d
            }

            if (y - 1 >= 0)
            {
                FillArea(x, y - 1); // u
            }
        }
    }

}
