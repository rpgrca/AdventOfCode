namespace Day13.Logic;

public class ClawContraptions
{
    private readonly string _input;
    private readonly ulong _adjust;
    private readonly List<((int OffsetX, int OffsetY) ButtonA, (int OffsetX, int OffsetY) ButtonB, (ulong X, ulong Y) Prize)> _contraptions;

    public List<((int OffsetX, int OffsetY) ButtonA, (int OffsetX, int OffsetY) ButtonB, (ulong X, ulong Y) Prize)> Contraptions => _contraptions;
    public int Count => _contraptions.Count;

    public int CheapestWin { get; private set; }

    public ClawContraptions(string input, ulong adjust = 0UL)
    {
        _input = input;
        _adjust = adjust;
        _contraptions = new();

        Parse();
        FindCheapestWin();
    }

    private void Parse()
    {
        var machines = _input.Split("\n\n");
        foreach (var machine in machines)
        {
            var data = machine.Split('\n').Select(p => p.Split(':'));
            (int, int) buttonA = default;
            (int, int) buttonB = default;
            (ulong, ulong) prize = default;
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
                        .Select(p => ulong.Parse(p[2..]))
                        .ToList();
                    prize = (info[0] + _adjust, info[1] + _adjust);
                }
            }

            _contraptions.Add((buttonA, buttonB, prize));
        }
    }

    private void FindCheapestWin()
    {
        foreach (var contraption in _contraptions)
        {
            int? cheapestWin = null;
            for (var a = 0; a <= 100; a++)
            {
                for (var b = 0; b <= 100; b++)
                {
                    if (((ulong)(contraption.ButtonA.OffsetX * a + contraption.ButtonB.OffsetX * b) == contraption.Prize.X) &&
                        ((ulong)(contraption.ButtonA.OffsetY * a + contraption.ButtonB.OffsetY * b) == contraption.Prize.Y))
                    {
                        var value = a * 3 + b;
                        if (! cheapestWin.HasValue || value < cheapestWin)
                        {
                            cheapestWin = value;
                        }
                    }
                }
            }


            if (cheapestWin.HasValue)
            {
                CheapestWin += cheapestWin.Value;
            }
        }
    }
}
