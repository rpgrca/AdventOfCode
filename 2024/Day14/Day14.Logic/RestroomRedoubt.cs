using System.Text;

namespace Day14.Logic;

public class RestroomRedoubt
{
    private readonly string _input;
    private readonly int _width;
    private readonly int _height;
    private readonly List<Robot> _robots;

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

        var topLeft = 0;
        var bottomLeft = 0;
        var topRight = 0;
        var bottomRight = 0;
        foreach (var robot in _robots.Where(p => p.Position.X != quadrantWidth && p.Position.Y != quadrantHeight))
        {
            if (robot.Position.X < quadrantWidth)
            {
                if (robot.Position.Y < quadrantHeight)
                {
                    topLeft++;
                }
                else
                {
                    bottomLeft++;
                }
            }
            else
            {
                if (robot.Position.Y < quadrantHeight)
                {
                    topRight++;
                }
                else
                {
                    bottomRight++;
                }
            }
        }

        SafetyFactor = topLeft * topRight * bottomLeft * bottomRight;
    }

    public void SearchForChristmasTree()
    {
        var seconds = 0;
        while (true)
        {
            seconds++;
            foreach (var robot in _robots)
            {
                MoveRobot(robot);
            }

            if (AnyRowWithMoreThan20Robots())
            {
                foreach (var possibleTop in _robots.OrderBy(p => p.Position.X).ThenBy(p => p.Position.Y))
                {
                    if (IsItTop(possibleTop))
                    {
                        TreeFoundAt = seconds;
                        //Console.WriteLine(Plot(seconds));
                        return;
                    }
                }
            }
        }
    }

    private bool AnyRowWithMoreThan20Robots() =>
        _robots
            .GroupBy(p => p.Position.Y)
            .OrderByDescending(p => p.Count())
            .First()
            .Count() > 20;

    private bool IsItTop(Robot possibleTop)
    {
        var diagonalSize = 1;
        bool next;
        do
        {
            next = false;
            if (_robots.Any(p => p.Position.X == possibleTop.Position.X - diagonalSize && p.Position.Y == possibleTop.Position.Y + diagonalSize) &&
                _robots.Any(p => p.Position.X == possibleTop.Position.X + diagonalSize && p.Position.Y == possibleTop.Position.Y + diagonalSize))
            {
                diagonalSize++;
                next = true;
            }
        }
        while (next);
        return diagonalSize > 3;
    }

/*
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
    }*/
}