using System.Diagnostics;

namespace Day21.Logic;

[DebuggerDisplay("{XY} ({X}, {Y}) (in: {Dimensions.Count})")]
public class Tile
{
    public int XY => (Y << 8) | X;
    public int X { get; }
    public int Y { get; }
    public HashSet<int> Dimensions { get; }

    public Tile(int x, int y, int dimension)
        : this(x, y, new HashSet<int> { dimension })
    {
    }

    public Tile(int x, int y, HashSet<int> dimensions)
    {
        X = x;
        Y = y;
        Dimensions = dimensions;
    }

    internal void Merge(HashSet<int> dimensions)
    {
        Dimensions.UnionWith(dimensions);
    }
}

public class StepCounter
{
    private const int CenterMapX = 100;
    private const int CenterMapY = 100;
    private readonly string _input;
    private readonly string[] _lines;
    private readonly char[,] _map;
    private List<Tile> _steps;

    public int Height => _lines.Length;
    public int Width => _lines[0].Length;

    public int StartingX { get; }
    public int StartingY { get; }

    public (int X, int Y)[] CurrentPositions => _steps.Select(s => (s.X, s.Y)).ToArray();

    public StepCounter(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _steps = new List<Tile>();
        _map = new char[Height, Width];

        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                if (_lines[y][x] == 'S')
                {
                    StartingX = x;
                    StartingY = y;
                    _map[y, x] = '.';
                }
                else
                {
                    _map[y,x] = _lines[y][x];
                }
            }
        }

        var tile = new Tile(StartingX, StartingY, CenterMapY << 8 | CenterMapY);
        _steps.Add(tile);
    }

    public void Step(int steps = 1)
    {
        while (steps-- > 0)
        {
            var newPositions = new List<Tile>();
            var cache = new Dictionary<int, Tile>();
            foreach (var position in _steps)
            {
                if (position.X - 1 >= 0)
                {
                    if (_map[position.Y, position.X - 1] == '.')
                    {
                        var codedPosition = (position.Y << 8) | (position.X - 1);
                        if (! cache.ContainsKey(codedPosition))
                        {
                            var newPosition = new Tile(position.X - 1, position.Y, position.Dimensions);
                            newPositions.Add(newPosition);
                            cache.Add(codedPosition, newPosition);
                        }
                        else
                        {
                            cache[codedPosition].Merge(position.Dimensions);
                        }
                    }
                }
                else
                {
                    if (_map[position.Y, Width - 1] == '.')
                    {
                        var newDimensions = position.Dimensions.Select(d => ((d >> 8) << 8) | ((d & 0xff) - 1)).ToHashSet();
                        var codedPosition = (position.Y << 8) | (Width - 1);
                        if (! cache.ContainsKey(codedPosition))
                        {
                            var newPosition = new Tile(Width - 1, position.Y, newDimensions);
                            newPositions.Add(newPosition);
                            cache.Add(codedPosition, newPosition);
                        }
                        else
                        {
                            cache[codedPosition].Merge(newDimensions);
                        }
                    }
                }

                if (position.X + 1 < Width)
                {
                    if (_map[position.Y, position.X + 1] == '.')
                    {
                        var codedPosition = (position.Y << 8) | (position.X + 1);
                        if (! cache.ContainsKey(codedPosition))
                        {
                            var newPosition = new Tile(position.X + 1, position.Y, position.Dimensions);
                            newPositions.Add(newPosition);
                            cache.Add(codedPosition, newPosition);
                        }
                        else
                        {
                            cache[codedPosition].Merge(position.Dimensions);
                        }
                    }
                }
                else
                {
                    if (_map[position.Y, 0] == '.')
                    {
                        var newDimensions = position.Dimensions.Select(d => ((d >> 8) << 8) | ((d & 0xff) + 1)).ToHashSet();
                        var codedPosition = (position.Y << 8) | 0;
                        if (! cache.ContainsKey(codedPosition))
                        {
                            var newPosition = new Tile(0, position.Y, newDimensions);
                            newPositions.Add(newPosition);
                            cache.Add(codedPosition, newPosition);
                        }
                        else
                        {
                            cache[codedPosition].Merge(newDimensions);
                        }
                    }
                }

                if (position.Y - 1 >= 0)
                {
                    if (_map[position.Y - 1, position.X] == '.')
                    {
                        var codedPosition = ((position.Y - 1) << 8) | position.X;
                        if (! cache.ContainsKey(codedPosition))
                        {
                            var newPosition = new Tile(position.X, position.Y - 1, position.Dimensions);
                            newPositions.Add(newPosition);
                            cache.Add(codedPosition, newPosition);
                        }
                        else
                        {
                            cache[codedPosition].Merge(position.Dimensions);
                        }
                    }
                }
                else
                {
                    if (_map[Height - 1, position.X] == '.')
                    {
                        var newDimensions = position.Dimensions.Select(d => (((d >> 8) - 1) << 8) | (d & 0xff)).ToHashSet();
                        var codedPosition = ((Height - 1) << 8) | position.X;
                        if (! cache.ContainsKey(codedPosition))
                        {
                            var newPosition = new Tile(position.X, Height - 1, newDimensions);
                            newPositions.Add(newPosition);
                            cache.Add(codedPosition, newPosition);
                        }
                        else
                        {
                            cache[codedPosition].Merge(newDimensions);
                        }
                    }
                }

                if (position.Y + 1 < Height)
                {
                    if (_map[position.Y + 1, position.X] == '.')
                    {
                        var codedPosition = ((position.Y + 1) << 8) | position.X;
                        if (! cache.ContainsKey(codedPosition))
                        {
                            var newPosition = new Tile(position.X, position.Y + 1, position.Dimensions);
                            newPositions.Add(newPosition);
                            cache.Add(codedPosition, newPosition);
                        }
                        else
                        {
                            cache[codedPosition].Merge(position.Dimensions);
                        }
                    }
                }
                else
                {
                    if (_map[0, position.X] == '.')
                    {
                        var newDimensions = position.Dimensions.Select(d => (((d >> 8) + 1) << 8) | (d & 0xff)).ToHashSet();
                        var codedPosition = (0 << 8) | position.X;
                        if (! cache.ContainsKey(codedPosition))
                        {
                            var newPosition = new Tile(position.X, 0, newDimensions);
                            newPositions.Add(newPosition);
                            cache.Add(codedPosition, newPosition);
                        }
                        else
                        {
                            cache[codedPosition].Merge(newDimensions);
                        }
                    }
                }
            }

            _steps = newPositions;
        }
    }

    public ulong CountCurrentPositions()
    {
        return (ulong)_steps.LongCount();
    }
}
