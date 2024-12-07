using Day5.Logic.Rules;

namespace Day5.Logic;

public abstract class Printer
{
    private readonly string _input;
    protected Dictionary<int, List<int>> _children;
    protected Dictionary<int, List<int>> _parents;
    private List<List<int>> _updates;

    public int RuleCount => _children.Values.Aggregate(0, (t, i) => t + i.Count);
    public int UpdatesCount => _updates.Count;
    public int SumOfMiddlePages { get; protected set; }

    public static Printer WithoutReordering(string input) =>
        new PrinterWithoutReordering(input);

    public static Printer WithReordering(string input) =>
        new PrinterWithReordering(input);

    protected Printer(string input)
    {
        _input = input;
        _children = new();
        _parents = new();
        _updates = new List<List<int>>();

        ParseInput();
    }

    private void ParseInput()
    {
        var sections = _input.Split("\n\n");
        var rules = new RulesLoader(sections[0]);

        _children = rules.Rules;
        _parents = rules.Exceptions;
        _updates = new UpdatesLoader(sections[1]).Updates;
    }

    protected void CalculateSumOfMiddlePages()
    {
        foreach (var update in _updates)
        {
            BreaksRule(update)
                .IfNot(() => {
                    PassthroughSolutionDoesNotBreakRule(update);
                })
                .IfSo(() => {
                    PassthroughSolutionBreaksRule(update);
                });
        }
    }

    protected IResult BreaksRule(List<int> update)
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

    protected abstract void PassthroughSolutionBreaksRule(List<int> update);

    protected abstract void PassthroughSolutionDoesNotBreakRule(List<int> solution);
}
