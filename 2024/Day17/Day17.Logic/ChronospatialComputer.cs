
namespace Day17.Logic;

public class ChronospatialComputer
{
    private readonly string _input;
    private readonly List<int> _program;

    public ChronospatialComputer(string input)
    {
        _input = input;
        var sections = _input.Split("\n\n");
        foreach (var section in sections[0].Split('\n'))
        {
            var words = section.Split(':', StringSplitOptions.TrimEntries);
            switch (words[0][^1])
            {
                case 'A': A = long.Parse(words[1]); break;
                case 'B': B = long.Parse(words[1]); break;
                case 'C': C = long.Parse(words[1]); break;
            }
        }

        var programs = sections[1].Split(':', StringSplitOptions.TrimEntries);
        _program = programs[1].Split(',').Select(int.Parse).ToList();
    }

    public long A { get; private set; }
    public long B { get; private set; }
    public long C { get; private set; }
    public int Length => _program.Count;
}
