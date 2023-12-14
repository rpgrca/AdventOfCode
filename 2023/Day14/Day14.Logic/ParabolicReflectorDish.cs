
namespace Day14.Logic;

public class ParabolicReflectorDish
{
    private readonly string _input;
    private readonly string[] _lines;

    public int Height { get; private set; } = 10;
    public int Width { get; private set; } = 10;

    public ParabolicReflectorDish(string input)
    {
        _input = input;
        _lines = input.Split("\n");
        Height = _lines.Length;
        Width = _lines[0].Length;
    }

}
