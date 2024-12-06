using Day5.Logic.Rules;

namespace Day5.Logic.Solutions;

internal abstract class Solution : ISolution
{
    protected readonly Dictionary<int, List<int>> _rules;

    protected abstract RuleCheck CreateRuleCheck(Dictionary<int, List<int>> rules);
    protected abstract int GetStart(List<int> update);
    protected abstract bool CalculateCondition(List<int> update, int index);
    protected abstract int GetNextStep(int index);
    protected abstract void InsertValueInSolution(List<int> solution, int value);

    public Solution(Dictionary<int, List<int>> rules) => _rules = rules;

    public virtual List<int> Calculate(List<int> update)
    {
        var mutableUpdate = update.ToList();
        var guessedSolution = new List<int>();
        var ruleCheck = CreateRuleCheck(_rules);

        do
        {
            var next = true;
            for (var index = GetStart(mutableUpdate); next && CalculateCondition(mutableUpdate, index); index = GetNextStep(index))
            {
                var page = mutableUpdate[index];
                ruleCheck.BreaksAnyRule(mutableUpdate, index)
                    .IfNot(() =>
                    {
                        InsertValueInSolution(guessedSolution, page);
                        mutableUpdate.Remove(page);
                        next = false;
                    });
            }
        }
        while (mutableUpdate.Count > 0);

        return guessedSolution;
    }
}