



namespace Day24.Logic;

public class Hail
{
    public long X { get; }
    public long Y { get; }
    public long Z { get; }
    public int Vx { get; }
    public int Vy { get; }
    public int Vz { get; }
    public ((long, long, long), (int, int, int)) Data => ((X, Y, Z), (Vx, Vy, Vz));

    public Hail(long x, long y, long z, int vx, int vy, int vz)
    {
        X = x;
        Y = y;
        Z = z;
        Vx = vx;
        Vy = vy;
        Vz = vz;
    }
}

public class NeverTellMeTheOdds
{
    private readonly string _input;
    private readonly string[] _lines;

    public int HailCount => _lines.Length;

    public List<Hail> Hails { get; }
    public int Intersections { get; set; }

    public NeverTellMeTheOdds(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        Hails = new List<Hail>();

        foreach (var line in _lines)
        {
            var values = line.Split(" @ ");
            var positions = values[0].Split(",");
            var velocities = values[1].Split(",");
            Hails.Add(new Hail(long.Parse(positions[0]), long.Parse(positions[1]), long.Parse(positions[2]),
                int.Parse(velocities[0]), int.Parse(velocities[1]), int.Parse(velocities[2])));
        }
    }

    public void IntersectBetween(ulong @from, ulong to)
    {
        for (var index = 0; index < Hails.Count - 1; index++)
        {
            for (var subIndex = index + 1; subIndex < Hails.Count; subIndex++)
            {
                var x1 = Hails[index].X;
                var x2 = Hails[index].X + Hails[index].Vx;
                var x3 = Hails[subIndex].X;
                var x4 = Hails[subIndex].X + Hails[subIndex].Vx;
                var y1 = Hails[index].Y;
                var y2 = Hails[index].Y + Hails[index].Vy;
                var y3 = Hails[subIndex].Y;
                var y4 = Hails[subIndex].Y + Hails[subIndex].Vy;

                var denominator = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
                if (denominator == 0)
                {
                    continue;
                }

                var px = ((x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4)) / (double)denominator;
                var py = ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / (double)denominator;

                if (px >= @from && px <= to && py >= @from && py <= to)
                {
                    Intersections++;
                }
            }
        }
    }
}
