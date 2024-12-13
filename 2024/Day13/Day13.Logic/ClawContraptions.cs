using System.Runtime.Intrinsics.X86;

namespace Day13.Logic;

public class ClawContraptions
{
    private readonly string _input;
    private readonly long _adjust;
    private readonly bool _adjusting;
    private readonly List<((long OffsetX, long OffsetY) ButtonA, (long OffsetX, long OffsetY) ButtonB, (long X, long Y) Prize)> _contraptions;

    public List<((long OffsetX, long OffsetY) ButtonA, (long OffsetX, long OffsetY) ButtonB, (long X, long Y) Prize)> Contraptions => _contraptions;
    public int Count => _contraptions.Count;

    public long CheapestWin { get; private set; }

    public ClawContraptions(string input, long? adjust = null)
    {
        _input = input;
        _contraptions = new();
        if (adjust.HasValue)
        {
            _adjust = adjust.Value;
            _adjusting = true;
        }
        else
        {
            _adjust = 0;
            _adjusting = false;
        }

        Parse();

        if (_adjusting)
        {
            FindCheapestWin2();
        }
        else
        {
            FindCheapestWin();
        }
    }

    private void Parse()
    {
        var machines = _input.Split("\n\n");
        foreach (var machine in machines)
        {
            var data = machine.Split('\n').Select(p => p.Split(':'));
            (long, long) buttonA = default;
            (long, long) buttonB = default;
            (long, long) prize = default;
            foreach (var dat in data)
            {
                if (dat[0] == "Button A")
                {
                    var info = dat[1].Split(',', StringSplitOptions.TrimEntries)
                        .Select(p => long.Parse(p[2..]))
                        .ToList();
                    buttonA = (info[0], info[1]);
                }
                else if (dat[0] == "Button B")
                {
                    var info = dat[1].Split(',', StringSplitOptions.TrimEntries)
                        .Select(p => long.Parse(p[2..]))
                        .ToList();
                    buttonB = (info[0], info[1]);
                }
                else if (dat[0] == "Prize")
                {
                    var info = dat[1].Split(',', StringSplitOptions.TrimEntries)
                        .Select(p => long.Parse(p[2..]))
                        .ToList();
                    prize = (info[0] + _adjust, info[1] + _adjust);
                }
            }

            _contraptions.Add((buttonA, buttonB, prize));
        }
    }

    private void FindCheapestWin2()
    {
        foreach (var contraption in _contraptions)
        {
            var determinant = (long)(contraption.ButtonA.OffsetX*contraption.ButtonB.OffsetY - contraption.ButtonB.OffsetX*contraption.ButtonA.OffsetY);
            if (determinant != 0)
            {
                var numerator = contraption.Prize.X*contraption.ButtonB.OffsetY - contraption.ButtonB.OffsetX*contraption.Prize.Y;
                var a = numerator / determinant;
                if (a * determinant == numerator)
                {
                    numerator = contraption.ButtonA.OffsetX*contraption.Prize.Y - contraption.Prize.X*contraption.ButtonA.OffsetY;
                    var b = numerator / determinant;
                    if (b * determinant == numerator)
                    {
                        CheapestWin += (long)a*3 + (long)b;
                    }
                }
            }
        }
    }

    private void FindCheapestWin()
    {
        foreach (var contraption in _contraptions)
        {
            long? cheapestWin = null;
            for (long a = 0; a <= 100; a++)
            {
                for (long b = 0; b <= 100; b++)
                {
                    if (((contraption.ButtonA.OffsetX * a + contraption.ButtonB.OffsetX * b) == contraption.Prize.X) &&
                        ((contraption.ButtonA.OffsetY * a + contraption.ButtonB.OffsetY * b) == contraption.Prize.Y))
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
