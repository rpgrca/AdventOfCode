namespace Day16.Logic;

public enum Direction
{
    East,
    North,
    West,
    South
}

public class ReindeerMaze
{
    private string _input;
    private string[] _lines;
    private readonly char[,] _map;
    private readonly HashSet<int> _uniqueSolutionTiles;

    public int Size => _lines.Length;

    public (int X, int Y) StartPoint { get; private set; }
    public (int X, int Y) EndPoint { get; private set; }
    public int LowestScore { get; private set; }

    public int ShortestPathTiles => _uniqueSolutionTiles.Count;

    public ReindeerMaze(string input)
    {
        _input = input;
        _lines = _input.Split('\n');
        _map = new char[Size, Size];
        _uniqueSolutionTiles = new();
        LowestScore = int.MaxValue;

        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                if (_lines[y][x] == 'S')
                {
                    StartPoint = (x, y);
                    _map[y, x] = _lines[y][x];
                }
                else if (_lines[y][x] == 'E')
                {
                    EndPoint = (x, y);
                    _map[y, x] = _lines[y][x];
                }
                else
                {
                    _map[y, x] = _lines[y][x];
                }
            }
        }
    }

    public void Run()
    {
        var visited = new HashSet<(int X, int Y, Direction)>();
        var priorityQueue = new PriorityQueue<(int X, int Y, Direction Direction, int Weight, int Turns, int Steps), int>();
        priorityQueue.Enqueue((StartPoint.X, StartPoint.Y, Direction.East, 0, 0, 0), 0);
        priorityQueue.Enqueue((StartPoint.X, StartPoint.Y, Direction.North, 1000, 1, 0), 1000);
        priorityQueue.Enqueue((StartPoint.X, StartPoint.Y, Direction.West, 2000, 2, 0), 2000);
        priorityQueue.Enqueue((StartPoint.X, StartPoint.Y, Direction.South, 1000, 1, 0), 1000);

        while (priorityQueue.Count > 0)
        {
            var move = priorityQueue.Dequeue();
            if (IsEndPoint(move.X, move.Y))
            {
                LowestScore = move.Weight;
                return;
            }

            if (visited.Contains((move.X, move.Y, move.Direction)))
            {
                continue;
            }

            visited.Add((move.X, move.Y, move.Direction));

            switch (move.Direction)
            {
                case Direction.East:
                    var newX = move.X + 1;
                    if (newX < Size && _map[move.Y, newX] != '#')
                    {
                        priorityQueue.Enqueue((newX, move.Y, move.Direction, move.Weight + 1, move.Turns, move.Steps + 1), move.Weight + 1);
                    }

                    var newY = move.Y - 1;
                    if (newY >= 0 && _map[newY, move.X] != '#')
                    {
                        priorityQueue.Enqueue((move.X, newY, Direction.North, move.Weight + 1001, move.Turns + 1, move.Steps + 1), move.Weight + 1001);
                    }

                    newY = move.Y + 1;
                    if (newY < Size && _map[newY, move.X] != '#')
                    {
                        priorityQueue.Enqueue((move.X, newY, Direction.South, move.Weight + 1001, move.Turns + 1, move.Steps + 1), move.Weight + 1001);
                    }
                    break;

                case Direction.North:
                    newY = move.Y - 1;
                    if (newY >= 0 && _map[newY, move.X] != '#')
                    {
                        priorityQueue.Enqueue((move.X, newY, move.Direction, move.Weight + 1, move.Turns, move.Steps + 1), move.Weight + 1);
                    }

                    newX = move.X + 1;
                    if (newX < Size && _map[move.Y, newX] != '#')
                    {
                        priorityQueue.Enqueue((newX, move.Y, Direction.East, move.Weight + 1001, move.Turns + 1, move.Steps + 1), move.Weight + 1001);
                    }

                    newX = move.X - 1;
                    if (newX >= 0 && _map[move.Y, newX] != '#')
                    {
                        priorityQueue.Enqueue((newX, move.Y, Direction.West, move.Weight + 1001, move.Turns + 1, move.Steps + 1), move.Weight + 1001);
                    }
                    break;

                case Direction.West:
                    newX = move.X - 1;
                    if (newX >= 0 && _map[move.Y, newX] != '#')
                    {
                        priorityQueue.Enqueue((newX, move.Y, move.Direction, move.Weight + 1, move.Turns, move.Steps + 1), move.Weight + 1);
                    }

                    newY = move.Y - 1;
                    if (newY >= 0 && _map[newY, move.X] != '#')
                    {
                        priorityQueue.Enqueue((move.X, newY, Direction.North, move.Weight + 1001, move.Turns + 1, move.Steps + 1), move.Weight + 1001);
                    }

                    newY = move.Y + 1;
                    if (newY < Size && _map[newY, move.X] != '#')
                    {
                        priorityQueue.Enqueue((move.X, newY, Direction.South, move.Weight + 1001, move.Turns + 1, move.Steps + 1), move.Weight + 1001);
                    }
                    break;

                case Direction.South:
                    newY = move.Y + 1;
                    if (newY < Size && _map[newY, move.X] != '#')
                    {
                        priorityQueue.Enqueue((move.X, newY, move.Direction, move.Weight + 1, move.Turns, move.Steps + 1), move.Weight + 1);
                    }

                    newX = move.X + 1;
                    if (newX < Size && _map[move.Y, newX] != '#')
                    {
                        priorityQueue.Enqueue((newX, move.Y, Direction.East, move.Weight + 1001, move.Turns + 1, move.Steps + 1), move.Weight + 1001);
                    }

                    newX = move.X - 1;
                    if (newX >= 0 && _map[move.Y, newX] != '#')
                    {
                        priorityQueue.Enqueue((newX, move.Y, Direction.West, move.Weight + 1001, move.Turns + 1, move.Steps + 1), move.Weight + 1001);
                    }
                    break;
            }
        }
    }

    private bool IsEndPoint(int x, int y) => _map[y, x] == 'E';

    public void Run2()
    {
        Run();

        _uniqueSolutionTiles.Add(StartPoint.Y * 1000 + StartPoint.X);
        _uniqueSolutionTiles.Add(EndPoint.Y * 1000 + EndPoint.X);

        var tiles = new HashSet<int>();
        var (turns, steps) = Math.DivRem(LowestScore, 1000);
        FindPath(StartPoint.X, StartPoint.Y, Direction.East, tiles, 0, turns, steps);
    }
