
using System.Formats.Tar;

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
    public int SumOfMiddlePagesFromIncorrectUpdates { get; private set; }

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
        foreach (var update in _updates)
        {
            var brokenRule = BreaksRule(update);
            if (!brokenRule)
            {
                SumOfMiddlePagesFromCorrectUpdates += update[(update.Count / 2)];
            }
            else
            {
                var ordered = false;
                var possibleUpdate = update.ToList();
                var possibleSolution = new List<int>();
                while (! ordered)
                {
                    var foundCorrectPosition = false;
                    for (var index = 0; index < possibleUpdate.Count && !foundCorrectPosition; index++)
                    {
                        var page = possibleUpdate[index];
                        if (! BreaksAnyRuleToTheRight(possibleUpdate, index))
                        {
                            possibleSolution.Add(page);
                            possibleUpdate.Remove(page);
                            foundCorrectPosition = true;
                        }
                    }

                    if (possibleUpdate.Count == 0)
                    {
                        ordered = true;
                    }
                }

                possibleUpdate = update.ToList();
                var possibleSolution2 = new List<int>();
                ordered = false;
                while (! ordered)
                {
                    var foundCorrectPosition = false;
                    for (var index = possibleUpdate.Count - 1; index >= 0 && !foundCorrectPosition; index--)
                    {
                        var page = possibleUpdate[index];
                        if (! BreaksAnyRuleToTheLeft(possibleUpdate, index))
                        {
                            possibleSolution2.Insert(0, page);
                            possibleUpdate.Remove(page);
                            foundCorrectPosition = true;
                        }
                    }

                    if (possibleUpdate.Count == 0)
                    {
                        ordered = true;
                    }
                }

                if (!BreaksRule(possibleSolution))
                {
                    SumOfMiddlePagesFromIncorrectUpdates += possibleSolution[(possibleSolution.Count / 2)];
                }
                else
                {
                    if (! BreaksRule(possibleSolution2))
                    {
                        SumOfMiddlePagesFromIncorrectUpdates += possibleSolution2[(possibleSolution2.Count / 2)];
                    }
                    else
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                }
            }
        }
    }

    private bool BreaksRule(List<int> update)
    {
        var brokenRule = false;
        for (var index = 0; index < update.Count && !brokenRule; index++)
        {
            brokenRule = BreaksAnyRuleToTheRight(update, index) ||
                         BreaksAnyRuleToTheLeft(update, index);
        }

        return brokenRule;
    }

    private bool BreaksAnyRuleToTheRight(List<int> update, int index)
    {
        var brokenRule = false;
        if (_rules.TryGetValue(update[index], out var pagesComingAfter))
        {
            var nextPages = update.Skip(index + 1);
            if (nextPages.Any(p => !pagesComingAfter.Contains(p)))
            {
                brokenRule = true;
            }
        }

        return brokenRule;
    }

    private bool BreaksAnyRuleToTheLeft(List<int> update, int index)
    {
        var brokenRule = false;
        if (_forbiddenRules.TryGetValue(update[index], out var pagesComingBefore))
        {
            var previousPages = update.Take(index);
            if (previousPages.Any(p => !pagesComingBefore.Contains(p)))
            {
                brokenRule = true;
            }
        }

        return brokenRule;
    }

}
