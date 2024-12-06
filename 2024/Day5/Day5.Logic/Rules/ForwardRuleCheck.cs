namespace Day5.Logic.Rules;

public class ForwardRuleCheck : RuleCheck
{
    public ForwardRuleCheck(Dictionary<int, List<int>> rules)
        : base(rules, (u, i) => u.Skip(i + 1))
    {
    }
}
