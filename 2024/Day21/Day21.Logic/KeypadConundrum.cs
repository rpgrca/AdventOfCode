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
            var memoization = new Dictionary<string, int>();
            foreach (var line in _lines)
            {
                keypad.CountShortestSequence(line, memoization);
            }

            foreach (var value in memoization)
            {
                SumOfComplexities += value.Key.Length * value.Value;
            }
        }
    }
}