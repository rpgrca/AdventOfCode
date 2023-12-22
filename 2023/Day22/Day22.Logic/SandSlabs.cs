
namespace Day22.Logic;

public class SandSlabs
{
    private readonly string _input;
    private readonly string[] _lines;
    public int BrickCount => _lines.Length;

    public SandSlabs(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
    }
}
