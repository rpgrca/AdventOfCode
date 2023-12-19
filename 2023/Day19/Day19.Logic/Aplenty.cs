

using System.Security.Cryptography.X509Certificates;

namespace Day19.Logic;

public class Aplenty
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<string> _rules;
    private readonly List<string> _parts;

    public Aplenty(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _rules = new List<string>();
        _parts = new List<string>();

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
                    _rules.Add(line);
                }
                else
                {
                    _parts.Add(line);
                }
            }
        }
    }

    public int PartCount => _parts.Count;
    public int RuleCount => _rules.Count;
}


public class Rule
{
    private readonly string _input;

    public string Name { get; }

    private readonly string[] _filters;

    public int ExpectedFilterCount => _filters.Length;

    public Rule(string input)
    {
        _input = input;
        var commands = _input.Split(new char[] { '{', '}' });
        Name = commands[0];
        _filters = commands[1].Split(",");
    }
}

public class Part
{
    private readonly string _input;

    public int X { get; }
    public int M { get; }
    public int A { get; }
    public int S { get; }

    public Part(string input)
    {
        _input = input;
        var values = input[1..^1].Split(",");
        foreach (var value in values)
        {
            var pair = value.Split("=");
            var amount = int.Parse(pair[1]);
            switch (pair[0])
            {
                case "x": X = amount; break;
                case "m": M = amount; break;
                case "a": A = amount; break;
                case "s": S = amount; break;
            }
        }
    }
}