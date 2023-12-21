
namespace Day21.Logic;

public class StepCounter
{
    private readonly string _input;
    private readonly string[] _lines;

    public int Width => _lines.Length;

    public StepCounter(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
    }
}
