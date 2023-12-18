using System.Diagnostics;

namespace Day17.Logic;


[DebuggerDisplay("{HeatLoss} [Total: {MinimumAccumulatedHeatLoss}]")]
public class Block : IBlock
{
    public int HeatLoss { get; }

    public int MinimumAccumulatedHeatLoss { get; private set; }

    public Block(int heatLoss)
    {
        HeatLoss = heatLoss;
        MinimumAccumulatedHeatLoss = int.MaxValue;
    }

    public void Push(int minimumAccumulatedHeatLoss)
    {
        MinimumAccumulatedHeatLoss = minimumAccumulatedHeatLoss;
    }

    public void Pop()
    {
    }
}

[DebuggerDisplay("{HeatLoss} [Total: {MinimumAccumulatedHeatLoss}]")]
public class Block2 : IBlock
{
    private readonly int[] _minimum;
    private int _index;

    public int HeatLoss { get; }

    public int MinimumAccumulatedHeatLoss => _minimum[_index];

    public Block2(int heatLoss)
    {
        HeatLoss = heatLoss;
        _minimum = new int[5000];
        _index = 0;
        for (var index = 0; index < 5000; index++)
        {
            _minimum[index] = int.MaxValue;
        }
    }

    public void Push(int minimumAccumulatedHeatLoss)
    {
        if (_index < 5000 - 1)
        {
            _minimum[++_index] = minimumAccumulatedHeatLoss;
        }
        else
        {
            throw new ArgumentOutOfRangeException("More than 5000 elements in cache");
        }
    }

    public void Pop()
    {
        if (_index > 0)
        {
            _index--;
        }
    }
}

public interface IBlock
{
    int HeatLoss { get; }
    int MinimumAccumulatedHeatLoss { get; }
    void Push(int minimumAccumulatedHeatLoss);
    void Pop();
}

