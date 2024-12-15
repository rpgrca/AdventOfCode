using System.Diagnostics;

namespace Day14.Logic;

[DebuggerDisplay("({X}, {Y})")]
public class Coordinates
{
    public int X;
    public int Y;

    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override bool Equals(object? obj)
    {
        if (obj is null) return false;
        if (obj is Coordinates other)
        {
            return X == other.X && Y == other.Y;
        }

        return false;
    }

    public static bool operator == (Coordinates left, Coordinates right) =>
        left.Equals(right);

    public static bool operator != (Coordinates left, Coordinates right) =>
        !left.Equals(right);
}