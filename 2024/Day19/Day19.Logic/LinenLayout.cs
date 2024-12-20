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
    public ulong AllValidCombinations { get; private set; }

    public LinenLayout(string input)
    {
        _input = input;

        var sections = _input.Split("\n\n");
        _designs = sections[1].Split('\n').ToList();
        _towels = sections[0].Split(',', StringSplitOptions.TrimEntries)
            .Order()
            .Where(p => _designs.Any(q => q.Contains(p)))
            .ToList();

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
            var buildingTowel = string.Empty;
            Automata? previous = null;

            while (index < design.Length)
            {
                var towel = design[index];
                if (bag.TryGetValue(towel, out var next))
                {
                    if (next.Count == 0)
                    {
                        bag = _bag;
                        previous = null;
                    }
                    else
                    {
                        bag = next;
                        previous = bag;
                    }
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

            if (bag.FinalState && found)
            {
                ValidDesignsCount++;
            }
        }
    }

    public void ValidateWithStack()
    {
        foreach (var design in _designs)
        {
            var towels = _towels;
            var index = 0;
            var stack = new PriorityQueue<string, int>();
            var invalid = new HashSet<string>();
            stack.Enqueue(design, design.Length);

            do
            {
                var found = false;
                var leftOver = stack.Dequeue();
                if (leftOver.Length == 0)
                {
                    ValidDesignsCount++;
                    break;
                }

                if (invalid.Contains(leftOver))
                {
                    continue;
                }

                foreach (var towel in towels.Where(p => leftOver[0] == p[0]))
                {
                    if (leftOver.StartsWith(towel))
                    {
                        var still = leftOver[(index + towel.Length)..];
                        if (! invalid.Contains(still))
                        {
                            stack.Enqueue(still, still.Length);
                            found = true;
                        }
                    }
                }

                if (! found)
                {
                    invalid.Add(leftOver);
                }
            }
            while (stack.Count > 0);
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

    public void FindAllValidCombinationsWithStack3()
    {
        foreach (var design in _designs)
        {
            var towels = _towels.Where(p => design.Contains(p)).ToList();

            var index = 0;
            var stack = new PriorityQueue<string, int>();
            var invalid = new HashSet<string>();
            var solution = new HashSet<string>();

            stack.Enqueue(design, design.Length);

            do
            {
                var found = false;
                var leftOver = stack.Dequeue();
                /*
                if (leftOver.Length == 0)
                {
                    solution.Add(leftOver);
                    AllValidCombinations++;
                    continue;
                }*/

                if (invalid.Contains(leftOver))
                {
                    continue;
                }

                foreach (var towel in towels.Where(p => leftOver[0] == p[0] && leftOver.StartsWith(p)))
                {
                    var still = leftOver[(index + towel.Length)..];
                    if (still == "" || solution.Contains(still))
                    {
                        AllValidCombinations++;
                        found = true;
                    }
                    else if (! invalid.Contains(still))
                    {
                            stack.Enqueue(still, still.Length);
                            found = true;
                    }
                }

                if (! found)
                {
                    invalid.Add(leftOver);
                }
            }
            while (stack.Count > 0);
        }
    }

    public void FindAllValidCombinationsWithStack2()
    {
        foreach (var design in _designs)
        {
            var towels = _towels.Where(p => design.Contains(p)).ToList();

            var index = 0;
            var stack = new PriorityQueue<(string Already, string Left), int>();
            var invalid = new HashSet<string>();
            var solution = new HashSet<string>();

            stack.Enqueue((string.Empty, design), design.Length);

            do
            {
                var found = false;
                var leftOver = stack.Dequeue();
                if (leftOver.Left.Length == 0)
                {
                    if (! solution.Contains(leftOver.Already))
                    {
                        solution.Add(leftOver.Already);
                        AllValidCombinations++;
                    }
                    else
                    {
                        found = false;
                    }
                    continue;
                }

                if (invalid.Contains(leftOver.Left))
                {
                    continue;
                }

                foreach (var towel in towels.Where(p => leftOver.Left[0] == p[0] && leftOver.Left.StartsWith(p)))
                {
                    var still = leftOver.Left[(index + towel.Length)..];
                    if (! invalid.Contains(still))
                    {
                        stack.Enqueue((leftOver.Already + "-" + towel, still), still.Length);
                        found = true;
                    }
                }

                if (! found)
                {
                    invalid.Add(leftOver.Left);
                }
            }
            while (stack.Count > 0);
        }
    }

    public void FindAllValidCombinationsWithDynamicProgramming()
    {
        foreach (var design in _designs)
        {
            var towels = _towels.Where(p => design.Contains(p)).ToHashSet();
            var longestTowel = towels.Max(p => p.Length);
            var cache = new List<List<string>>[design.Length + 1];
            cache[0] = new List<List<string>>{ new() };

            for (var index = 1; index <= design.Length; index++)
            {
                cache[index] = new();
                for (var subIndex = Math.Max(0, index - longestTowel); subIndex < index; subIndex++)
                {
                    var syllable = design.Substring(subIndex, index - subIndex);
                    if (towels.Contains(syllable))
                    {
                        foreach (var combination in cache[subIndex])
                        {
                            var newCombination = new List<string>(combination) { syllable };
                            cache[index].Add(newCombination);
                        }
                    }
                }
            }

            AllValidCombinations = AllValidCombinations + (ulong)cache[design.Length].Count;
        }
    }

    public void FindAllValidCombinations()
    {
        foreach (var design in _designs)
        {
            var towels = _towels.Where(p => design.Contains(p)).ToHashSet();
            var longestTowel = towels.Max(p => p.Length);
            var cache = new ulong[design.Length + 1];
            cache[0] = 1;

            for (var index = 1; index <= design.Length; index++)
            {
                cache[index] = new();
                for (var subIndex = Math.Max(0, index - longestTowel); subIndex < index; subIndex++)
                {
                    var syllable = design.Substring(subIndex, index - subIndex);
                    if (towels.Contains(syllable))
                    {
                        cache[index] += cache[subIndex];
                    }
                }
            }

            AllValidCombinations += cache[design.Length];
        }
    }

}
