
namespace Day12.Logic;

public class HotSprings
{
    private readonly string _input;
    private readonly string[] _lines;

    public HotSprings(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
    }

    public int RowCount => _lines.Length;
}
