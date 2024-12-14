using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO.Pipes;
using System.Text;

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

    public int SafetyFactor { get; private set; }
    public int TreeFoundAt { get; private set; }

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
            foreach (var robot in _robots)
            {
                MoveRobot(robot);
            }
        }
    }

    private void MoveRobot(Robot robot)
    {
        robot.Position.X += robot.Velocity.X;
        if (robot.Position.X >= _width)
        {
            robot.Position.X -= _width;
        }
        else if (robot.Position.X < 0)
        {
            robot.Position.X = _width + robot.Position.X;
        }

        robot.Position.Y += robot.Velocity.Y;
        if (robot.Position.Y >= _height)
        {
            robot.Position.Y -= _height;
        }
        if (robot.Position.Y < 0)
        {
            robot.Position.Y = _height + robot.Position.Y;
        }
    }

    public void CalculateSafetyFactor()
    {
        var quadrantWidth = _width / 2;
        var quadrantHeight = _height / 2;
        var topLeft = _robots.Count(p => p.Position.X < quadrantWidth && p.Position.Y < quadrantHeight);
        var topRight = _robots.Count(p => p.Position.X > quadrantWidth && p.Position.Y < quadrantHeight);
        var bottomLeft = _robots.Count(p => p.Position.X < quadrantWidth && p.Position.Y > quadrantHeight);
        var bottomRight = _robots.Count(p => p.Position.X > quadrantWidth && p.Position.Y > quadrantHeight);

        SafetyFactor = topLeft * topRight * bottomLeft * bottomRight;
    }

    public void SearchForChristmasTree()
    {
        var seconds = 0;
        var printAt = 52;
        while (true)
        {
            seconds++;
            foreach (var robot in _robots)
            {
                MoveRobot(robot);
            }

            var y = _robots.GroupBy(p => p.Position.Y).OrderByDescending(p => p.Count()).First();
            if (y.Count() > 20)
            {
                foreach (var possibleTop in _robots)
                {
                    if (_robots.Any(p => p.Position.X == possibleTop.Position.X-1 && p.Position.Y == possibleTop.Position.Y+1))
                    {
                        if (_robots.Any(p => p.Position.X == possibleTop.Position.X+1 && p.Position.Y == possibleTop.Position.Y+1))
                        {
                            if (_robots.Any(p => p.Position.X == possibleTop.Position.X-2 && p.Position.Y == possibleTop.Position.Y+2))
                            {
                                if (_robots.Any(p => p.Position.X == possibleTop.Position.X+2 && p.Position.Y == possibleTop.Position.Y+2))
                                {
                                    if (_robots.Any(p => p.Position.X == possibleTop.Position.X-3 && p.Position.Y == possibleTop.Position.Y+3))
                                    {
                                        if (_robots.Any(p => p.Position.X == possibleTop.Position.X+3 && p.Position.Y == possibleTop.Position.Y+3))
                                        {
                                            TreeFoundAt = seconds;
                                            return;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    private string Plot(int line)
    {
        var sb = new StringBuilder();
        for (var y = 0; y < _height; y++)
        {
            for (var x = 0; x < _width; x++)
            {
                if (_robots.Any(p => p.Position.X == x && p.Position.Y == y))
                {
                    sb.Append('#');
                }
                else
                {
                    sb.Append('.');
                }
            }

            sb.Append($"  {line}\n");
        }

        return sb.ToString();
    }
}
