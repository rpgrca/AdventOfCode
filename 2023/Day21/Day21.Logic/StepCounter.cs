



using System.Runtime.CompilerServices;

namespace Day21.Logic;

public class StepCounter
{
    private readonly string _input;
    private readonly string[] _lines;

    public int Height => _lines.Length;
    public int Width => _lines[0].Length;

    public int StartingX { get; }
    public int StartingY { get; }
    public List<(int X, int Y)> CurrentPositions { get; private set; }

    public StepCounter(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                if (_lines[y][x] == 'S')
                {
                    StartingX = x;
                    StartingY = y;
                    goto StartLocationFound;
                }
            }
        }

        StartLocationFound:;
        CurrentPositions = new List<(int X, int Y)> { (StartingX, StartingY) };
    }

    public void Step()
    {
        var newPositions = new List<(int X, int Y)>();
        foreach (var position in CurrentPositions)
        {
            if (position.X - 1 >= 0)
            {
                if (_lines[position.Y][position.X - 1] == '.')
                {
                    var newPosition = (position.X - 1, position.Y);
                    if (! newPositions.Contains(newPosition))
                    {
                        newPositions.Add(newPosition);
                    }
                }
            }

            if (position.X + 1 < Width)
            {
                if (_lines[position.Y][position.X + 1] == '.')
                {
                    var newPosition = (position.X + 1, position.Y);
                    if (! newPositions.Contains(newPosition))
                    {
                        newPositions.Add(newPosition);
                    }
                }
            }

            if (position.Y - 1 >= 0)
            {
                if (_lines[position.Y - 1][position.X] == '.')
                {
                    var newPosition = (position.X, position.Y - 1);
                    if (! newPositions.Contains(newPosition))
                    {
                        newPositions.Add(newPosition);
                    }
                }
            }

            if (position.Y + 1 < Height)
            {
                if (_lines[position.Y + 1][position.X] == '.')
                {
                    var newPosition = (position.X, position.Y + 1);
                    if (! newPositions.Contains(newPosition))
                    {
                        newPositions.Add(newPosition);
                    }
                }
            }
        }

        CurrentPositions = newPositions;
    }
}
