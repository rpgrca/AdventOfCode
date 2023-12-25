

namespace Day25.Logic;

public class Snowverload
{
    private readonly string _input;
    private readonly string[] _lines;
    public int InputLength => _lines.Length;

    public Dictionary<string, List<string>> Components { get; }

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
    }
}
