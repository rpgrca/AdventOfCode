


namespace Day6.Logic;

public class GuardPatrolProtocol
{
    private readonly string _input;
    private readonly char[][] _map;
    private readonly List<List<HashSet<int>>> _cache;
    private readonly List<(int X, int Y, int Direction)> _steps;
    private readonly HashSet<(int X, int Y)> _walked;

    public GuardPatrolProtocol(string input)
    {
        _input = input;
        _steps = new();
        _walked = new();
        _map = _input.Split('\n').Select(p => p.ToCharArray()).ToArray();
        _cache = CreateCache();

        TransverseMap();
    }

    private List<List<HashSet<int>>> CreateCache()
    {
        var cache = new List<List<HashSet<int>>>();
        for (var y = 0; y < Length; y++)
        {
            cache.Add(new List<HashSet<int>>());
            for (var x = 0; x < Length; x++)
            {
                cache[y].Add(new HashSet<int>());
            }
        }

        return cache;
    }

    private void ClearCache(List<List<HashSet<int>>> cache)
    {
        foreach (var row in cache)
        {
            foreach (var column in row)
            {
                column.Clear();
            }
        }
    }

    private void TransverseMap()
    {
        var initialX = 0;
        var initialY = 0;
        for (var y = 0; y < Length; y++)
        {
            for (var x = 0; x < Length; x++)
            {
                if (_map[y][x] == '^')
                {
                    initialX = x;
                    initialY = y;
                    goto found;
                }
            }
        }

found:

        _walked.Add((initialX, initialY));
        var directions = new List<(int X, int Y)>
        {
            (0, -1), // up 0
            (1, 0),
            (0, 1),
            (-1, 0)
        };
        var currentDirection = 0;
        var currentX = initialX;
        var currentY = initialY;
        var nextX = currentX + directions[currentDirection].X;
        var nextY = currentY + directions[currentDirection].Y;
        var inLoop = false;

        while (nextX >= 0 && nextX < Length && nextY >= 0 && nextY < Length)
        {
            if (_map[nextY][nextX] != '#')
            {
                if (_cache[nextY][nextX].Contains(currentDirection))
                {
                    inLoop = true;
                    break;
                }

                currentX = nextX;
                currentY = nextY;
                _map[currentY][currentX] = 'X';
                _cache[currentY][currentX].Add(currentDirection);
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

        var cache = CreateCache();
        foreach (var (x, y) in _walked.Skip(1))
        {
            var oldPosition = _map[y][x];
            _map[y][x] = '#';
            if (CheckForLoop(cache, initialX, initialY))
            {
                PossibleObstructions++;
            }
            _map[y][x] = oldPosition;
            ClearCache(cache);
        }
    }

    private bool CheckForLoop(List<List<HashSet<int>>> cache, int initialX, int initialY)
    {
        var directions = new List<(int X, int Y)>
        {
            (0, -1), // up 0
            (1, 0),
            (0, 1),
            (-1, 0)
        };
        var currentDirection = 0;
        var currentX = initialX;
        var currentY = initialY;
        var nextX = currentX + directions[currentDirection].X;
        var nextY = currentY + directions[currentDirection].Y;
        var inLoop = false;

        while (nextX >= 0 && nextX < Length && nextY >= 0 && nextY < Length)
        {
            if (_map[nextY][nextX] != '#')
            {
                if (cache[nextY][nextX].Contains(currentDirection))
                {
                    inLoop = true;
                    break;
                }

                currentX = nextX;
                currentY = nextY;
                cache[currentY][currentX].Add(currentDirection);
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

    private void TransverseMap1()
    {
        var initialX = 0;
        var initialY = 0;
        for (var y = 0; y < Length; y++)
        {
            for (var x = 0; x < Length; x++)
            {
                if (_map[y][x] == '^')
                {
                    initialX = x;
                    initialY = y;
                    goto found;
                }
            }
        }

found:
        var directions = new List<(int X, int Y)>
        {
            (0, -1), // up 0
            (1, 0),
            (0, 1),
            (-1, 0)
        };
        var currentDirection = 0;
        var currentX = initialX;
        var currentY = initialY;
        var nextX = currentX + directions[currentDirection].X;
        var nextY = currentY + directions[currentDirection].Y;

        while (nextX >= 0 && nextX < Length && nextY >= 0 && nextY < Length)
        {
            if (nextX == 1 && nextY == 8)
            {
                System.Diagnostics.Debugger.Break();
            }

            if (_map[nextY][nextX] != '#')
            {/*
                var possibleDirection = (currentDirection + 1) % 4;
                var obstacleChangedDirection = directions[possibleDirection];
                var possibleX = currentX + obstacleChangedDirection.X;
                var possibleY = currentY + obstacleChangedDirection.Y;
                if (possibleX >= 0 && possibleX < Length && possibleY >= 0 && possibleY < Length)
                {
                    if (_cache[possibleY][possibleX].Contains(possibleDirection))
                    {
                        PossibleObstructions++;
                    }
                }*/

                currentX = nextX;
                currentY = nextY;
                _map[currentY][currentX] = 'X';
                _cache[currentY][currentX].Add(currentDirection);
            }
            else
            {
                currentDirection = (currentDirection + 1) % 4;
            }

            nextX = currentX + directions[currentDirection].X;
            nextY = currentY + directions[currentDirection].Y;
        }

        for (var y = 0; y < Length; y++)
        {
            for (var x = 0; x < Length; x++)
            {
                if (_map[y][x] == 'X' || _map[y][x] == '^')
                {
                    DistinctVisitedPositions++;
                }
            }
        }

    }

    public int Length => _map.Length;
    public int DistinctVisitedPositions { get; private set; }
    public int PossibleObstructions { get; private set; }
}