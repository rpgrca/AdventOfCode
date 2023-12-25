



namespace Day25.Logic;

public class Snowverload
{
    private readonly string _input;
    private readonly string[] _lines;
    public int InputLength => _lines.Length;

    public Dictionary<string, List<string>> Components { get; }
    public List<(string Left, string Right)> WeakLinks { get; }
    public int SizeMultiplication { get; private set; }

    public Snowverload(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        Components = new Dictionary<string, List<string>>();
        foreach (var line in _lines)
        {
            var values = line.Split(": ");
            var components = values[1].Split(" ");
            foreach (var component in components)
            {
                if (! Components.ContainsKey(component))
                {
                    Components.Add(component, new List<string>());
                }

                Components[component].Add(values[0]);
            }

            if (! Components.ContainsKey(values[0]))
            {
                Components.Add(values[0], new List<string>());
            }

            Components[values[0]].AddRange(components);
        }

        WeakLinks = new List<(string Left, string Right)>();
        foreach (var (source, targets) in Components)
        {
           foreach (var target in targets.Where(p => p != source))
            {
                var bypass = false;
                var grandchildren = Components[target];
                foreach (var grandchild in grandchildren.Where(p => p != target && p != source))
                {
                    bypass = ExistsBypassFrom(source, grandchild, target);
                    if (bypass)
                    {
                        break;
                    }
                }

                if (! bypass)
                {
                    if (!WeakLinks.Contains((source, target)) && !WeakLinks.Contains((target, source)))
                    {
                        WeakLinks.Add((source, target));
                    }
                }
            }
        }

        SizeMultiplication = 1;
        for (var first = 0; first < WeakLinks.Count - 2; first++)
        {
            for (var second = first + 1; second < WeakLinks.Count - 1; second++)
            {
                for (var third = second + 1; third < WeakLinks.Count; third++)
                {
                    var transition1 = WeakLinks[first];
                    var transition2 = WeakLinks[second];
                    var transition3 = WeakLinks[third];

                    Components[transition1.Left].Remove(transition1.Right);
                    Components[transition1.Right].Remove(transition1.Left);
                    Components[transition2.Left].Remove(transition2.Right);
                    Components[transition2.Right].Remove(transition2.Left);
                    Components[transition3.Left].Remove(transition3.Right);
                    Components[transition3.Right].Remove(transition3.Left);

                    var groups = SplitInGroups();
                    if (groups.Length == 2)
                    {
                        SizeMultiplication = groups[0].Count * groups[1].Count;
                    }

                    Components[transition1.Left].Add(transition1.Right);
                    Components[transition1.Right].Add(transition1.Left);
                    Components[transition2.Left].Add(transition2.Right);
                    Components[transition2.Right].Add(transition2.Left);
                    Components[transition3.Left].Add(transition3.Right);
                    Components[transition3.Right].Add(transition3.Left);
                }
            }
        }
    }

    private bool ExistsBypassFrom(string source, string target, string skipping)
    {
        var level1s = Components[source];
        if (level1s.Contains(target))
        {
            return true;
        }

        foreach (var level2 in level1s.Where(p => p != skipping))
        {
            if (level2 == target)
            {
                return true;
            }

            foreach (var level3 in Components[level2].Where(p => p != skipping))
            {
                if (level3 == target)
                {
                    return true;
                }
            }
        }

        return false;
    }

    private HashSet<string>[] SplitInGroups()
    {
        var result = new List<HashSet<string>>();
        var node = Components.ElementAt(0).Key;
        var visited = new HashSet<string>() { node };

        int result2 = CountNodes(node, visited, Components);

        if (result2 == Components.Count)
        {
            return Array.Empty<HashSet<string>>();
        }
        else
        {
            var leftOvers = Components.Where(p => !visited.Contains(p.Key)).ToDictionary(p => p.Key, q => q.Value);
            var visited2 = new HashSet<string>();
            node = leftOvers.ElementAt(0).Key;
            int result3 = CountNodes(node, visited2, leftOvers);
            if (result3 == leftOvers.Count)
            {
                return new HashSet<string>[] { visited, visited2 };
            }
            else
            {
                return Array.Empty<HashSet<string>>();
            }
        }
    }

    private int CountNodes(string root, HashSet<string> visited, Dictionary<string, List<string>> components)
    {
        var accumulated = 0;

        foreach (var node in components[root].Except(visited))
        {
            if (! visited.Contains(node))
            {
                visited.Add(node);
                accumulated++;
            }

            accumulated += CountNodes(node, visited, components);
        }

        return accumulated;
    }
}
