
namespace Day7.Logic;
public class CamelCards
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<(string, int)> _hands;

    public int Hands => _hands.Count;

    public CamelCards(string input)
    {
        _input = input;
        _lines = input.Split("\n");
        _hands = new List<(string, int)>();

        Parse();
    }

    private void Parse()
    {
        foreach (var line in _lines)
        {
            var splittedLine = line.Split(" ");
            _hands.Add((splittedLine[0].Trim(), int.Parse(splittedLine[1])));
        }
    }
}
