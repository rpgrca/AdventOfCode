using System.Text;

namespace Day18.Logic;

public class RamRun
{
    private readonly string _input;
    private readonly List<(int X, int Y)> _corruptedMemory;

    public int Count => _corruptedMemory.Count;

    public int Size { get; private set; }
    public int Steps { get; private set; }

    private readonly char[,] _memoryMap;

    public RamRun(string input, int size)
    {
        _input = input;
        Size = size;
        _memoryMap = new char[Size,Size];
        for (var y = 0; y < Size; y++)
            for (var x = 0; x < Size; x++)
                _memoryMap[y,x] = '.';

        _corruptedMemory = _input.Split('\n')
            .Select(p => (int.Parse(p.Split(',')[0]), int.Parse(p.Split(',')[1])))
            .ToList();
    }

    public void Load(int bytes)
    {
        foreach (var corruptedMemory in _corruptedMemory.Take(bytes))
        {
            _memoryMap[corruptedMemory.Y, corruptedMemory.X] = '#';
        }
    }

    public string Plot()
    {
        var sb = new StringBuilder();
        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                sb.Append(_memoryMap[y, x]);
            }

            sb.AppendLine();
        }

        return sb.ToString().Trim();
    }

    public void Solve()
    {
        Steps = int.MaxValue;
        var currentX = 0;
        var currentY = 0;
        var priorityQueue = new PriorityQueue<(int X, int Y, int Weight), int>();
        var visited = new HashSet<(int X, int Y)>();
        priorityQueue.Enqueue((0, 1, 1), 1);
        priorityQueue.Enqueue((1, 0, 1), 1);

        while (priorityQueue.Count > 0)
        {
            var nextStep = priorityQueue.Dequeue();
            if (nextStep.X == Size - 1 && nextStep.Y == Size - 1)
            {
                if (Steps > nextStep.Weight)
                {
                    Steps = nextStep.Weight;
                    continue;
                }
            }

            if (visited.Contains((nextStep.X, nextStep.Y)))
            {
                continue;
            }

            visited.Add((nextStep.X, nextStep.Y));
            var newWeight = nextStep.Weight + 1;
            if (nextStep.X > 0 && _memoryMap[nextStep.Y, nextStep.X - 1] != '#')
            {
                priorityQueue.Enqueue((nextStep.X - 1, nextStep.Y, newWeight), newWeight);
            }

            if (nextStep.X < Size - 1 && _memoryMap[nextStep.Y, nextStep.X + 1] != '#')
            {
                priorityQueue.Enqueue((nextStep.X + 1, nextStep.Y, newWeight), newWeight);
            }

            if (nextStep.Y > 0 && _memoryMap[nextStep.Y - 1, nextStep.X] != '#')
            {
                priorityQueue.Enqueue((nextStep.X, nextStep.Y - 1, newWeight), newWeight);
            }

            if (nextStep.Y < Size - 1 && _memoryMap[nextStep.Y + 1, nextStep.X] != '#')
            {
                priorityQueue.Enqueue((nextStep.X, nextStep.Y + 1, newWeight), newWeight);
            }
        }
    }
}
