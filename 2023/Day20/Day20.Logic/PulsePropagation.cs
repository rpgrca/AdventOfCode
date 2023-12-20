

namespace Day20.Logic;

public class PulsePropagation
{
    private readonly string _input;
    private readonly string[] _lines;

    public PulsePropagation(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        var flipflops = new HashSet<string>();
        var conjuntions = new HashSet<string>();

        foreach (var line in _lines)
        {
            var command = line.Split(" -> ");
            if (command[0][0] == '%')
            {
                FlipFlopCount++;
                flipflops.Add(command[0][1..]);
            }
            else
            if (command[0][0] == '&')
            {
                ConjuntionCount++;
                conjuntions.Add(command[0][1..]);
            }
        }

        foreach (var line in _lines)
        {
            var command = line.Split(" -> ");
            var targets = command[1].Split(",");
            foreach (var target in targets.Select(p => p.Trim()))
            {
                if (!flipflops.Contains(target) && !conjuntions.Contains(target))
                {
                    UnnamedCount++;
                }
            }
        }
    }

    public int CommandsCount => _lines.Length;

    public int FlipFlopCount { get; set; }
    public int ConjuntionCount { get; set; }
    public int UnnamedCount { get; set; }
}
