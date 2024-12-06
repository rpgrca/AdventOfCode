namespace Day5.Logic;

public class RulesLoader
{
    private readonly string _input;
    public Dictionary<int, List<int>> Rules { get; }
    public Dictionary<int, List<int>> Exceptions { get; }

    public RulesLoader(string input)
    {
        _input = input;
        Rules = new();
        Exceptions = new();

        Load();
    }

    private void Load()
    {
        var lines = _input.Split('\n');
        foreach (var line in lines)
        {
            var rule = line.Split('|')
                .Select(int.Parse)
                .ToArray();

            AddRule(rule[0], rule[1]);
            AddException(rule[0], rule[1]);
        }
    }

    private void AddRule(int head, int tail)
    {
        if (! Rules.ContainsKey(head))
        {
            Rules.Add(head, new List<int>());
        }
        Rules[head].Add(tail);
    }

    private void AddException(int head, int tail)
    {
        if (! Exceptions.ContainsKey(tail))
        {
            Exceptions.Add(tail, new List<int>());
        }
        Exceptions[tail].Add(head);
    }
}
