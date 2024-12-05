
namespace Day5.Logic;

public class Printer
{
    private readonly string _input;
    private readonly Dictionary<int, List<int>> _rules;
    private readonly List<List<int>> _updates;

    public Printer(string input)
    {
        _input = input;
        _rules = new Dictionary<int, List<int>>();
        _updates = new List<List<int>>();

        ParseInput();
    }

    public int RuleCount => _rules.Values.Aggregate(0, (t, i) => t + i.Count);
    public int UpdatesCount => _updates.Count;

    private void ParseInput()
    {
        var lines = _input.Split("\n");
        var loadingRules = true;

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                loadingRules = false;
                continue;
            }

            if (loadingRules)
            {
                var rule = line.Split('|').Select(int.Parse).ToArray();
                if (! _rules.ContainsKey(rule[0]))
                {
                    _rules.Add(rule[0], new List<int>());
                }

                _rules[rule[0]].Add(rule[1]);
            }
            else
            {
                _updates.Add(line.Split(',').Select(int.Parse).ToList());
            }
        }
    }
}