public class ClumsyCrucible
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly IBlock[][] _heatLossMap;
    private char _direction;
    private int _straightMoves;
    private int _leastHeatLossAtGoal;
    private List<char> _bestSteps;

    public int Width => _lines[0].Length;
    public int Height => _lines.Length;

    public (int X, int Y) Entrance { get; }
    public (int X, int Y) Goal { get; }
    public int HeatLoss => _leastHeatLossAtGoal;

    public ClumsyCrucible(string input, bool scanSampleRoute = false, int leastHeatLossAtGoal = 2_000_000)
    {
        _input = input;
        _lines = _input.Split("\n");
        _leastHeatLossAtGoal = leastHeatLossAtGoal;

        Entrance = (0, 0);
        Goal = (Width - 1, Height - 1);

        _heatLossMap = _lines.Select(l => l.Select(c => new Block2(c - '0')).Cast<IBlock>().ToArray()).ToArray();

        if (scanSampleRoute)
        {
            FindSampleRoute();
        }
    }

    public void FindBestRoute()
    {
        var steps = new List<char>();
        FindBestRoute(Entrance.X, Entrance.Y, -1, -1, 0, 0, '?');
/*
        var map = string.Empty;
        for (var y = 0; y < Height; y++)
        {
            for (var x = 0; x < Width; x++)
            {
                map += _heatLossMap[y][x].MinimumAccumulatedHeatLoss.ToString("D4") + ' ';
            }

            map += '\n';
        }

        Console.WriteLine(map);*/
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

        if (currentX == Goal.X && currentY == Goal.Y)
        {
            if (_leastHeatLossAtGoal > accumulatedHeatLoss)
            {
                _heatLossMap[currentY][currentX].Push(accumulatedHeatLoss);
                _leastHeatLossAtGoal = accumulatedHeatLoss;
                //Console.WriteLine(_leastHeatLossAtGoal);
                //_bestSteps = steps.Select(p => p).ToList();
            }

            return;
        }

        if (_heatLossMap[currentY][currentX].MinimumAccumulatedHeatLoss > accumulatedHeatLoss)
        {
            _heatLossMap[currentY][currentX].Push(accumulatedHeatLoss);
        }
        else
        {
            throw new Exception("Invalid state");
        }

        var possibleNextX = currentX + 1;
        if (possibleNextX < Width)
        {
            if (currentDirection != 'w')
            {
                possibleStraightMoves = currentDirection != 'e' ? 0 : straightMoves + 1;
                if (possibleStraightMoves < 3)
                {
                    possibleAccumulatedHeatLoss = accumulatedHeatLoss + _heatLossMap[currentY][possibleNextX].HeatLoss;
                    if (possibleAccumulatedHeatLoss < _leastHeatLossAtGoal && _heatLossMap[currentY][possibleNextX].MinimumAccumulatedHeatLoss > possibleAccumulatedHeatLoss)
                    {
                        //steps.Add('e');
                        FindBestRoute(possibleNextX, currentY, currentX, currentY, possibleAccumulatedHeatLoss, possibleStraightMoves, 'e');
                        //steps.RemoveAt(steps.Count - 1);
                    }
                }
            }
        }

        var possibleNextY = currentY + 1;
        if (possibleNextY < Height)
        {
            if (currentDirection != 'n')
            {
                possibleStraightMoves = currentDirection != 's' ? 0 : straightMoves + 1;
                if (possibleStraightMoves < 3)
                {
                    possibleAccumulatedHeatLoss = accumulatedHeatLoss + _heatLossMap[possibleNextY][currentX].HeatLoss;
                    if (possibleAccumulatedHeatLoss < _leastHeatLossAtGoal && _heatLossMap[possibleNextY][currentX].MinimumAccumulatedHeatLoss > possibleAccumulatedHeatLoss)
                    {
                        //steps.Add('s');
                        FindBestRoute(currentX, possibleNextY, currentX, currentY, possibleAccumulatedHeatLoss, possibleStraightMoves, 's');
                        //steps.RemoveAt(steps.Count - 1);
                    }
                }
            }
        }

        possibleNextX = currentX - 1;
        if (possibleNextX >= 0)
        {
            if (currentDirection != 'e')
            {
                possibleStraightMoves = currentDirection != 'w' ? 0 : straightMoves + 1;
                if (possibleStraightMoves < 3)
                {
                    possibleAccumulatedHeatLoss = accumulatedHeatLoss + _heatLossMap[currentY][possibleNextX].HeatLoss;
                    if (possibleAccumulatedHeatLoss < _leastHeatLossAtGoal && _heatLossMap[currentY][possibleNextX].MinimumAccumulatedHeatLoss > possibleAccumulatedHeatLoss)
                    {
                        //steps.Add('w');
                        FindBestRoute(possibleNextX, currentY, currentX, currentY, possibleAccumulatedHeatLoss, possibleStraightMoves, 'w');
                        //steps.RemoveAt(steps.Count - 1);
                    }
                }
            }
        }

        possibleNextY = currentY - 1;
        if (possibleNextY >= 0)
        {
            if (currentDirection != 's')
            {
                possibleStraightMoves = currentDirection != 'n' ? 0 : straightMoves + 1;
                if (possibleStraightMoves < 3)
                {
                    possibleAccumulatedHeatLoss = accumulatedHeatLoss + _heatLossMap[possibleNextY][currentX].HeatLoss;
                    if (possibleAccumulatedHeatLoss < _leastHeatLossAtGoal && _heatLossMap[possibleNextY][currentX].MinimumAccumulatedHeatLoss > possibleAccumulatedHeatLoss)
                    {
                        //steps.Add('n');
                        FindBestRoute(currentX, possibleNextY, currentX, currentY, possibleAccumulatedHeatLoss, possibleStraightMoves, 'n');
                        //steps.RemoveAt(steps.Count - 1);
                    }
                }
            }
        }

        _heatLossMap[currentY][currentX].Pop();
    }
}
