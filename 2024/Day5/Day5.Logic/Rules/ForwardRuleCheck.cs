namespace Day5.Logic.Rules;

internal class ForwardRuleCheck : RuleCheck
{
    public ForwardRuleCheck(Dictionary<int, List<int>> rules)
        : base(rules, (u, i) => u.Skip(i + 1))
    {
    }
}
