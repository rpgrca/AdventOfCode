
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
