



using System.Diagnostics;

namespace Day17.Logic;

[DebuggerDisplay("{HeatLoss} [Total: {MinimumAccumulatedHeatLoss}]")]
public class Block
{
    public int HeatLoss { get; init; }
    public int MinimumAccumulatedHeatLoss { get; set; }

    public Block(int heatLoss)
    {
        HeatLoss = heatLoss;
        MinimumAccumulatedHeatLoss = int.MaxValue;
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

    public ClumsyCrucible(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        _leastHeatLossAtGoal = int.MaxValue;

        Entrance = (0, 0);
        Goal = (Width - 1, Height - 1);

        _heatLossMap = _lines.Select(l => l.Select(c => new Block(c - '0')).ToArray()).ToList();
    }

    public void FindBestRoute()
    {
        FindBestRoute(Entrance.X, Entrance.Y, 0, 0, '?');
    }

    private void FindBestRoute(int currentX, int currentY, int accumulatedHeatLoss, int straightMoves, char currentDirection)
    {
        int possibleAccumulatedHeatLoss;
        int possibleStraightMoves;

        _heatLossMap[currentY][currentX].MinimumAccumulatedHeatLoss = accumulatedHeatLoss;
        if (currentX == Goal.X && currentY == Goal.Y)
        {
            if (_leastHeatLossAtGoal > _heatLossMap[currentY][currentX].MinimumAccumulatedHeatLoss)
            {
                _leastHeatLossAtGoal = _heatLossMap[currentY][currentX].MinimumAccumulatedHeatLoss;
                return;
            }
        }

        var possibleNextX = currentX + 1;
        if (possibleNextX < Width)
        {
            possibleStraightMoves = currentDirection != 'e' ? 0 : straightMoves + 1;
            if (possibleStraightMoves < 3)
            {
                possibleAccumulatedHeatLoss = accumulatedHeatLoss + _heatLossMap[currentY][possibleNextX].HeatLoss;
                if (_heatLossMap[currentY][possibleNextX].MinimumAccumulatedHeatLoss > possibleAccumulatedHeatLoss)
                {
                    FindBestRoute(possibleNextX, currentY, possibleAccumulatedHeatLoss, possibleStraightMoves, 'e');
                }
            }
        }

        var possibleNextY = currentY + 1;
        if (possibleNextY < Height)
        {
            possibleStraightMoves = currentDirection != 's' ? 0 : straightMoves + 1;
            if (possibleStraightMoves < 3)
            {
                possibleAccumulatedHeatLoss = accumulatedHeatLoss + _heatLossMap[possibleNextY][currentX].HeatLoss;
                if (_heatLossMap[possibleNextY][currentX].MinimumAccumulatedHeatLoss > possibleAccumulatedHeatLoss)
                {
                    FindBestRoute(currentX, possibleNextY, possibleAccumulatedHeatLoss, possibleStraightMoves, 's');
                }
            }
        }

        possibleNextX = currentX - 1;
        if (possibleNextX >= 0)
        {
            possibleStraightMoves = currentDirection == 'w' ? 0 : straightMoves + 1;
            if (possibleStraightMoves < 3)
            {
                possibleAccumulatedHeatLoss = accumulatedHeatLoss + _heatLossMap[currentY][possibleNextX].HeatLoss;
                if (_heatLossMap[currentY][possibleNextX].MinimumAccumulatedHeatLoss > possibleAccumulatedHeatLoss)
                {
                    FindBestRoute(possibleNextX, currentY, possibleAccumulatedHeatLoss, possibleStraightMoves, 'w');
                }
            }
        }

        possibleNextY = currentY - 1;
        if (possibleNextY >= 0)
        {
            possibleStraightMoves = currentDirection == 'n' ? 0 : straightMoves + 1;
            if (possibleStraightMoves < 3)
            {
                possibleAccumulatedHeatLoss = accumulatedHeatLoss + _heatLossMap[possibleNextY][currentX].HeatLoss;
                if (_heatLossMap[possibleNextY][currentX].MinimumAccumulatedHeatLoss > possibleAccumulatedHeatLoss)
                {
                    FindBestRoute(currentX, possibleNextY, possibleAccumulatedHeatLoss, possibleStraightMoves, 'n');
                }
            }
        }
    }
}
