



namespace Day24.Logic;

public class Hail
{
    public double X { get; }
    public double Y { get; }
    public double Z { get; }
    public double Vx { get; }
    public double Vy { get; }
    public double Vz { get; }
    public ((double, double, double), (double, double, double)) Data => ((X, Y, Z), (Vx, Vy, Vz));

    public Hail(double x, double y, double z, double vx, double vy, double vz)
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
            Hails.Add(new Hail(double.Parse(positions[0]), double.Parse(positions[1]), double.Parse(positions[2]),
                double.Parse(velocities[0]), double.Parse(velocities[1]), double.Parse(velocities[2])));
        }
    }

    public void IntersectBetween(double @from, double to)
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

                var slope1 = (y2 - y1) / (double)(x2 - x1);
                var b1 = y1 - (slope1 * x1);
                var slope2 = (y4 - y3) / (double)(x4 - x3);
                var b2 = y3 - (slope2 * x3);

                var denominator = (x1 - x2) * (y3 - y4) - (y1 - y2) * (x3 - x4);
                if (denominator == 0)
                {
                    continue;
                }

                var px = ((x1 * y2 - y1 * x2) * (x3 - x4) - (x1 - x2) * (x3 * y4 - y3 * x4)) / denominator;
                var py = ((x1 * y2 - y1 * x2) * (y3 - y4) - (y1 - y2) * (x3 * y4 - y3 * x4)) / denominator;

                if (@from <= px && px <= @to && @from <= py && py <= @to)
                {
                    if (((px > x1 && x2 > x1) || (px < x1 && x2 < x1)) && ((px > x3 && x4 > x3) || (px < x3 && x4 < x3)))
                    {
                        Intersections++;
                    }

//                    var pointDistance = Math.Pow(x1 - px, 2) + Math.Pow(y1 - py, 2);
//                    var offsetDistance = Math.Pow(x2 - px, 2) + Math.Pow(y2 - py, 2);
//
//                    if (offsetDistance <= pointDistance)
//                    {
//                        pointDistance = Math.Pow(x3 - px, 2) + Math.Pow(y3 - py, 2);
//                        offsetDistance = Math.Pow(x4 - px, 2) + Math.Pow(y4 - py, 2);
//                        if (offsetDistance <= pointDistance)
//                        {
//                            Intersections++;
//                        }
//                        /*
//                        else
//                        {
//                            var x5 = x4 + Hails[subIndex].Vx;
//                            var y5 = y4 + Hails[subIndex].Vy;
//                            var offsetDistance2 = Math.Pow(x5 - px, 2) + Math.Pow(y5 - py, 2);
//                            if (offsetDistance2 > offsetDistance)
//                            {
//                                Intersections++;
//                            }
//                        }*/
//                    }/*
//                    else if (offsetDistance == pointDistance)
//                    {
//                        var x5 = offsetDistance + Hails[index].Vx;
//                        var y5 = offsetDistance + Hails[index].Vy;
//
//                        var secondOffsetDistance = Math.Pow(x5 - px, 2) + Math.Pow(y5 - py, 2);
//                        if (secondOffsetDistance <= pointDistance)
//                        {
//                            Intersections++;
//                        }
//                    }*/
//                    else
//                    {
//                    /*
//                        var x5 = x2 + Hails[index].Vx;
//                        var y5 = y2 + Hails[index].Vy;
//                        var offsetDistance2 = Math.Pow(x5 - px, 2) + Math.Pow(y5 - py, 2);
//                        if (offsetDistance2 > offsetDistance)
//                        {
//                            Intersections++;
//                        }*/
//                    }
                }
            }
        }
    }
}
