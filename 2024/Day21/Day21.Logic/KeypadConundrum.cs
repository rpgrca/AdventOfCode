
namespace Day21.Logic;

public class KeypadConundrum
{
    private string _input;

    public List<int> Codes { get; set; }

    public KeypadConundrum(string input)
    {
        _input = input;
        Codes = _input.Split('\n').Select(p => int.Parse(p[0..^1])).ToList();
    }

}
