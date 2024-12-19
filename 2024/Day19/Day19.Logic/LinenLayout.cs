


namespace Day19.Logic;

public class LinenLayout
{
    private readonly string _input;
    private List<string> _towels;
    private List<string> _designs;

    public int DesignsCount => _designs.Count;
    public int TowelsCount => _towels.Count;
    public int ValidDesignsCount { get; private set; }

    public LinenLayout(string input)
    {
        _input = input;
        var sections = _input.Split("\n\n");
        _towels = sections[0].Split(',', StringSplitOptions.TrimEntries).Order().ToList();
        _designs = sections[1].Split('\n').ToList();
    }

    public void Validate()
    {
        foreach (var design in _designs)
        {
            var piece = design;
            var length = piece.Length;
            var start = 0;

            if (FindTowelCombination(design, start))
            {
                ValidDesignsCount++;
            }
        }
    }

    private bool FindTowelCombination(string design, int start)
    {
        foreach (var towel in _towels)
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
}
