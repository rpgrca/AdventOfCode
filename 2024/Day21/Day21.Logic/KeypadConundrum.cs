namespace Day21.Logic;

public class KeypadConundrum
{
    private readonly string[] _lines;

    public List<int> Codes { get; set; }
    public int SumOfComplexities { get; private set;}

    public KeypadConundrum(string input, IKeypadTyping keypad, bool onlyCount = false)
    {
        _lines = input.Split('\n');

        Codes = _lines.Select(p => int.Parse(p[0..^1])).ToList();

        if (! onlyCount)
        {
            foreach (var line in _lines)
            {
                var shortestSequence = keypad.CalculateShortestSequence(line);
                SumOfComplexities += shortestSequence.Length * int.Parse(line[..^1]);
            }
        }
        else
        {
            foreach (var line in _lines)
            {
                var memoization = new Dictionary<string, int>();
                keypad.CountShortestSequence(line, memoization);

                var shortestSequenceLength = memoization.Select(p => p.Key.Length * p.Value).Sum();
                SumOfComplexities = shortestSequenceLength * int.Parse(line[..^1]);
            }
        }
    }
}