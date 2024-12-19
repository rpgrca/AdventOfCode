using System.Runtime.CompilerServices;
using System.Text;

namespace Day18.Logic;

public class RamRun
{
    private readonly string _input;
    private readonly List<(int X, int Y)> _corruptedMemory;

    public int Count => _corruptedMemory.Count;

    public int Size { get; private set; }
    public int Steps { get; private set; }
    public string BlockedPath { get; private set; }

    private readonly char[,] _memoryMap;
    private readonly int[,] _map;

    public RamRun(string input, int size)
    {
        _input = input;
        Size = size;
        BlockedPath = string.Empty;
        _memoryMap = new char[Size,Size];
        _map = new int[Size, Size];
        for (var y = 0; y < Size; y++)
            for (var x = 0; x < Size; x++)
            {
                _memoryMap[y,x] = '.';
                _map[y,x] = 512;
            }

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

    public string PlotWeights()
    {
        var sb = new StringBuilder();
        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                if (_memoryMap[y, x] == '#')
                {
                    sb.Append("###");
                }
                else
                {
                    sb.Append($"{_map[y, x],03}");
                }
                sb.Append('\t');
            }

            sb.AppendLine();
        }

        return sb.ToString().Trim();
    }

    private int MakeWeight(int x, int y, int steps) => (steps << 16) | ((Size - y) << 8) | (Size - x);

    public void Solve()
    {
        Steps = int.MaxValue;
        _map[0, 0] = 0;

        var visited = new HashSet<int>();
        var priorityQueue = new PriorityQueue<int, int>();

        if (_memoryMap[0, 1] != '#')
        {
            priorityQueue.Enqueue(Encode(1, 0, 1), MakeWeight(1, 0, 1));
        }

        if (_memoryMap[1, 0] != '#')
        {
            priorityQueue.Enqueue(Encode(0, 1, 1), MakeWeight(0, 1, 1));
        }

        while (priorityQueue.Count > 0)
        {
            var value = priorityQueue.Dequeue();
            var x = DecodeX(value);
            var y = DecodeY(value);
            var steps = DecodeSteps(value);
            if (x == Size - 1 && y == Size - 1)
            {
                if (Steps > steps)
                {
                    Steps = steps;
                    continue;
                }
            }


            if (visited.Contains(value))
            {
                continue;
            }
            visited.Add(value);

/*
            if (_map[y, x] < steps)
            {
                continue;
            }

            _map[y, x] = steps;
*/
            var incrementedX = x + 1;
            var decrementedX = x - 1;
            var incrementedY = y + 1;
            var decrementedY = y - 1;
            var nextSteps = steps + 1;
            if (x < Size - 1 && _map[y, incrementedX] > nextSteps && _memoryMap[y, incrementedX] != '#')
            {
                priorityQueue.Enqueue(Encode(incrementedX, y, nextSteps), MakeWeight(incrementedX, y, nextSteps));
            }

            if (y < Size - 1 && _map[incrementedY, x] > nextSteps && _memoryMap[incrementedY, x] != '#')
            {
                priorityQueue.Enqueue(Encode(x, incrementedY, nextSteps), MakeWeight(x, incrementedY, nextSteps));
            }

            if (x > 0 && _map[y, decrementedX] > nextSteps && _memoryMap[y, decrementedX] != '#')
            {
                priorityQueue.Enqueue(Encode(decrementedX, y, nextSteps), MakeWeight(decrementedX, y, nextSteps));
            }

            if (y > 0 && _map[decrementedY, x] > nextSteps && _memoryMap[decrementedY, x] != '#')
            {
                priorityQueue.Enqueue(Encode(x, decrementedY, nextSteps), MakeWeight(x, decrementedY, nextSteps));
            }
        }
    }

    private int Encode(int x, int y, int steps) => (steps << 16) | (y << 8) | x;

    private int DecodeX(int value) => value & 0xff;

    private int DecodeY(int value) => (value >> 8) & 0xff;

    private int DecodeSteps(int value) => (value >> 16) & 0xffff;

    public void SolveDeeply()
    {
        Steps = int.MaxValue;
        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                _map[y, x] = int.MaxValue;
            }
        }

        SolveDeeply(_map, 0, 0, 0);
    }

    private void SolveDeeply(int[,] map, int x, int y, int weight)
    {
        if (x == Size - 1 && y == Size - 1)
        {
            if (weight < map[y, x])
            {
                map[y, x] = weight;
            }

            if (Steps > weight)
            {
                Steps = weight;
            }

            return;
        }

        if (map[y, x] < weight)
        {
            return;
        }

        map[y, x] = weight;

        var incrementedX = x + 1;
        var decrementedX = x - 1;
        var incrementedY = y + 1;
        var decrementedY = y - 1;

        if (x < Size - 1 && _memoryMap[y, incrementedX] != '#')
        {
            SolveDeeply(map, incrementedX, y, weight + 1);
        }

        if (y < Size - 1 && _memoryMap[incrementedY, x] != '#')
        {
            SolveDeeply(map, x, incrementedY, weight + 1);
        }

        if (x > 0 && _memoryMap[y, decrementedX] != '#')
        {
            SolveDeeply(map, decrementedX, y, weight + 1);
        }

        if (y > 0 && _memoryMap[decrementedY, x] != '#')
        {
            SolveDeeply(map, x, decrementedY, weight + 1);
        }

    }

    public void SolveDrop(int bytes)
    {
        foreach (var corruptedMemory in _corruptedMemory.Skip(bytes))
        {
            _memoryMap[corruptedMemory.Y, corruptedMemory.X] = '#';
            Solve();
            if (Steps == int.MaxValue)
            {
                BlockedPath = $"{corruptedMemory.X},{corruptedMemory.Y}";
                break;
            }
        }
    }
}
