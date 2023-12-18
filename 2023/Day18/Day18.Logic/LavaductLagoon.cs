
namespace Day18.Logic;

public class LavaductLagoon
{
    private readonly string _input;
    private readonly string[] _lines;

    public LavaductLagoon(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
    }

    public int DigPlanLength => _lines.Length;
}
