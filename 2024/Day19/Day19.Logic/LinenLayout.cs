

namespace Day19.Logic;

public class LinenLayout
{
    private readonly string _input;
    private List<string> _towels;
    private List<string> _designs;

    public int DesignsCount => _designs.Count;
    public int TowelsCount => _towels.Count;

    public LinenLayout(string input)
    {
        _input = input;
        var sections = _input.Split("\n\n");
        _towels = sections[0].Split(',', StringSplitOptions.TrimEntries).ToList();
        _designs = sections[1].Split('\n').ToList();
    }

}
