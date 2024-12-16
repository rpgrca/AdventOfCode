
namespace Day16.Logic;

public enum Direction
{
    East,
    North,
    West,
    South
}

public struct Tile
{
    public char Sprite;
    //public Direction Direction;
    //public int Weight;
}

public class ReindeerMaze
{
    private string _input;
    private string[] _lines;
    private readonly Tile[,] _map;

    public int Size => _lines.Length;

    public (int X, int Y) StartPoint { get; private set; }
    public (int X, int Y) EndPoint { get; private set; }
    public int LowestScore { get; private set; }

    public ReindeerMaze(string input)
    {
        _input = input;
        _lines = _input.Split('\n');
        _map = new Tile[Size, Size];

        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                if (_lines[y][x] == 'S')
                {
                    StartPoint = (x, y);
                    _map[y, x].Sprite = _lines[y][x];
                }
                else if (_lines[y][x] == 'E')
                {
                    EndPoint = (x, y);
                    _map[y, x].Sprite = _lines[y][x];
                }
                else
                {
                    _map[y, x].Sprite = _lines[y][x];
                }
            }
        }
    }

    public void Run()
    {
        var priorityQueue = new PriorityQueue<(int X, int Y, Direction Direction, int Weight), int>();
        priorityQueue.Enqueue((StartPoint.X, StartPoint.Y, Direction.East, 0), 0);
        priorityQueue.Enqueue((StartPoint.X, StartPoint.Y, Direction.North, 1000), 1000);
        priorityQueue.Enqueue((StartPoint.X, StartPoint.Y, Direction.West, 2000), 2000);
        priorityQueue.Enqueue((StartPoint.X, StartPoint.Y, Direction.South, 1000), 1000);

        while (priorityQueue.Count > 0)
        {
            var move = priorityQueue.Dequeue();
            if (IsEndPoint(move.X, move.Y))
            {
                LowestScore = move.Weight;
                return;
            }

            switch (move.Direction)
            {
                case Direction.East:
                    var newX = move.X + 1;
                    if (newX < Size && _map[move.Y, newX].Sprite != '#')
                    {
                        priorityQueue.Enqueue((newX, move.Y, move.Direction, move.Weight + 1), move.Weight + 1);
                    }

                    var newY = move.Y - 1;
                    if (newY >= 0 && _map[newY, move.X].Sprite != '#')
                    {
                        priorityQueue.Enqueue((move.X, newY, Direction.North, move.Weight + 1001), move.Weight + 1001);
                    }

                    newY = move.Y + 1;
                    if (newY < Size && _map[newY, move.X].Sprite != '#')
                    {
                        priorityQueue.Enqueue((move.X, newY, Direction.South, move.Weight + 1001), move.Weight + 1001);
                    }
                    break;

                case Direction.North:
                    newY = move.Y - 1;
                    if (newY >= 0)
                    {
                        if (_map[newY, move.X].Sprite != '#')
                        {
                            priorityQueue.Enqueue((move.X, newY, move.Direction, move.Weight + 1), move.Weight + 1);
                        }
                    }

                    newX = move.X + 1;
                    if (newX < Size)
                    {
                        if (_map[move.Y, newX].Sprite != '#')
                        {
                            priorityQueue.Enqueue((newX, move.Y, Direction.East, move.Weight + 1001), move.Weight + 1001);
                        }
                    }

                    newX = move.X - 1;
                    if (newX >= 0)
                    {
                        if (_map[move.Y, newX].Sprite != '#')
                        {
                            priorityQueue.Enqueue((newX, move.Y, Direction.West, move.Weight + 1001), move.Weight + 1001);
                        }
                    }
                    break;

                case Direction.West:
                    newX = move.X - 1;
                    if (newX >= 0 && _map[move.Y, newX].Sprite != '#')
                    {
                        priorityQueue.Enqueue((newX, move.Y, move.Direction, move.Weight + 1), move.Weight + 1);
                    }

                    newY = move.Y - 1;
                    if (newY >= 0 && _map[newY, move.X].Sprite != '#')
                    {
                        priorityQueue.Enqueue((move.X, newY, Direction.North, move.Weight + 1001), move.Weight + 1001);
                    }

                    newY = move.Y + 1;
                    if (newY < Size && _map[newY, move.X].Sprite != '#')
                    {
                        priorityQueue.Enqueue((move.X, newY, Direction.South, move.Weight + 1001), move.Weight + 1001);
                    }
                    break;

                case Direction.South:
                    newY = move.Y + 1;
                    if (newY < Size)
                    {
                        if (_map[newY, move.X].Sprite != '#')
                        {
                            priorityQueue.Enqueue((move.X, newY, move.Direction, move.Weight + 1), move.Weight + 1);
                        }
                    }

                    newX = move.X + 1;
                    if (newX < Size && _map[move.Y, newX].Sprite != '#')
                    {
                        priorityQueue.Enqueue((newX, move.Y, Direction.East, move.Weight + 1001), move.Weight + 1001);
                    }

                    newX = move.X - 1;
                    if (newX >= 0 && _map[move.Y, newX].Sprite != '#')
                    {
                        priorityQueue.Enqueue((newX, move.Y, Direction.West, move.Weight + 1001), move.Weight + 1001);
                    }
                    break;
            }
        }
    }

    private bool IsEndPoint(int x, int y) => _map[y, x].Sprite == 'E';

    private int CalculatePriority(int x, int y) => (Size - y) * (Size - x);
}