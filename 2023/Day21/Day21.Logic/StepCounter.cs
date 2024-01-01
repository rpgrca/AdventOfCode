using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using Microsoft.VisualBasic;

namespace Day21.Logic;

[DebuggerDisplay("{XY} ({X}, {Y}) (in: {Dimensions.Count})")]
public class Tile
{
    public int XY => (Y << 8) | X;
    public int X { get; }
    public int Y { get; }
    public HashSet<int> Dimensions { get; private set; }

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
        Dimensions = new HashSet<int>(Dimensions);
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
    private Dictionary<int, string> _beforePreviousState;
    private readonly Dictionary<int, int> _fullDimensions;

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
        _beforePreviousState = new Dictionary<int, string>();
        _fullDimensions = new Dictionary<int, int>();

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

        var tile = new Tile(StartingX, StartingY, (CenterMapY << 8) | CenterMapX);
        _steps.Add(tile);
        _beforePreviousState.Add((CenterMapY << 8) | CenterMapX, MapToString((CenterMapY << 8) | CenterMapX));
    }

    public void Step(int steps = 1)
    {
        var currentStep = 0;
        while (currentStep++ < steps)
        {
            var dimensions = new HashSet<int>();
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
                        var newDimensions = position.Dimensions.Select(d => ((d >> 8) << 8) | ((d & 0xff) - 1)).Except(_fullDimensions.Keys).ToHashSet();
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
                        var newDimensions = position.Dimensions.Select(d => ((d >> 8) << 8) | ((d & 0xff) + 1)).Except(_fullDimensions.Keys).ToHashSet();
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
                        var newDimensions = position.Dimensions.Select(d => (((d >> 8) - 1) << 8) | (d & 0xff)).Except(_fullDimensions.Keys).ToHashSet();
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
                        var newDimensions = position.Dimensions.Select(d => (((d >> 8) + 1) << 8) | (d & 0xff)).Except(_fullDimensions.Keys).ToHashSet();
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

            if (currentStep % 33 == 0)
            {
                var filledDimensions = newPositions.SelectMany(p => p.Dimensions).GroupBy(q => q).Where(p => p.Count() == 42).Select(p => p.Key).ToHashSet();
                foreach (var filledDimension in filledDimensions)
                {
                    _fullDimensions.Add(filledDimension, currentStep);
                }

                foreach (var position in newPositions)
                {
                    position.Dimensions.RemoveWhere(p => filledDimensions.Contains(p));
                }
            }

            _steps = newPositions;
        }
    }

    public ulong CountCurrentPositions(int steps)
    {
        var result = (ulong)_steps.Sum(s => s.Dimensions.Count);

        foreach (var fillDimension in _fullDimensions)
        {
            if (fillDimension.Value % 2 == 0)
            {
                if (steps % 2 == 0)
                {
                    result += 42;
                }
                else
                {
                    result += 39;
                }
            }
            else
            {
                if (steps % 2 == 1)
                {
                    result += 42;
                }
                else
                {
                    result += 39;
                }
            }
        }

        return result;
    }

    public void Draw()
    {
        var hashSet = new HashSet<int>();
        foreach (var step in _steps)
        {
            foreach (var dimension in step.Dimensions)
            {
                if (! hashSet.Contains(dimension))
                {
                    hashSet.Add(dimension);
                }
            }
        }

        hashSet.Order();
        foreach (var dimension in hashSet)
        {
            var map = MapToString(dimension);
            Console.WriteLine($"{dimension} ({dimension & 0xff},{dimension >> 8})\n{map}");
            Debug.Print($"{dimension} ({dimension & 0xff},{dimension >> 8})\n{map}");
        }
    }

    private string MapToString(int dimension)
    {
        var map = new StringBuilder();
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                var tile = _steps.SingleOrDefault(p => p.X == x && p.Y == y && p.Dimensions.Contains(dimension));
                if (tile != null)
                {
                    map.Append('O');
                }
                else
                {
                    map.Append(_map[y, x]);
                }
            }

            map.Append('\n');
        }

        return map.ToString();
    }
}
