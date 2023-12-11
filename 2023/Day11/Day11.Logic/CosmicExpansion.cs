
namespace Day11.Logic;
public class CosmicExpansion
{
    private readonly string _input;
    private readonly string[] _lines;

    public CosmicExpansion(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
    }

    public int Width => _lines[0].Length;
    public int Height => _lines.Length;
}
