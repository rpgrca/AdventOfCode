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

    public static bool operator == (Robot left, Robot right)
    {
        return left.Equals(right);
    }

    public static bool operator != (Robot left, Robot right)
    {
        return !left.Equals(right);
    }


    public override string ToString()
    {
        return $"({Position}, {Velocity})";
    }
}

public struct Coordinates
{
    public int X;
    public int Y;

    public Coordinates(int x, int y)
    {
        X = x;
        Y = y;
    }

    public override bool Equals([NotNullWhen(true)] object? obj)
    {
        if (obj is null) return false;
        if (obj is Coordinates other)
        {
            return X == other.X && Y == other.Y;
        }

        return false;
    }

    public static bool operator == (Coordinates left, Coordinates right)
    {
        return left.Equals(right);
    }

    public static bool operator != (Coordinates left, Coordinates right)
    {
        return !left.Equals(right);
    }

    public override string ToString()
    {
        return $"({X}, {Y})";
    }
}

public class RestroomRedoubt
{
    private string _input;
    private int _width;
    private int _height;
    private readonly List<Robot> _robots;

    public int RobotCount => _robots.Count;

    public List<Robot> Robots => _robots;

    public RestroomRedoubt(string input, int width, int height)
    {
        _input = input;
        _width = width;
        _height = height;
        _robots = new();

        Parse();
    }

    private void Parse()
    {
        var lines = _input.Split('\n');
        foreach (var line in lines)
        {
            var coordinates = line.Split(' ');
            var position = coordinates[0][2..].Split(',').Select(int.Parse).ToArray();
            var velocity = coordinates[1][2..].Split(',').Select(int.Parse).ToArray();
            _robots.Add(new(new(position[0], position[1]), new(velocity[0], velocity[1])));
        }
    }

    public void CalculateAfter(int seconds)
    {
        while (seconds-- > 0)
        {
            var robot = _robots[0];
            robot.Position.X += robot.Velocity.X;
            if (robot.Position.X >= _width)
            {
                robot.Position.X -= _width;
            }
            robot.Position.Y += robot.Velocity.Y;
            if (robot.Position.Y < 0)
            {
                robot.Position.Y = _height + robot.Position.Y;
            }
        }
    }
}
