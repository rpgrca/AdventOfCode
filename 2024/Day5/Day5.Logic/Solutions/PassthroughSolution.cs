using System.Diagnostics;
using Day5.Logic.Rules;

namespace Day5.Logic.Solutions;

internal class PassthroughSolution : Solution
{
    public PassthroughSolution()
        : base(new Dictionary<int, List<int>>())
    {
    }

    protected override bool CalculateCondition(List<int> update, int index) =>
        throw new UnreachableException();

    protected override RuleCheck CreateRuleCheck(Dictionary<int, List<int>> rules) =>
        throw new UnreachableException();

    protected override int GetNextStep(int index) =>
        throw new UnreachableException();

    protected override int GetStart(List<int> update) =>
        throw new UnreachableException();

    protected override void InsertValueInSolution(List<int> solution, int value) =>
        throw new UnreachableException();

    public override List<int> Calculate(List<int> update) =>
        update;
}