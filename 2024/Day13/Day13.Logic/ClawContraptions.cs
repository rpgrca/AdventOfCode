
namespace Day13.Logic;

public class ClawContraptions
{
    private readonly string _input;
    private readonly List<((int OffsetX, int OffsetY) ButtonA, (int OffsetX, int OffsetY) ButtonB, (int X, int Y) Prize)> _contraptions;

    public List<((int OffsetX, int OffsetY) ButtonA, (int OffsetX, int OffsetY) ButtonB, (int X, int Y) Prize)> Contraptions => _contraptions;
    public int Count => _contraptions.Count;

    public ClawContraptions(string input)
    {
        _input = input;
        _contraptions = new();
        Parse();
    }

    private void Parse()
    {
        var machines = _input.Split("\n\n");
        foreach (var machine in machines)
        {
            var data = machine.Split('\n').Select(p => p.Split(':'));
            (int, int) buttonA = default;
            (int, int) buttonB = default;
            (int, int) prize = default;
            foreach (var dat in data)
            {
                if (dat[0] == "Button A")
                {
                    var info = dat[1].Split(',', StringSplitOptions.TrimEntries)
                        .Select(p => int.Parse(p[2..]))
                        .ToList();
                    buttonA = (info[0], info[1]);
                }
                else if (dat[0] == "Button B")
                {
                    var info = dat[1].Split(',', StringSplitOptions.TrimEntries)
                        .Select(p => int.Parse(p[2..]))
                        .ToList();
                    buttonB = (info[0], info[1]);
                }
                else if (dat[0] == "Prize")
                {
                    var info = dat[1].Split(',', StringSplitOptions.TrimEntries)
                        .Select(p => int.Parse(p[2..]))
                        .ToList();
                    prize = (info[0], info[1]);
                }
            }

            _contraptions.Add((buttonA, buttonB, prize));
        }
    }
}
