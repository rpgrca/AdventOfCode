


using System.IO.Compression;

namespace Day16.Logic;
public class TheFloorWillBeLava
{
    private struct Beam
    {
        public int X;
        public int Y;
        public char Orientation;
    }

    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<char[]> _map;
    private readonly List<char[]> _energizedMap;

    public int Width => _lines[0].Length;
    public int Height => _lines.Length;

    public string GetEnergizedMap()
    {
        return string.Join("\n", _energizedMap.Select(p => new string(p)));
    }

    public TheFloorWillBeLava(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        _map = new List<char[]>();
        foreach (var line in _lines)
        {
            _map.Add(line.Select(c => c).ToArray());
        }

        _energizedMap = new List<char[]>();
        for (var index = 0; index < Height; index++)
        {
            _energizedMap.Add(Enumerable.Range(1, Width).Select(p => '.').ToArray());
        }
    }

    public void Energize()
    {
        var beam = new Beam { Orientation = 'r' };
        do
        {
            _energizedMap[beam.Y][beam.X] = '#';
            switch (_map[beam.Y][beam.X])
            {
                case '.':
                    switch (beam.Orientation)
                    {
                        case 'r':
                            beam.X++;
                            break;
                        case 'd':
                            beam.Y++;
                            break;
                    }
                    break;

                case '/':
                    switch (beam.Orientation)
                    {
                        case 'r':
                            beam.Y--;
                            beam.Orientation = 'u';
                            break;
                    }
                    break;

                case '\\':
                    switch (beam.Orientation)
                    {
                        case 'r':
                            beam.Y++;
                            beam.Orientation = 'd';
                            break;
                    }
                    break;

                case '-':
                    switch (beam.Orientation)
                    {
                        case 'r':
                            beam.X++;
                            break;
                    }
                    break;

                case '|':
                    switch (beam.Orientation)
                    {
                        case 'r':
                            beam.Y++;
                            beam.Orientation = 'd';
                            break;

                        case 'd':
                            beam.Y++;
                            break;
                    }
                    break;
            }
        }
        while (beam.X >= 0 && beam.X < Width && beam.Y >= 0 && beam.Y < Height);
    }
}
