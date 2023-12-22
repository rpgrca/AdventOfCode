namespace Day22.Logic;

public class Brick
{
    public (int X, int Y, int Z) Start { get; init; }
    public (int X, int Y, int Z) End { get; init; }
}

public class SandSlabs
{
    private readonly string _input;
    private readonly string[] _lines;
    public int BrickCount => _lines.Length;

    public List<Brick> Bricks { get; set; }

    public SandSlabs(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        Bricks = new List<Brick>();

        foreach (var line in _lines)
        {
            var points = line.Split("~")
                .Select(p => p.Split(",").Select(int.Parse).ToArray())
                .Select(d => (d[0], d[1], d[2]))
                .ToArray();

            Bricks.Add(new Brick { Start = points[0], End = points[1] });
        }
    }
}
