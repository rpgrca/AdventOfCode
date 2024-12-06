namespace Day5.Logic.Rules;

public class BackwardRuleCheck : RuleCheck
{
    public BackwardRuleCheck(Dictionary<int, List<int>> rules)
        : base(rules, (u, i) => u.Take(i))
    {
    }
}
