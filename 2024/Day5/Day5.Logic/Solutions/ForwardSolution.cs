using Day5.Logic.Rules;

namespace Day5.Logic.Solutions;

internal class ForwardSolution : Solution
{
    public ForwardSolution(Dictionary<int, List<int>> rules)
        : base(rules)
    {
    }

    protected override bool CalculateCondition(List<int> update, int index) =>
        index < update.Count;

    protected override RuleCheck CreateRuleCheck(Dictionary<int, List<int>> rules) =>
        new ForwardRuleCheck(rules);

    protected override int GetNextStep(int index) => index + 1;

    protected override int GetStart(List<int> update) => 0;

    protected override void InsertValueInSolution(List<int> solution, int value) =>
        solution.Add(value);
}