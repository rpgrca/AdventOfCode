


namespace Day6.Logic;

public class GuardPatrolProtocol
{
    private readonly string _input;
    private readonly char[][] _map;
    private readonly List<List<HashSet<int>>> _cache;
    private readonly List<(int X, int Y, int Direction)> _steps;

    public GuardPatrolProtocol(string input)
    {
        _input = input;
        _steps = new();
        _map = _input.Split('\n').Select(p => p.ToCharArray()).ToArray();
        _cache = new();
        for (var y = 0; y < Length; y++)
        {
            _cache.Add(new List<HashSet<int>>());
            for (var x = 0; x < Length; x++)
            {
                _cache[y].Add(new HashSet<int>());
            }
        }

        TransverseMap();
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
        var nextX = currentX + directions[currentDirection % 4].X;
        var nextY = currentY + directions[currentDirectSystem.ArgumentOutOfRangeException
        while (nextX >= 0 && nextX < Length && nextY >= 0 && nextY < Length)
        {
            if (_map[nextY][nextX] != '#')
            {
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
                }

                currentX = nextX;
                currentY = nextY;
                _map[currentY][currentX] = 'X';
                _cache[currentY][currentX].Add(currentDirection);
            }
            else
            {
                currentDirection++;
            }

            nextX = currentX + directions[currentDirection % 4].X;
            nextY = currentY + directions[currentDirection % 4].Y;
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