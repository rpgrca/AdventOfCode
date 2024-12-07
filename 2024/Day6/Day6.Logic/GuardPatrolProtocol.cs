namespace Day6.Logic;

/*
public class GuardPatrolProtocolWorkingSlow
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
                if (! _walked.Contains((nextX, nextY)))
                {
                    _walked.Add((nextX, nextY));
                }


                currentX = nextX;
                currentY = nextY;
                _map[currentY][currentX] = 'X';
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
                //File.AppendAllText("/home/roberto/loop_1.txt", $"{y}, {x}\n");
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
}*/

/*
public class GuardPatrolProtocol
{
    private readonly string[] _input;
    private readonly bool[,] _map;
    private readonly bool[,,] _cache;
    private readonly HashSet<(int X, int Y)> _walked;
    private readonly List<(int X, int Y, int Direction)> _steps;
    private int _initialX;
    private int _initialY;
    private (int X, int Y)[] _directions =
    {
        ( 0, -1),
        ( 1,  0),
        ( 0,  1),
        (-1,  0)
    };

    public int Length => _input.Length;
    public int DistinctVisitedPositions { get; private set; }
    public int PossibleObstructions { get; private set; }

    public GuardPatrolProtocol(string input, bool calculateObstructions = false)
    {
        _input = input.Split('\n');
        _map = new bool[Length, Length];
        _walked = new();
        _steps = new();
        _cache = new bool[Length, Length, 4];

        CreateMultidimensionalMap();
        CalculateInitialPosition();
        TransverseMap();

        if (calculateObstructions)
        {
            CalculatePossibleObstructions();
        }
    }

    private void CreateMultidimensionalMap()
    {
        for (var y = 0; y < Length; y++)
        {
            for (var x = 0; x < Length; x++)
            {
                _map[y, x] = _input[y][x] == '#';
            }
        }
    }

    private void CalculateInitialPosition()
    {
        for (var y = 0; y < Length; y++)
        {
            var index =_input[y].IndexOf('^');
            if (index != -1)
            {
                _initialX = index;
                _initialY = y;
                return;
            }
        }
    }

    private void TransverseMap()
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
        var previousX = _initialX;
        var previousY = _initialY;

        _walked.Add((_initialX, _initialY));
        while (nextX >= 0 && nextX < Length && nextY >= 0 && nextY < Length)
        {
            if (! _map[nextY, nextX])
            {
                previousX = currentX;
                previousY = currentY;
                currentX = nextX;
                currentY = nextY;
                _cache[currentY, currentX, currentDirection] = true;
                if (! _walked.Contains((currentX, currentY)))
                {
                    if (currentX == _initialX && currentY == _initialY)
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                    _walked.Add((currentX, currentY));
                    _steps.Add((currentX, currentY, currentDirection));
                }
                else
                {
                }
            }
            else
            {
                currentDirection = (currentDirection + 1) & 3;
            }

            nextX = currentX + directions[currentDirection].X;
            nextY = currentY + directions[currentDirection].Y;
        }

        _steps.Add((currentX, currentY, currentDirection));
        DistinctVisitedPositions = _walked.Count;
    }

    private void CalculatePossibleObstructions()
    {
        var cache = new bool[Length, Length, 4];
        for (var index = 1; index < _steps.Count; index++)
        {
            var (x, y, direction) = _steps[^index];
            var (lastX, lastY, lastDirection) = _steps[^(index+1)];

            _cache[y, x, direction] = false;
            Buffer.BlockCopy(_cache, 0, cache, 0, _cache.Length * sizeof(bool));

            _map[y, x] = true;
            if (CheckForLoop(cache, lastX, lastY, lastDirection))
            {
                PossibleObstructions++;
            }
            _map[y, x] = false;
        }
    }

    private bool CheckForLoop(bool[,,] cache, int initialX, int initialY, int initialDirection)
    {
        var currentDirection = initialDirection;
        var currentX = initialX;
        var currentY = initialY;
        var nextX = currentX + _directions[currentDirection].X;
        var nextY = currentY + _directions[currentDirection].Y;

        while (nextX >= 0 && nextX < Length && nextY >= 0 && nextY < Length)
        {
            if (! _map[nextY, nextX])
            {
                if (cache[nextY,nextX,currentDirection])
                {
                    return true;
                }

                currentX = nextX;
                currentY = nextY;
                cache[currentY, currentX, currentDirection] = true;
            }
            else
            {
                currentDirection = (currentDirection + 1) & 3;
            }

            nextX = currentX + _directions[currentDirection].X;
            nextY = currentY + _directions[currentDirection].Y;
        }

        return false;
    }
}*/


