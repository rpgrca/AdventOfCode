
namespace Day20.Logic;

public class RaceCondition
{
    private readonly string _input;
    private readonly string[] _lines;

    public int Size => _lines.Length;

    public RaceCondition(string input)
    {
        _input = input;
        _lines = _input.Split('\n').ToArray();
    }
}
