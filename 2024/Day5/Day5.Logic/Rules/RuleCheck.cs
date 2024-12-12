namespace Day5.Logic.Rules;

internal class RuleCheck : IRule
{
    private readonly Dictionary<int, List<int>> _rules;
    private readonly Func<List<int>, int, IEnumerable<int>> _pageRetriever;

    public RuleCheck(Dictionary<int, List<int>> rules, Func<List<int>, int, IEnumerable<int>> pageRetriever)
    {
        _rules = rules;
        _pageRetriever = pageRetriever;
    }

    public IResult BreaksAnyRule(List<int> update, int index)
    {
        IResult brokenRule = new IncorrectResult();
        if (_rules.TryGetValue(update[index], out var pages))
        {
            var nextPages = _pageRetriever(update, index);
            if (nextPages.Any(p => !pages.Contains(p)))
            {
                brokenRule = new CorrectResult();
            }
        }

        return brokenRule;
    }
}