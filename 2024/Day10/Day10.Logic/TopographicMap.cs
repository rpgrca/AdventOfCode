

namespace Day10.Logic;

public class TopographicMap
{
    private readonly string _input;
    private readonly string[] _lines;

    public int Size => _lines.Length;
    public List<(int X, int Y)> Trailheads { get; private set; }

    public TopographicMap(string input)
    {
        _input = input;
        _lines = input.Split('\n');
        Trailheads = new();

        Parse();
    }

    private void Parse()
    {
        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                if (_lines[y][x] == '0')
                {
                    Trailheads.Add((x, y));
                }
            }
        }
    }
}
