namespace Day5.Logic;

public class PrinterWithoutReordering : Printer
{
    public PrinterWithoutReordering(string input) : base(input) =>
        CalculateSumOfMiddlePages();

    protected override void PassthroughSolutionBreaksRule(List<int> update)
    {
    }

    protected override void PassthroughSolutionDoesNotBreakRule(List<int> solution)
    {
        SumOfMiddlePages += solution[solution.Count / 2];
    }
}