/*
    public void Run3()
    {
        Run();
        _uniqueSolutionTiles.Add(StartPoint.Y * 1000 + StartPoint.X);
        _uniqueSolutionTiles.Add(EndPoint.Y * 1000 + EndPoint.X);

        var tiles = new HashSet<int>();
        var (turns, steps) = Math.DivRem(LowestScore, 1000);
        FindPath2(StartPoint.X, StartPoint.Y, Direction.East, tiles, 0, turns, steps);
    }
*/
    private void FindPath(int x, int y, Direction direction, HashSet<int> tiles, int weight, int turns, int steps)
    {
        if (turns < 0 || steps < 0)
        {
            return;
        }

        if (tiles.Contains(y * 1000 + x))
        {
            return;
        }

        if (weight > LowestScore)
        {
            return;
        }

        if (weight == LowestScore)
        {
            if (IsEndPoint(x, y))
            {
                foreach (var tile in tiles)
                {
                    _uniqueSolutionTiles.Add(tile);
                }

                Console.WriteLine(_uniqueSolutionTiles.Count);
            }

            return;
        }

        tiles.Add(y * 1000 + x);

        var incrementedX = x + 1;
        var incrementedY = y + 1;
        var decrementedX = x - 1;
        var decrementedY = y - 1;

        if (direction != Direction.West && _map[y, incrementedX] != '#')
        {
            switch (direction)
            {
                case Direction.East:
                    FindPath(incrementedX, y, Direction.East, tiles, weight + 1, turns, steps - 1);
                    break;
                case Direction.North:
                case Direction.South:
                    FindPath(incrementedX, y, Direction.East, tiles, weight + 1001, turns - 1, steps - 1);
                    break;
            }
        }

        if (direction != Direction.South && _map[decrementedY, x] != '#')
        {
            switch (direction)
            {
                case Direction.North:
                    FindPath(x, decrementedY, Direction.North, tiles, weight + 1, turns, steps - 1);
                    break;
                case Direction.East:
                case Direction.West:
                    FindPath(x, decrementedY, Direction.North, tiles, weight + 1001, turns - 1, steps - 1);
                    break;
            }
        }

        if (direction != Direction.East && _map[y, decrementedX] != '#')
        {
            switch (direction)
            {
                case Direction.West:
                    FindPath(decrementedX, y, Direction.West, tiles, weight + 1, turns, steps - 1);
                    break;
                case Direction.North:
                case Direction.South:
                    FindPath(decrementedX, y, Direction.West, tiles, weight + 1001, turns - 1, steps - 1);
                    break;
            }
        }

        if (direction != Direction.North && _map[incrementedY, x] != '#')
        {
            switch (direction)
            {
                case Direction.South:
                    FindPath(x, incrementedY, Direction.South, tiles, weight + 1, turns, steps - 1);
                    break;
                case Direction.East:
                case Direction.West:
                    FindPath(x, incrementedY, Direction.South, tiles, weight + 1001, turns - 1, steps - 1);
                    break;
            }
        }

        tiles.Remove(y * 1000 + x);
    }
