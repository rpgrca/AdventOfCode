using Day5.Logic.Solutions;
using Day5.Logic.Rules;

namespace Day5.Logic;

public class Printer
{
    private readonly string _input;
    private Dictionary<int, List<int>> _children;
    private Dictionary<int, List<int>> _parents;
    private List<List<int>> _updates;

    public int RuleCount => _children.Values.Aggregate(0, (t, i) => t + i.Count);
    public int UpdatesCount => _updates.Count;
    public int SumOfMiddlePagesFromCorrectUpdates { get; private set; }
    public int SumOfMiddlePagesFromIncorrectUpdates { get; private set; }

    public Printer(string input)
    {
        _input = input;
        _children = new();
        _parents = new();
        _updates = new List<List<int>>();

        ParseInput();
        CalculateSumOfMiddlePagesFromCorrectUpdates();
    }

    private void ParseInput()
    {
        var sections = _input.Split("\n\n");
        var rules = new RulesLoader(sections[0]);
        var updates = new UpdatesLoader(sections[1]);

        _children = rules.Rules;
        _parents = rules.Exceptions;
        _updates = updates.Updates;
    }

    private void CalculateSumOfMiddlePagesFromCorrectUpdates()
    {
        var steps = new List<(Func<Solution> Solution, Action<List<int>> Success)>()
        {
            (() => new PassthroughSolution(), u => SumOfMiddlePagesFromCorrectUpdates += u[u.Count / 2]),
            (() => new ForwardSolution(_children), u => SumOfMiddlePagesFromIncorrectUpdates += u[u.Count / 2]),
            (() => new BackwardSolution(_parents), u => SumOfMiddlePagesFromIncorrectUpdates += u[u.Count / 2])
        };

        foreach (var update in _updates)
        {
            var found = false;
            for (var index = 0; !found && index < steps.Count; index++)
            {
                var step = steps[index];
                var possibleSolution = step.Solution().Calculate(update);
                BreaksRule(possibleSolution)
                    .IfNot(() => {
                        step.Success(possibleSolution);
                        found = true;
                    });
            }
        }
    }

    private IResult BreaksRule(List<int> update)
    {
        IResult brokenRule = new IncorrectResult();
        for (var index = 0; index < update.Count && !brokenRule.AsBoolean(); index++)
        {
            new ForwardRuleCheck(_children)
                .BreaksAnyRule(update, index)
                .IfSo(() => brokenRule = new CorrectResult())
                .IfNot(() => {
                    new BackwardRuleCheck(_parents)
                    .BreaksAnyRule(update, index)
                    .IfSo(() => brokenRule = new CorrectResult());
                });
        }

        return brokenRule;
    }
}
