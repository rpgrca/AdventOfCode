



namespace Day14.Logic;

public class RestroomRedoubt
{
    private string _input;
    private int _width;
    private int _height;
    private readonly List<((int X, int Y) Position, (int X, int Y) Velocity)> _robots;

    public int RobotCount => _robots.Count;

    public List<((int X, int Y) Position, (int X, int Y) Velocity)> Robots => _robots;

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
            _robots.Add(((position[0], position[1]), (velocity[0], velocity[1])));
        }
    }

    public void CalculateAfter(int v)
    {
        throw new NotImplementedException();
    }
}
