
namespace Day19.Logic;

public class Rule
{
    private readonly string _input;

    public string Name { get; }

    private readonly List<Filter> _filters;

    public int ExpectedFilterCount => _filters.Count;

    public bool HasSuccessfulEndState { get; }
    public IEnumerable<Filter> Filters => _filters;

    public Rule(string input)
    {
        _input = input;
        _filters = new();

        var commands = _input.Split(new char[] { '{', '}' });
        Name = commands[0];
        var filters = commands[1].Split(",");
        foreach (var filter in filters)
        {
            var newFilter = new Filter(filter);
            if (newFilter.Result.StartsWith("A"))
            {
                HasSuccessfulEndState = true;
            }

            _filters.Add(newFilter);
        }
    }

    internal string Apply(Part part)
    {
        foreach (var filter in _filters)
        {
            var useThisRule = filter.Apply(part);
            if (useThisRule)
            {
                return filter.Result;
            }
        }

        throw new Exception("Invalid state reached");
    }
}
