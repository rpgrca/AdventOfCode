using Day5.Logic.Solutions;

namespace Day5.Logic;

internal class PrinterWithReordering : Printer
{
    private readonly List<Func<Dictionary<int, List<int>>, Dictionary<int, List<int>>, Solution>> _validators;

    public PrinterWithReordering(string input) : base(input)
    {
        _validators = new List<Func<Dictionary<int, List<int>>, Dictionary<int, List<int>>, Solution>>
        {
            (_, c) => new ForwardSolution(c),
            (p, _) => new BackwardSolution(p)
        };

        CalculateSumOfMiddlePages();
    }

    protected override void PassthroughSolutionBreaksRule(List<int> update)
    {
        var next = true;
        foreach (var step in _validators)
        {
            var possibleSolution = step(_parents, _children).Calculate(update);
            BreaksRule(possibleSolution)
                .IfNot(() => {
                    SumOfMiddlePages += possibleSolution[possibleSolution.Count / 2];
                    next = false;
                });

            if (! next) break;
        }
    }

    protected override void PassthroughSolutionDoesNotBreakRule(List<int> solution)
    {
    }
}