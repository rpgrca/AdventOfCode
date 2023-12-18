using System.Runtime.CompilerServices;

namespace Day18.Logic;

public class LavaductLagoon
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly char[][] _map;
    private readonly int _length;


    public int DigPlanLength => _lines.Length;

    public int TrenchPerimeter { get; private set; }

    public LavaductLagoon(string input, int length = 100)
    {
        _input = input;
        _lines = _input.Split("\n");
        _map = new char[length][];
        _length = length;

        for (var index = 0; index < _length; index++)
        {
            _map[index] = new string('.', _length).ToCharArray();
        }
    }

    public void Dig()
    {
        int steps;
        var currentX = _length / 3;
        var currentY = _length / 3;

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
}
