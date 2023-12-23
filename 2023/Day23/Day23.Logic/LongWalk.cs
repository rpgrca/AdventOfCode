namespace Day23.Logic;

public class LongWalk
{
    private readonly string _input;
    private readonly string[] _lines;

    public int Width => _lines[0].Length;
    public int Height => _lines.Length;
    public (int X, int Y) StartingPosition { get; set; }
    public (int X, int Y) EndingPosition { get; set; }

    public LongWalk(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        StartingPosition = (_lines[0].IndexOf("."), 0);
        EndingPosition = (_lines[Height - 1].IndexOf("."), Height - 1);
    }

}
