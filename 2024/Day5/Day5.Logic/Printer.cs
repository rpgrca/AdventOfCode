

using Microsoft.VisualBasic;

namespace Day5.Logic;

public class Printer
{
    private readonly string _input;
    private readonly Dictionary<int, List<int>> _rules;
    private readonly Dictionary<int, List<int>> _forbiddenRules;
    private readonly List<List<int>> _updates;

    public Printer(string input)
    {
        _input = input;
        _rules = new Dictionary<int, List<int>>();
        _forbiddenRules = new Dictionary<int, List<int>>();
        _updates = new List<List<int>>();

        ParseInput();
        CalculateSumOfMiddlePagesFromCorrectUpdates();
    }

    public int RuleCount => _rules.Values.Aggregate(0, (t, i) => t + i.Count);
    public int UpdatesCount => _updates.Count;
    public int SumOfMiddlePagesFromCorrectUpdates { get; private set; }

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

                if (! _forbiddenRules.ContainsKey(rule[1]))
                {
                    _forbiddenRules.Add(rule[1], new List<int>());
                }
                _forbiddenRules[rule[1]].Add(rule[0]);
            }
            else
            {
                _updates.Add(line.Split(',').Select(int.Parse).ToList());
            }
        }
    }

    private void CalculateSumOfMiddlePagesFromCorrectUpdates()
    {
        var brokenRule = false;
        foreach (var update in _updates)
        {
            brokenRule = false;
            for (var index = 0; index < update.Count; index++)
            {
                if (_rules.TryGetValue(update[index], out var pagesComingAfter))
                {
                    var nextPages = update.Skip(index + 1);
                    if (nextPages.Any(p => !pagesComingAfter.Contains(p)))
                    {
                        brokenRule = true;
                        break;
                    }
                }

                if (_forbiddenRules.TryGetValue(update[index], out var pagesComingBefore))
                {
                    var previousPages = update.Take(index);
                    if (previousPages.Any(p => !pagesComingBefore.Contains(p)))
                    {
                        brokenRule = true;
                        break;
                    }
                }
            }

            if (! brokenRule)
            {
                SumOfMiddlePagesFromCorrectUpdates += update[(update.Count / 2)];
            }
        }
    }
}
