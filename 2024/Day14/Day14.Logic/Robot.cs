using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;

namespace Day14.Logic;

[DebuggerDisplay("({Position}, {Velocity})")]
public class Robot
{
    public Coordinates Position;
    public Coordinates Velocity;

    public Robot(Coordinates position, Coordinates velocity)
    {
        Position = position;
        Velocity = velocity;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is null) return false;
        if (obj is Robot other)
        {
            return Position.Equals(other.Position) && Velocity.Equals(other.Velocity);
        }

        return false;
    }

    public static bool operator == (Robot left, Robot right) =>
        left.Equals(right);

    public static bool operator != (Robot left, Robot right) =>
        !left.Equals(right);
}