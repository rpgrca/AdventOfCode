




using System.Security.Cryptography.X509Certificates;

namespace Day16.Logic;

public class ReindeerMaze
{
    private string _input;
    private string[] _lines;

    public int Size => _lines.Length;

    public (int X, int Y) StartPoint { get; private set; }
    public (int X, int Y) EndPoint { get; private set; }
    public int LowestScore { get; private set; }

    public ReindeerMaze(string input)
    {
        _input = input;
        _lines = _input.Split('\n');

        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                if (_lines[y][x] == 'S')
                {
                    StartPoint = (x, y);
                }
                else if (_lines[y][x] == 'E')
                {
                    EndPoint = (x, y);
                }
            }
        }
    }

    public enum Direction
    {
        East,
        North,
        West,
        South
    }

    public void Run()
    {
        var priorityQueue = new PriorityQueue<(int X, int Y, Direction Direction, int Total), int>();
        var x = StartPoint.X;
        var y = StartPoint.Y;

        priorityQueue.Enqueue((x, y, Direction.East, 0), 0);
        priorityQueue.Enqueue((x, y, Direction.North, 1000), 1000);
        priorityQueue.Enqueue((x, y, Direction.West, 2000), 2000);
        priorityQueue.Enqueue((x, y, Direction.South, 1000), 1000);
        while (priorityQueue.Count > 0)
        {
            var move = priorityQueue.Dequeue();
            if (EndPoint == (move.X, move.Y))
            {
                LowestScore = move.Total;
                return;
            }

            switch (move.Direction)
            {
                case Direction.East:
                    if (x + 1 < Size)
                    {
                        if (_lines[y][x + 1] != '#')
                        {
                            priorityQueue.Enqueue((move.X + 1, move.Y, move.Direction, move.Total + 1), move.Total + 1);
                        }
                    }
                    break;

                case Direction.North:
                    if (y - 1 >= 0)
                    {
                        if (_lines[y - 1][x] != '#')
                        {
                            priorityQueue.Enqueue((move.X, move.Y - 1, move.Direction, move.Total + 1), move.Total + 1);
                        }
                    }
                    break;

                case Direction.West:
                    if (x - 1 >= 0)
                    {
                        if (_lines[y][x - 1] != '#')
                        {
                            priorityQueue.Enqueue((move.X - 1, move.Y, move.Direction, move.Total + 1), move.Total + 1);
                        }
                    }
                    break;

                case Direction.South:
                    if (y + 1 < Size)
                    {
                        if (_lines[y + 1][x] != '#')
                        {
                            priorityQueue.Enqueue((move.X, move.Y + 1, move.Direction, move.Total + 1), move.Total + 1);
                        }
                    }
                    break;
            }
        }
    }

    private int CalculatePriority(int x, int y) => y * Size + x;
}