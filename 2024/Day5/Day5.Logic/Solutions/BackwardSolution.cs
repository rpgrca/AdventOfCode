using Day5.Logic.Rules;

namespace Day5.Logic.Solutions;

internal class BackwardSolution : Solution
{
    public BackwardSolution(Dictionary<int, List<int>> rules) :
        base(rules)
    {
    }

    protected override bool CalculateCondition(List<int> update, int index) =>
        index >= 0;

    protected override RuleCheck CreateRuleCheck(Dictionary<int, List<int>> rules) =>
        new BackwardRuleCheck(rules);

    protected override int GetNextStep(int index) => index - 1;

    protected override int GetStart(List<int> update) => update.Count - 1;

    protected override void InsertValueInSolution(List<int> solution, int value) =>
        solution.Insert(0, value);
}