public class GuardPatrolProtocol
{
    private readonly string[] _input;
    private readonly bool[,] _map;
    private readonly HashSet<(int X, int Y)> _walked;
    private readonly List<(int X, int Y, int Direction)> _steps;
    private int _initialX;
    private int _initialY;
    private (int X, int Y)[] _directions =
    {
        ( 0, -1),
        ( 1,  0),
        ( 0,  1),
        (-1,  0)
    };

    public int Length => _input.Length;
    public int DistinctVisitedPositions { get; private set; }
    public int PossibleObstructions { get; private set; }

    public GuardPatrolProtocol(string input, bool calculateObstructions = false)
    {
        _input = input.Split('\n');
        _map = new bool[Length, Length];
        _walked = new();
        _steps = new();

        CreateMultidimensionalMap();
        CalculateInitialPosition();
        TransverseMap();

        if (calculateObstructions)
        {
            CalculatePossibleObstructions();
        }
    }

    private void CreateMultidimensionalMap()
    {
        for (var y = 0; y < Length; y++)
        {
            for (var x = 0; x < Length; x++)
            {
                _map[y, x] = _input[y][x] == '#';
            }
        }
    }

    private bool[,,] CreateCache => new bool[Length, Length, 4];

    private void CalculateInitialPosition()
    {
        for (var y = 0; y < Length; y++)
        {
            var index =_input[y].IndexOf('^');
            if (index != -1)
            {
                _initialX = index;
                _initialY = y;
                return;
            }
        }
    }

    private void TransverseMap()
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

        _walked.Add((_initialX, _initialY));
        while (nextX >= 0 && nextX < Length && nextY >= 0 && nextY < Length)
        {
            if (! _map[nextY, nextX])
            {
                currentX = nextX;
                currentY = nextY;
                _steps.Add((currentX, currentY, currentDirection));
                if (! _walked.Contains((currentX, currentY)))
                {
                    _walked.Add((currentX, currentY));
                }
            }
            else
            {
                currentDirection = (currentDirection + 1) & 3;
            }

            nextX = currentX + directions[currentDirection].X;
            nextY = currentY + directions[currentDirection].Y;
        }

        DistinctVisitedPositions = _walked.Count;
    }

    private void CalculatePossibleObstructions()
    {
        foreach (var (x, y) in _walked.Skip(1))
        {
            var cache = CreateCache;

            _map[y, x] = true;
            if (CheckForLoop(cache))
            {
                PossibleObstructions++;
            }
            _map[y, x] = false;
        }
    }

    private bool CheckForLoop(bool[,,] cache)
    {
        var currentDirection = 0;
        var currentX = _initialX;
        var currentY = _initialY;
        var nextX = currentX + _directions[currentDirection].X;
        var nextY = currentY + _directions[currentDirection].Y;

        while (nextX >= 0 && nextX < Length && nextY >= 0 && nextY < Length)
        {
            if (! _map[nextY, nextX])
            {
                if (cache[nextY,nextX,currentDirection])
                {
                    return true;
                }

                currentX = nextX;
                currentY = nextY;
                cache[currentY, currentX, currentDirection] = true;
            }
            else
            {
                currentDirection = (currentDirection + 1) & 3;
            }

            nextX = currentX + _directions[currentDirection].X;
            nextY = currentY + _directions[currentDirection].Y;
        }

        return false;
    }
}
