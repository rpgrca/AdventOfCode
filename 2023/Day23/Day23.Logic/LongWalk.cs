
namespace Day23.Logic;

public class LongWalk
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly bool[,] _visited;

    public int Width => _lines[0].Length;
    public int Height => _lines.Length;
    public (int X, int Y) StartingPosition { get; set; }
    public (int X, int Y) EndingPosition { get; set; }
    public int LongestPathLength { get; set; }

    public LongWalk(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _visited = new bool[Width, Height];

        StartingPosition = (_lines[0].IndexOf("."), 0);
        EndingPosition = (_lines[Height - 1].IndexOf("."), Height - 1);
    }

    public void FindLongestSlipperyPath()
    {
        var visited = new HashSet<int> { StartingPosition.Y << 8 | StartingPosition.X };
        FindLongestPath(StartingPosition.X, StartingPosition.Y, visited, 0);
    }

    private void FindLongestPath(int currentX, int currentY, HashSet<int> visited, int steps)
    {
        if (EndingPosition.X == currentX && EndingPosition.Y == currentY)
        {
            if (LongestPathLength < steps)
            {
                LongestPathLength = steps;
                return;
            }
        }

        visited.Add(currentX, currentY);

        switch (_lines[currentY][currentX])
        {
            case '>':
                if (! visited.Contains(currentX + 1, currentY))
                {
                    FindLongestPath(currentX + 1, currentY, visited, steps + 1);
                }
                break;

            case '<':
                if (! visited.Contains(currentX - 1, currentY))
                {
                    FindLongestPath(currentX - 1, currentY, visited, steps + 1);
                }
                break;

            case '^':
                if (! visited.Contains(currentX, currentY - 1))
                {
                    FindLongestPath(currentX, currentY - 1, visited, steps + 1);
                }
                break;

            case 'v':
                if (! visited.Contains(currentX, currentY + 1))
                {
                    FindLongestPath(currentX, currentY + 1, visited, steps + 1);
                }
                break;

            case '.':
                if (currentY - 1 >= 0 && !visited.Contains(currentX, currentY - 1))
                {
                    FindLongestPath(currentX, currentY - 1, visited, steps + 1);
                }

                if (currentX - 1 >= 0 && ! visited.Contains(currentX - 1, currentY))
                {
                    FindLongestPath(currentX - 1, currentY, visited, steps + 1);
                }

                if (currentX + 1 < Width && ! visited.Contains(currentX + 1, currentY))
                {
                    FindLongestPath(currentX + 1, currentY, visited, steps + 1);
                }

                if (currentY + 1 < Height && ! visited.Contains(currentX, currentY + 1))
                {
                    FindLongestPath(currentX, currentY + 1, visited, steps + 1);
                }
                break;

            default: // #
                break;
        }

        visited.Remove(currentX, currentY);
    }

    public void FindLongestDryPath()
    {
        FindLongestDryPath(StartingPosition.X, StartingPosition.Y, 0);
    }

    private void FindLongestDryPath(int currentX, int currentY, int steps)
    {
        if (EndingPosition.X == currentX && EndingPosition.Y == currentY)
        {
            if (LongestPathLength < steps)
            {
                LongestPathLength = steps;
                Console.WriteLine($"{DateTime.Now}: {steps}");
                return;
            }
        }

        _visited[currentX, currentY] = true;

        if (currentY - 1 >= 0 && _lines[currentY - 1][currentX] != '#' && !_visited[currentX, currentY - 1])
        {
            FindLongestDryPath(currentX, currentY - 1, steps + 1);
        }

        if (currentX - 1 >= 0 && _lines[currentY][currentX - 1] != '#' && ! _visited[currentX - 1, currentY])
        {
            FindLongestDryPath(currentX - 1, currentY, steps + 1);
        }

        if (currentX + 1 < Width && _lines[currentY][currentX + 1] != '#' && ! _visited[currentX + 1, currentY])
        {
            FindLongestDryPath(currentX + 1, currentY, steps + 1);
        }

        if (currentY + 1 < Height && _lines[currentY + 1][currentX] != '#' && ! _visited[currentX, currentY + 1])
        {
            FindLongestDryPath(currentX, currentY + 1, steps + 1);
        }

        _visited[currentX, currentY] = false;
    }
}