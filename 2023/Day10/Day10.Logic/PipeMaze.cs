
namespace Day10.Logic;
public class PipeMaze
{
    private readonly string _input;
    private readonly string[] _lines;

    public PipeMaze(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
    }

    public int W => _lines[0].Length;
    public int H => _lines.Length;
}
