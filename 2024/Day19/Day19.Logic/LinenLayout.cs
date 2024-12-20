namespace Day19.Logic;

public class Automata : Dictionary<char, Automata>
{
    public bool FinalState;
}

public class LinenLayout
{
    private readonly string _input;
    private List<string> _towels;
    private List<string> _designs;
    private int _longestTowel;
    private readonly Automata _bag;

    public int DesignsCount => _designs.Count;
    public int TowelsCount => _towels.Count;
    public int ValidDesignsCount { get; private set; }

    public LinenLayout(string input)
    {
        _input = input;

        var sections = _input.Split("\n\n");
        _towels = sections[0].Split(',', StringSplitOptions.TrimEntries).Order().ToList();
        _designs = sections[1].Split('\n').ToList();
        _longestTowel = _towels.OrderByDescending(p => p.Length).First().Length;

        _bag = new();
        foreach (var towel in _towels)
        {
            var current = _bag;
            var previous = current;
            foreach (var color in towel)
            {
                if (! current.ContainsKey(color))
                {
                    current.Add(color, new());
                }

                previous = current;
                current = current[color];
            }

            previous.FinalState = true;
        }
    }

    public void ValidateWithAutomata()
    {
        foreach (var design in _designs)
        {
            var bag = _bag;
            var found = true;
            var index = 0;
            Automata? previous = null;

            while (index < design.Length)
            {
                var towel = design[index];
                if (bag.TryGetValue(towel, out var next))
                {
                    previous = bag;
                    bag = next;
                }
                else
                {
                    if (bag.Count > 0)
                    {
                        found = false;
                        break;
                    }

                    if (previous != null && previous.FinalState)
                    {
                        previous = null;
                        bag = _bag;
                        continue;
                    }

                    previous = null;
                    bag = _bag;
                    continue;
                }

                index++;
            }

            if (found)
            {
                ValidDesignsCount++;
            }
        }
    }

    public void Validate()
    {
        var index = 0;
        foreach (var design in _designs)
        {
            var piece = design;
            var start = 0;

            if (FindTowelCombination(design, start))
            {
                ValidDesignsCount++;
                Console.WriteLine($"OK - {design} ({index}/{_designs.Count})");
            }
            else
            {
                Console.WriteLine($"ERR- {design} ({index}/{_designs.Count})");
            }
        }
    }

    private bool FindTowelCombination(string design, int start)
    {
        foreach (var towel in FindBestMatches(design[start..]))
        {
            if (design[start..].StartsWith(towel))
            {
                if (start + towel.Length == design.Length)
                {
                    return true;
                }

                if (FindTowelCombination(design, start + towel.Length))
                {
                    return true;
                }
            }
        }

        return false;
    }

    private IEnumerable<string> FindBestMatches(string design)
    {
        var maximum = design.Length > _longestTowel ? _longestTowel : design.Length;
        for (var length = maximum; length > 0; length--)
        {
            foreach (var towel in _towels.Where(p => p == design.Substring(0, length)))
            {
                yield return towel;
            }
        }
    }
}
