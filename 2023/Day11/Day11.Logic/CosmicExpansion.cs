
namespace Day11.Logic;

public class CosmicExpansion
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<List<char>> _expandedUniverse;
    private readonly List<(int X, int Y)> _galaxies;

    public CosmicExpansion(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _galaxies = new List<(int X, int Y)>();

        var expansionW = new List<int>();
        var expansionH = new List<int>();

        for (var y = 0; y < Height; y++)
        {
            var hasGalaxy = _lines[y].Any(p => p == '#');
            if (!hasGalaxy)
            {
                expansionH.Add(y);
            }
        }

        for (var x = 0; x < Width; x++)
        {
            var hasGalaxy = false;
            for (var y = 0; y < Height; y++)
            {
                if (_lines[y][x] == '#')
                {
                    hasGalaxy = true;
                }
            }

            if (!hasGalaxy)
            {
                expansionW.Add(x);
            }
        }


        _expandedUniverse = new List<List<char>>();
        for (var y = 0; y < Height; y++)
        {
            var temp = new List<char>();
            for (var x = 0; x < Width; x++)
            {
                temp.Add(_lines[y][x]);
                if (expansionW.Contains(x))
                {
                    temp.Add('.');
                }
            }

            _expandedUniverse.Add(temp);
            if (expansionH.Contains(y))
            {
                _expandedUniverse.Add(temp.Select(p => p).ToList());
            }
        }

        for (var y = 0; y < ExpandedHeight; y++)
        {
            for (var x = 0; x < ExpandedWidth; x++)
            {
                if (_expandedUniverse[y][x] == '#')
                {
                    _galaxies.Add((x, y));
                }
            }
        }
    }

    public int Width => _lines[0].Length;
    public int Height => _lines.Length;

    public int ExpandedWidth => _expandedUniverse[0].Count;
    public int ExpandedHeight => _expandedUniverse.Count;

    public int GalaxyCount => _galaxies.Count;

    public List<(int X, int Y)> Galaxies => _galaxies;

    public int CalculateDistanceBetween(int start, int end)
    {
        return Math.Abs(_galaxies[start].X - _galaxies[end].X) + Math.Abs(_galaxies[start].Y - _galaxies[end].Y);
    }
}
