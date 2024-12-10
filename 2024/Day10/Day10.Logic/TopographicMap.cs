namespace Day10.Logic;

public class TopographicMap
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly char[][] _map;

    public int Size => _lines.Length;
    public List<(int X, int Y)> Trailheads { get; private set; }
    public int TrailheadScore { get; private set; }
    public int TrailheadRating { get; private set; }

    public TopographicMap(string input)
    {
        _input = input;
        _lines = input.Split('\n');
        _map = _lines.Select(p => p.ToCharArray()).ToArray();

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
                if (_lines[y][x] == '0')
                {
                    Trailheads.Add((x, y));
                }
            }
        }
    }

    private void CalculateScore()
    {
        foreach (var trailhead in Trailheads)
        {
            var summits = new HashSet<(int X, int Y)>();
            TrailheadScore += CalculateScoreFor(summits, trailhead, 0);
            TrailheadRating += CalculateRatingFor(trailhead, 0);
        }
    }

    private int CalculateScoreFor(HashSet<(int X, int Y)> summits, (int X, int Y) position, int weight)
    {
        if (_map[position.Y][position.X] != weight + '0')
        {
            return 0;
        }

        if (weight == 9)
        {
            if (! summits.Contains(position))
            {
                summits.Add(position);
                return 1;
            }

            return 0;
        }

        var score = 0;
        if (position.X > 0)
        {
            score = CalculateScoreFor(summits, (position.X - 1, position.Y), weight + 1);
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

    private int CalculateRatingFor((int X, int Y) position, int weight)
    {
        if (_map[position.Y][position.X] != weight + '0')
        {
            return 0;
        }

        if (weight == 9)
        {
            return 1;
        }

        var rating = 0;
        if (position.X > 0)
        {
            rating = CalculateRatingFor((position.X - 1, position.Y), weight + 1);
        }

        if (position.X < Size - 1)
        {
            rating += CalculateRatingFor((position.X + 1, position.Y), weight + 1);
        }

        if (position.Y > 0)
        {
            rating += CalculateRatingFor((position.X, position.Y - 1), weight + 1);
        }

        if (position.Y < Size - 1)
        {
            rating += CalculateRatingFor((position.X, position.Y + 1), weight + 1);
        }

        return rating;
    }
}
