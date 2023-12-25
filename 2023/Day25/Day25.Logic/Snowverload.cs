
namespace Day25.Logic;

public class Snowverload
{
    private readonly string _input;
    private readonly string[] _lines;
    public int ComponentCount => _lines.Length;

    public Snowverload(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
    }
}
