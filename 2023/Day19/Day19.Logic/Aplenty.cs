namespace Day19.Logic;

public class Aplenty
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly Dictionary<string, Rule> _rules;
    private readonly List<Part> _parts;

    public Aplenty(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _rules = new Dictionary<string, Rule>();
        _parts = new List<Part>();

        var inRules = true;
        foreach (var line in _lines)
        {
            if (string.IsNullOrEmpty(line))
            {
                inRules = false;
            }
            else
            {
                if (inRules)
                {
                    var rule = new Rule(line);
                    _rules.Add(rule.Name, rule);
                }
                else
                {
                    _parts.Add(new Part(line));
                }
            }
        }
    }

    public int PartCount => _parts.Count;
    public int RuleCount => _rules.Count;

    public int SumOfAcceptedParts { get; private set; }

    public void Execute()
    {
        foreach (var part in _parts)
        {
            var nextRule = "in";
            while (nextRule != "A" && nextRule != "R")
            {
                nextRule = _rules[nextRule].Apply(part);
            }

            if (nextRule == "A")
            {
                SumOfAcceptedParts += part.X + part.M + part.A + part.S;
            }
        }
    }
}


public class Rule
{
    private readonly string _input;

    public string Name { get; }

    private readonly List<Filter> _filters;

    public int ExpectedFilterCount => _filters.Count;

    public Rule(string input)
    {
        _input = input;
        _filters = new();

        var commands = _input.Split(new char[] { '{', '}' });
        Name = commands[0];
        var filters = commands[1].Split(",");
        foreach (var filter in filters)
        {
            _filters.Add(new Filter(filter));
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

public class Filter
{
    private readonly string _input;
    private readonly Func<Part, bool> _method;

    public Filter(string input)
    {
        _input = input;
        if (_input.Contains('<'))
        {
            var values = _input.Split('<');
            var jump = values[1].Split(':');
            _method = p => p.Values[values[0][0]] < int.Parse(jump[0]);
            Result = jump[1];
        }
        else if (_input.Contains('>'))
        {
            var values = _input.Split('>');
            var jump = values[1].Split(':');
            _method = p => p.Values[values[0][0]] > int.Parse(jump[0]);
            Result = jump[1];
        }
        else
        {
            _method = p => true;
            Result = input;
        }
    }

    public string Result { get; internal set; }

    internal bool Apply(Part part) => _method(part);
}