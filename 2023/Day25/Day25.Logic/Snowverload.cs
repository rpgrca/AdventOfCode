


namespace Day25.Logic;

public class Snowverload
{
    private readonly string _input;
    private readonly string[] _lines;
    public int InputLength => _lines.Length;

    public Dictionary<string, List<string>> Components { get; }
    public List<(string Left, string Right)> WeakLinks { get; }

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
            foreach (var target in targets)
            {
                var bypass = false;
                var grandchildren = Components[target];
                foreach (var grandchild in grandchildren.Where(p => p != target))
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
        }

        return false;
    }
}
