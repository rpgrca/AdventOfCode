
namespace Day20.Logic;

public class PulsePropagation
{
    private readonly string _input;
    private readonly string[] _lines;

    public PulsePropagation(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
    }

    public int CommandsCount => _lines.Length;
}
