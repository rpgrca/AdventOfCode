
namespace Day23.Logic;

public class LongWalk
{
    private readonly string _input;
    private readonly string[] _lines;

    public LongWalk(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
    }

    public int Width => _lines[0].Length;
    public int Height => _lines.Length;
}
