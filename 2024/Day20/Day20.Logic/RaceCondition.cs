



using System.Security.Cryptography.X509Certificates;

namespace Day20.Logic;

public class RaceCondition
{
    private readonly string _input;
    private readonly string[] _lines;
    private char[,] _map;

    public int Size => _lines.Length;

    public (int X, int Y) Start { get; private set; }
    public (int X, int Y) End { get; private set; }
    public int FastCheatsCount { get; private set; }

    public RaceCondition(string input)
    {
        _input = input;
        _lines = _input.Split('\n').ToArray();
        _map = new char[Size, Size];
        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                switch (_lines[y][x])
                {
                    case 'S':
                        Start = (x, y);
                        _map[y,x] = '.';
                        break;

                    case 'E':
                        End = (x, y);
                        _map[y,x] = '.';
                        break;

                    default:
                        _map[y, x] = _lines[y][x];
                        break;
                }
            }
        }
    }

//              -20,0
//       -19,-1 -19,0 -19,1
//-18,-2 -18,-1 -18,0 -18,1 -18,2

    public void Find20PicosecondCheatsSavingAtLeast(int picoseconds)
    {
        var weights = new int[Size,Size];
        var list = new List<(int X, int Y, int Weight)>();
        ScanMap(weights, list, Start.X, Start.Y, 1);
        var cache = list.OrderBy(p => p.Weight).Select(p => (p.X, p.Y)).ToArray();
        var cheats = new List<((int X, int Y) Begin, (int X, int Y) End, int Savings)>();

        for (var weight = 1; weight < weights[End.Y, End.X]; weight++)
        {
            var (x, y) = cache[weight - 1];

            for (var offsetY = -20; offsetY <= 20; offsetY++)
            {
                var limit = 20 - Math.Abs(offsetY);
                for (var offsetX = -limit; offsetX <= limit; offsetX++)
                {
                    var modifiedX = x + offsetX;
                    var modifiedY = y + offsetY;

                    if (modifiedX < Size - 1 && modifiedX >= 0 && modifiedY < Size - 1 && modifiedY >= 0)
                    {
                        int v = weights[modifiedY, modifiedX] - weights[y, x] - Math.Abs(offsetX) - Math.Abs(offsetY);
                        if (_map[modifiedY, modifiedX] != '#' && v > 0)
                        {
                            cheats.Add(((x, y), (modifiedX, modifiedY), v));
                        }
                    }
                }
            }
        }

        FastCheatsCount = cheats.Count(p => p.Savings >= picoseconds);
    }

    public void FindCheatsSavingAtLeast(int picoseconds)
    {
        var weights = new int[Size,Size];
        var list = new List<(int X, int Y, int Weight)>();
        ScanMap(weights, list, Start.X, Start.Y, 1);
        var cache = list.OrderBy(p => p.Weight).Select(p => (p.X, p.Y)).ToArray();
        var cheats = new List<((int X, int Y) Begin, (int X, int Y) End, int Savings)>();

        for (var weight = 1; weight < weights[End.Y, End.X]; weight++)
        {
            var (x, y) = cache[weight - 1];
            var incrementedX = x + 1;
            var decrementedX = x - 1;
            var incrementedY = y + 1;
            var decrementedY = y - 1;

            if (incrementedX < Size - 1 && _map[y, incrementedX] == '#' && _map[y, incrementedX + 1] != '#' && weights[y, incrementedX + 1] > weights[y, x])
            {
                cheats.Add(((x, y), (incrementedX + 1, y), weights[y, incrementedX + 1] - weights[y, x] - 2));
            }

            if (decrementedX > 1 && _map[y, decrementedX] == '#' && _map[y, decrementedX - 1] != '#' && weights[y, decrementedX - 1] > weights[y, x])
            {
                cheats.Add(((x, y), (decrementedX - 1, y), weights[y, decrementedX - 1] - weights[y, x] - 2));
            }

            if (incrementedY < Size - 1 && _map[incrementedY, x] == '#' && _map[incrementedY + 1, x] != '#' && weights[incrementedY + 1, x] > weights[y, x])
            {
                cheats.Add(((x, y), (x, incrementedY + 1), weights[incrementedY + 1, x] - weights[y, x] - 2));
            }

            if (decrementedY > 1 && _map[decrementedY, x] == '#' && _map[decrementedY - 1, x] != '#' && weights[decrementedY - 1, x] > weights[y, x])
            {
                cheats.Add(((x, y), (x, decrementedY - 1), weights[decrementedY - 1, x] - weights[y, x] - 2));
            }
        }

        FastCheatsCount = cheats.Count(p => p.Savings >= picoseconds);
    }

    private void ScanMap(int[,] weights, List<(int X, int Y, int Weight)> list, int x, int y, int weight)
    {
        if (weights[y, x] > 0)
        {
            return;
        }

        weights[y, x] = weight;
        list.Add((x, y, weight));

        if (x == End.X && y == End.Y)
        {
            return;
        }

        if (x - 1 >= 0 && _map[y, x-1] != '#')
        {
            ScanMap(weights, list, x - 1, y, weight + 1);
        }

        if (x + 1 < Size && _map[y, x+1] != '#')
        {
            ScanMap(weights, list, x + 1, y, weight + 1);
        }

        if (y - 1 >= 0 && _map[y-1, x] != '#')
        {
            ScanMap(weights, list, x, y - 1, weight + 1);
        }

        if (y + 1 >= 0 && _map[y+1, x] != '#')
        {
            ScanMap(weights, list, x, y + 1, weight + 1);
        }
    }
}