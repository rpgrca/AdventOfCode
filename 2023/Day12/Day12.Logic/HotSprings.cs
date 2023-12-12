namespace Day12.Logic;

public class HotSprings
{
    private readonly string _input;
    private readonly string[] _lines;

    public int RowCount => _lines.Length;

    public List<(string Map, int[] Groups)> Rows { get; private set; }

    public HotSprings(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        Rows = new List<(string Map, int[] Groups)>();

        foreach (var line in _lines)
        {
            var values = line.Split(" ");
            Rows.Add((values[0], values[1].Split(",").Select(int.Parse).ToArray()));
        }
    }

}
