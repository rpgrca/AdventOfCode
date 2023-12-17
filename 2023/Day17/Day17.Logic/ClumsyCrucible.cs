using System.Diagnostics;

namespace Day17.Logic;

[DebuggerDisplay("{HeatLoss} [Total: {MinimumAccumulatedHeatLoss}]")]
public class Block
{
    private readonly List<int> _minimumAccumulatedHeatLoss;

    public int HeatLoss { get; }

    public int MinimumAccumulatedHeatLoss => _minimumAccumulatedHeatLoss.Last();

    public Block(int heatLoss)
    {
        HeatLoss = heatLoss;
        _minimumAccumulatedHeatLoss = new List<int>
        {
            int.MaxValue
        };
    }

    public void Push(int minimumAccumulatedHeatLoss)
    {
        _minimumAccumulatedHeatLoss.Add(minimumAccumulatedHeatLoss);
    }

    public void Pop()
    {
        _minimumAccumulatedHeatLoss.RemoveAt(_minimumAccumulatedHeatLoss.Count - 1);
    }
}

public class ClumsyCrucible
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly List<Block[]> _heatLossMap;
    private char _direction;
    private int _straightMoves;
    private int _leastHeatLossAtGoal;

    public int Width => _lines[0].Length;
    public int Height => _lines.Length;

    public (int X, int Y) Entrance { get; }
    public (int X, int Y) Goal { get; }
    public int HeatLoss => _leastHeatLossAtGoal;

    public ClumsyCrucible(string input, bool scanSampleRoute = false)
    {
        _input = input;
        _lines = _input.Split("\n");
        _leastHeatLossAtGoal = int.MaxValue;

        Entrance = (0, 0);
        Goal = (Width - 1, Height - 1);

        _heatLossMap = _lines.Select(l => l.Select(c => new Block(c - '0')).ToArray()).ToList();

        if (scanSampleRoute)
        {
            FindSampleRoute();
        }
    }

    public void FindBestRoute()
    {
        FindBestRoute(Entrance.X, Entrance.Y, -1, -1, 0, 0, '?');

        var map = string.Empty;
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                map += _heatLossMap[y][x].MinimumAccumulatedHeatLoss.ToString("D4") + ' ';
            }

            map += '\n';
        }

        Console.WriteLine(map);
    }

    private void FindSampleRoute()
    {
        var currentX = Entrance.X;
        var currentY = Entrance.Y;
        var accumulator = 0;

        while (currentX < Goal.X || currentY < Goal.Y)
        {
            accumulator += _heatLossMap[currentY][currentX].HeatLoss;

            if (currentX < Goal.X && currentX - currentY == 0)
            {
                currentX++;
            }
            else
            {
                currentY++;
            }
        }

        _leastHeatLossAtGoal = accumulator;
    }

    private void FindBestRoute(int currentX, int currentY, int previousX, int previousY, int accumulatedHeatLoss, int straightMoves, char currentDirection)
    {
        int possibleAccumulatedHeatLoss;
        int possibleStraightMoves;

        if (_heatLossMap[currentY][currentX].MinimumAccumulatedHeatLoss > accumulatedHeatLoss)
        {
            _heatLossMap[currentY][currentX].Push(accumulatedHeatLoss);
        }
        else
        {
            throw new Exception("Invalid state");
        }

        if (currentX == Goal.X && currentY == Goal.Y)
        {
            if (_leastHeatLossAtGoal > _heatLossMap[currentY][currentX].MinimumAccumulatedHeatLoss)
            {
                _leastHeatLossAtGoal = _heatLossMap[currentY][currentX].MinimumAccumulatedHeatLoss;
                return;
            }
        }

        if (accumulatedHeatLoss > _leastHeatLossAtGoal)
        {
            return;
        }

        var possibleNextX = currentX + 1;
        if (possibleNextX < Width)
        {
            if (previousX != possibleNextX || previousY != currentY)
            {
                possibleStraightMoves = currentDirection != 'e' ? 0 : straightMoves + 1;
                if (possibleStraightMoves < 3)
                {
                    possibleAccumulatedHeatLoss = accumulatedHeatLoss + _heatLossMap[currentY][possibleNextX].HeatLoss;
                    if (_heatLossMap[currentY][possibleNextX].MinimumAccumulatedHeatLoss > possibleAccumulatedHeatLoss)
                    {
                        FindBestRoute(possibleNextX, currentY, currentX, currentY, possibleAccumulatedHeatLoss, possibleStraightMoves, 'e');
                    }
                }
            }
        }

        var possibleNextY = currentY + 1;
        if (possibleNextY < Height)
        {
            if (previousX != currentX || previousY != possibleNextY)
            {
                possibleStraightMoves = currentDirection != 's' ? 0 : straightMoves + 1;
                if (possibleStraightMoves < 3)
                {
                    possibleAccumulatedHeatLoss = accumulatedHeatLoss + _heatLossMap[possibleNextY][currentX].HeatLoss;
                    if (_heatLossMap[possibleNextY][currentX].MinimumAccumulatedHeatLoss > possibleAccumulatedHeatLoss)
                    {
                        FindBestRoute(currentX, possibleNextY, currentX, currentY, possibleAccumulatedHeatLoss, possibleStraightMoves, 's');
                    }
                }
            }
        }

        possibleNextX = currentX - 1;
        if (possibleNextX >= 0)
        {
            if (previousX != possibleNextX || previousY != currentY)
            {
                possibleStraightMoves = currentDirection != 'w' ? 0 : straightMoves + 1;
                if (possibleStraightMoves < 3)
                {
                    possibleAccumulatedHeatLoss = accumulatedHeatLoss + _heatLossMap[currentY][possibleNextX].HeatLoss;
                    if (_heatLossMap[currentY][possibleNextX].MinimumAccumulatedHeatLoss > possibleAccumulatedHeatLoss)
                    {
                        FindBestRoute(possibleNextX, currentY, currentX, currentY, possibleAccumulatedHeatLoss, possibleStraightMoves, 'w');
                    }
                }
            }
        }

        possibleNextY = currentY - 1;
        if (possibleNextY >= 0)
        {
            if (previousX != currentX || previousY != possibleNextY)
            {
                possibleStraightMoves = currentDirection != 'n' ? 0 : straightMoves + 1;
                if (possibleStraightMoves < 3)
                {
                    possibleAccumulatedHeatLoss = accumulatedHeatLoss + _heatLossMap[possibleNextY][currentX].HeatLoss;
                    if (_heatLossMap[possibleNextY][currentX].MinimumAccumulatedHeatLoss > possibleAccumulatedHeatLoss)
                    {
                        FindBestRoute(currentX, possibleNextY, currentX, currentY, possibleAccumulatedHeatLoss, possibleStraightMoves, 'n');
                    }
                }
            }
        }

        _heatLossMap[currentY][currentX].Pop();
    }
}
