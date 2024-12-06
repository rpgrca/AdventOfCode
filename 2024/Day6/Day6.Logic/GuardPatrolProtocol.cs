namespace Day6.Logic;

public class GuardPatrolProtocol
{
    private readonly string _input;
    private readonly char[][] _map;
    private readonly List<(int X, int Y, int Direction)> _steps;
    private readonly HashSet<(int X, int Y)> _walked;
    private int _initialX;
    private int _initialY;

    public GuardPatrolProtocol(string input, bool calculateObstructions = false)
    {
        _input = input;
        _steps = new();
        _walked = new();
        _map = _input.Split('\n').Select(p => p.ToCharArray()).ToArray();

        CalculateInitialPosition();
        TransverseMap();
        if (calculateObstructions)
        {
            CalculatePossibleObstructions();
        }
    }

    private HashSet<int>[,] CreateCache()
    {
        var cache = new HashSet<int>[Length,Length];
        for (var y = 0; y < Length; y++)
        {
            for (var x = 0; x < Length; x++)
            {
                cache[y,x] = new HashSet<int>();
            }
        }

        return cache;
    }

    private void ClearCache(HashSet<int>[,] cache)
    {
        foreach (var row in cache)
        {
            row.Clear();
        }
    }

    private void CalculateInitialPosition()
    {
        for (var y = 0; y < Length; y++)
        {
            for (var x = 0; x < Length; x++)
            {
                if (_map[y][x] == '^')
                {
                    _initialX = x;
                    _initialY = y;
                    return;
                }
            }
        }
    }

    private void TransverseMap()
    {
        _walked.Add((_initialX, _initialY));
        var directions = new List<(int X, int Y)>
        {
            (0, -1), // up 0
            (1, 0),
            (0, 1),
            (-1, 0)
        };
        var currentDirection = 0;
        var currentX = _initialX;
        var currentY = _initialY;
        var nextX = currentX + directions[currentDirection].X;
        var nextY = currentY + directions[currentDirection].Y;

        while (nextX >= 0 && nextX < Length && nextY >= 0 && nextY < Length)
        {
            if (_map[nextY][nextX] != '#')
            {
                currentX = nextX;
                currentY = nextY;
                _map[currentY][currentX] = 'X';
                if (! _walked.Contains((currentX, currentY)))
                {
                    _walked.Add((currentX, currentY));
                }
            }
            else
            {
                currentDirection = (currentDirection + 1) % 4;
            }

            nextX = currentX + directions[currentDirection].X;
            nextY = currentY + directions[currentDirection].Y;
        }

        DistinctVisitedPositions = _walked.Count;
    }

    private void CalculatePossibleObstructions()
    {
        var cache = CreateCache();
        foreach (var (x, y) in _walked.Skip(1))
        {
            _map[y][x] = '#';
            if (CheckForLoop(cache))
            {
                PossibleObstructions++;
            }
            _map[y][x] = '.';
            ClearCache(cache);
        }
    }

    private bool CheckForLoop(HashSet<int>[,] cache)
    {
        var directions = new List<(int X, int Y)>
        {
            (0, -1), // up 0
            (1, 0),
            (0, 1),
            (-1, 0)
        };
        var currentDirection = 0;
        var currentX = _initialX;
        var currentY = _initialY;
        var nextX = currentX + directions[currentDirection].X;
        var nextY = currentY + directions[currentDirection].Y;
        var inLoop = false;

        while (nextX >= 0 && nextX < Length && nextY >= 0 && nextY < Length)
        {
            if (_map[nextY][nextX] != '#')
            {
                if (cache[nextY,nextX].Contains(currentDirection))
                {
                    inLoop = true;
                    break;
                }

                currentX = nextX;
                currentY = nextY;
                cache[currentY,currentX].Add(currentDirection);
            }
            else
            {
                currentDirection = (currentDirection + 1) % 4;
            }

            nextX = currentX + directions[currentDirection].X;
            nextY = currentY + directions[currentDirection].Y;
        }

        return inLoop;
    }

    public int Length => _map.Length;
    public int DistinctVisitedPositions { get; private set; }
    public int PossibleObstructions { get; private set; }
}