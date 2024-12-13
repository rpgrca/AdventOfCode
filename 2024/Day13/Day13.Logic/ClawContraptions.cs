namespace Day13.Logic;

public class ClawContraptions
{
    private readonly string _input;
    private readonly long _adjust;
    private readonly List<((long X, long Y) A, (long X, long Y) B, (long X, long Y) Prize)> _contraptions;

    public List<((long X, long Y) A, (long X, long Y) B, (long X, long Y) Prize)> Contraptions => _contraptions;
    public int Count => _contraptions.Count;
    public long CheapestWin { get; private set; }


    public ClawContraptions(string input, long? adjust = null)
    {
        _input = input;
        _contraptions = new();
        if (adjust.HasValue)
        {
            _adjust = adjust.Value;
        }
        else
        {
            _adjust = 0;
        }

        Parse();
        FindCheapestWin();
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

    private void FindCheapestWin()
    {
        foreach (var contraption in _contraptions)
        {
            if (ApplyCramersRule(contraption.A.X, contraption.B.X, contraption.A.Y, contraption.B.Y, contraption.Prize.X, contraption.Prize.Y, out (long A, long B) result))
            {
                CheapestWin += result.A * 3 + result.B;
            }
        }
    }

    /*
     * a b e
     * c d f
     */
    private bool ApplyCramersRule(long a, long b, long c, long d, long e, long f, out (long X, long Y) result)
    {
        var determinant = a * d - b * c;
        if (determinant != 0)
        {
            var numerator = e * d - b * f;
            var (x, firstRemainder) = Math.DivRem(numerator, determinant);
            if (firstRemainder == 0)
            {
                numerator = a * f - e * c;
                var (y, secondRemainder) = Math.DivRem(numerator, determinant);
                if (secondRemainder == 0)
                {
                    CheapestWin += x * 3 + y;
                }
            }
        }

        result = default;
        return false;
    }
}
