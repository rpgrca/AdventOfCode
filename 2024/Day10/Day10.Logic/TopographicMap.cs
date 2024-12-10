namespace Day10.Logic;

public class TopographicMap
{
    private readonly string[] _lines;
    private readonly int[,] _map;
    private readonly Func<HashSet<(int, int)>, (int, int), int> _onSummit;

    public int Size => _lines.Length;
    public List<(int X, int Y)> Trailheads { get; private set; }
    public int Result { get; private set; }

    public static TopographicMap ForScore(string input) =>
        new(input, (s, p) => s.Add(p) ? 1 : 0);

    public static TopographicMap ForRating(string input) =>
        new(input, (_, _) => 1);

    private TopographicMap(string input, Func<HashSet<(int, int)>, (int, int), int> onSummit)
    {
        _lines = input.Split('\n');
        _map = new int[Size, Size];
        _onSummit = onSummit;
        Trailheads = new();

        LocateTrailheads();
        CalculateScore();
    }

    private void LocateTrailheads()
    {
        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                _map[y,x] = _lines[y][x] - '0';
                if (_map[y,x] == 0)
                {
                    Trailheads.Add((x, y));
                }
            }
        }
    }

    private void CalculateScore()
    {
        var summits = new HashSet<(int X, int Y)>();
        foreach (var trailhead in Trailheads)
        {
            Result += CalculateScoreFor(summits, trailhead, 0);
            summits.Clear();
        }
    }

    private int CalculateScoreFor(HashSet<(int X, int Y)> summits, (int X, int Y) position, int weight)
    {
        if (_map[position.Y, position.X] != weight)
        {
            return 0;
        }

        if (weight == 9)
        {
            return _onSummit(summits, position);
        }

        var score = 0;
        if (position.X > 0)
        {
            score += CalculateScoreFor(summits, (position.X - 1, position.Y), weight + 1);
        }

        if (position.X < Size - 1)
        {
            score += CalculateScoreFor(summits, (position.X + 1, position.Y), weight + 1);
        }

        if (position.Y > 0)
        {
            score += CalculateScoreFor(summits, (position.X, position.Y - 1), weight + 1);
        }

        if (position.Y < Size - 1)
        {
            score += CalculateScoreFor(summits, (position.X, position.Y + 1), weight + 1);
        }

        return score;
    }
}