
namespace Day10.Logic;

public class TopographicMap
{
    private readonly string _input;
    private readonly string[] _lines;

    public TopographicMap(string input)
    {
        _input = input;
        _lines = input.Split('\n');
    }

    public int Size => _lines.Length;
}
