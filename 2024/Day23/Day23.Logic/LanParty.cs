namespace Day23.Logic;

public class LanParty
{
    private readonly string _input;
    private readonly string[] _lines;

    public int Count => _lines.Length;

    public LanParty(string input)
    {
        _input = input;
        _lines = _input.Split('\n');
    }
}
