


namespace Day17.Logic;

public class ClumsyCrucible
{
    private readonly string _input;
    private readonly string[] _lines;

    public int Width => _lines[0].Length;
    public int Height => _lines.Length;

    public (int X, int Y) Entrance { get; }
    public (int X, int Y) Goal { get; }

    public ClumsyCrucible(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        Entrance = (0, 0);
        Goal = (Width - 1, Height - 1);
    }
}
