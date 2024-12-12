namespace Day5.Logic.Rules;

internal class BackwardRuleCheck : RuleCheck
{
    public BackwardRuleCheck(Dictionary<int, List<int>> rules)
        : base(rules, (u, i) => u.Take(i))
    {
    }
}
