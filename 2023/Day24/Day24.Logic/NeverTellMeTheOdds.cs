



namespace Day24.Logic;

public class Hail
{
    public ulong X { get; }
    public ulong Y { get; }
    public ulong Z { get; }
    public int Vx { get; }
    public int Vy { get; }
    public int Vz { get; }
    public ((ulong, ulong, ulong), (int, int, int)) Data => ((X, Y, Z), (Vx, Vy, Vz));

    public Hail(ulong x, ulong y, ulong z, int vx, int vy, int vz)
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
            Hails.Add(new Hail(ulong.Parse(positions[0]), ulong.Parse(positions[1]), ulong.Parse(positions[2]),
                int.Parse(velocities[0]), int.Parse(velocities[1]), int.Parse(velocities[2])));
        }
    }

    public void IntersectBetween(ulong @from, ulong to)
    {
        for (var index = 0; index < Hails.Count - 1; index++)
        {
            for (var subIndex = index + 1; subIndex < Hails.Count; subIndex++)
            {
                var areParallel = Hails[index].Vx / Hails[subIndex].Vx == Hails[index].Vy / Hails[subIndex].Vy;
                if (areParallel)
                {
                    continue;
                }
                else
                {
                    Intersections++;
                }
            }
        }
    }
}
