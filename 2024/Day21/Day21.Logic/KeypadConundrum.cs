namespace Day21.Logic;

public class KeypadConundrum
{
    private readonly string[] _lines;

    public List<int> Codes { get; set; }
    public ulong SumOfComplexities { get; private set;}

    public KeypadConundrum(string input, IKeypadTyping keypad, bool onlyCount = false)
    {
        _lines = input.Split('\n');

        Codes = _lines.Select(p => int.Parse(p[0..^1])).ToList();

        if (! onlyCount)
        {
            foreach (var line in _lines)
            {
                var shortestSequence = keypad.CalculateShortestSequence(line);
                SumOfComplexities += (ulong)shortestSequence.Length * ulong.Parse(line[..^1]);
            }
        }
        else
        {
            foreach (var line in _lines)
            {
                var memoization = new Dictionary<string, long>();
                keypad.CountShortestSequence(line, memoization);

                var shortestSequenceLength = (ulong)memoization.Select(p => p.Key.Length * p.Value).Sum();
                SumOfComplexities += (ulong)shortestSequenceLength * ulong.Parse(line[..^1]);
            }
        }
    }
}