/*
    private void FindPath2(int x, int y, Direction direction, HashSet<int> tiles, int weight, int turns, int steps)
    {
        if (turns < 0 || steps < 0)
        {
            return;
        }

        if (tiles.Contains(y * 1000 + x))
        {
            return;
        }

        if (weight > LowestScore)
        {
            return;
        }

        if (weight == LowestScore)
        {
            if (IsEndPoint(x, y))
            {
                foreach (var tile in tiles)
                {
                    _uniqueSolutionTiles.Add(tile);
                }

                Console.WriteLine(_uniqueSolutionTiles.Count);
            }

            return;
        }

        tiles.Add(y * 1000 + x);

        var incrementedX = x + 1;
        var incrementedY = y + 1;
        var decrementedX = x - 1;
        var decrementedY = y - 1;

        if (direction != Direction.West && _map[y, incrementedX].Sprite != '#')
        {
            switch (direction)
            {
                case Direction.East:
                    FindPath(incrementedX, y, Direction.East, tiles, weight + 1, turns, steps - 1);
                    break;
                case Direction.North:
                case Direction.South:
                    FindPath(incrementedX, y, Direction.East, tiles, weight + 1001, turns - 1, steps - 1);
                    break;
            }
        }

        if (direction != Direction.South && _map[decrementedY, x].Sprite != '#')
        {
            switch (direction)
            {
                case Direction.North:
                    FindPath(x, decrementedY, Direction.North, tiles, weight + 1, turns, steps - 1);
                    break;
                case Direction.East:
                case Direction.West:
                    FindPath(x, decrementedY, Direction.North, tiles, weight + 1001, turns - 1, steps - 1);
                    break;
            }
        }

        if (direction != Direction.East && _map[y, decrementedX].Sprite != '#')
        {
            switch (direction)
            {
                case Direction.West:
                    FindPath(decrementedX, y, Direction.West, tiles, weight + 1, turns, steps - 1);
                    break;
                case Direction.North:
                case Direction.South:
                    FindPath(decrementedX, y, Direction.West, tiles, weight + 1001, turns - 1, steps - 1);
                    break;
            }
        }

        if (direction != Direction.North && _map[incrementedY, x].Sprite != '#')
        {
            switch (direction)
            {
                case Direction.South:
                    FindPath(x, incrementedY, Direction.South, tiles, weight + 1, turns, steps - 1);
                    break;
                case Direction.East:
                case Direction.West:
                    FindPath(x, incrementedY, Direction.South, tiles, weight + 1001, turns - 1, steps - 1);
                    break;
            }
        }

        tiles.Remove(y * 1000 + x);
    }
    */

}