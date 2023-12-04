
namespace Day4.Logic;
public class Scratchcards
{
    private readonly string _input;
    private readonly string[] _scratchcards;
    private readonly List<int[]> _winningValues;
    private readonly List<int[]> _ownedValues;

    public int Amount => _scratchcards.Length;
    public int WinningAmount => _winningValues[0].Length;
    public int OwnedAmount => _ownedValues[0].Length;

    public Scratchcards(string input)
    {
        _input = input;
        _winningValues = new List<int[]>();
        _ownedValues = new List<int[]>();
        _scratchcards = _input.Split("\n");

        Parse();
    }

    private void Parse()
    {
        foreach (var line in _scratchcards)
        {
            var splittedLine = line.Split(":");
            var amounts = splittedLine[1].Split("|");
            _winningValues.Add(amounts[0]
                .Split(" ")
                .Where(p => !string.IsNullOrEmpty(p))
                .Select(int.Parse)
                .ToArray());

            _ownedValues.Add(amounts[1]
                .Split(" ")
                .Where(p => !string.IsNullOrEmpty(p))
                .Select(int.Parse)
                .ToArray());
        }
    }
}
