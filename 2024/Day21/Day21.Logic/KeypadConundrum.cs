namespace Day21.Logic;

public class KeypadConundrum
{
    private readonly string[] _lines;

    public List<int> Codes { get; set; }
    public string ShortestSequence { get; private set; }
    public int SumOfComplexities { get; private set;}

    public KeypadConundrum(string input, IKeypadTyping keypad)
    {
        _lines = input.Split('\n');

        Codes = _lines.Select(p => int.Parse(p[0..^1])).ToList();
        ShortestSequence = string.Empty;

        foreach (var line in _lines)
        {
            var shortestSequence = keypad.CalculateShortestSequence(line);
            SumOfComplexities += string.Concat(shortestSequence).Length * int.Parse(line[..^1]);
        }
    }
}