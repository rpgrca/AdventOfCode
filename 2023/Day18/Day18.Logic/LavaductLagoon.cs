using System.Data;
using System.Runtime.ExceptionServices;
namespace Day18.Logic;

public class LavaductLagoon
{
    private const int MapMaximumLength = 10_000;
    private readonly string _input;
    private readonly string[] _lines;
    private readonly char[][] _map;
    private readonly int _length;
    private readonly int _initialX;
    private readonly int _initialY;

    public int DigPlanLength => _lines.Length;

    public int TrenchPerimeter { get; private set; }
    public long TrenchArea { get; private set; }
    public List<(int Length, char Direction)> RealInstructions { get; }

    public LavaductLagoon(string input, int length = 100, bool create = true)
    {
        _input = input;
        _lines = _input.Split("\n");
        _length = length;
        _initialX = _length / 3;
        _initialY = _length / 3;
        RealInstructions = new List<(int, char)>();

        foreach (var line in _lines)
        {
            var command = line.Split(" ");
            RealInstructions.Add((int.Parse(command[1]), command[0][0]));
        }

        if (create)
        {
            _map = new char[length][];
            for (var index = 0; index < _length; index++)
            {
                _map[index] = new string('.', _length).ToCharArray();
            }
        }
    }

    public void Decode()
    {
        RealInstructions.Clear();
        foreach (var line in _lines)
        {
            var command = line.Split(" ");
            var hex = command[2][1..^1];
            var direction = hex[^1] switch {
                '0' => 'R',
                '1' => 'D',
                '2' => 'L',
                _ => 'U'
            };
            var length = Convert.ToInt32(hex[1..^1], 16);

            RealInstructions.Add((length, direction));
        }
    }

    public void Dig()
    {
        int steps;
        var currentX = _initialX;
        var currentY = _initialY;

        foreach (var line in _lines)
        {
            var command = line.Split(" ");
            steps = int.Parse(command[1]);

            switch (command[0])
            {
                case "R":
                    steps += currentX;
                    while (currentX < steps)
                    {
                        _map[currentY][currentX++] = '#';
                    }
                    break;

                case "D":
                    steps += currentY;
                    while (currentY < steps)
                    {
                        _map[currentY++][currentX] = '#';
                    }
                    break;

                case "L":
                    steps = currentX - steps;
                    while (currentX > steps)
                    {
                        _map[currentY][currentX--] = '#';
                    }
                    break;

                case "U":
                    steps = currentY - steps;
                    while (currentY > steps)
                    {
                        _map[currentY--][currentX] = '#';
                    }
                    break;
            }
        }
    }

    public void Draw()
    {
        foreach (var row in _map)
        {
            Console.WriteLine(string.Join("", row.Select(c => c)));
        }
    }

    public void CalculatePerimeter()
    {
        TrenchPerimeter = 0;
        for (var y = 0; y < _length; y++)
        {
            for (var x = 0; x < _length; x++)
            {
                if (_map[y][x] == '#')
                {
                    TrenchPerimeter++;
                }
            }
        }
    }

    public void CalculateArea()
    {
        FillArea(_initialX + 1, _initialY + 1);
        TrenchArea = 0;
        for (var y = 0; y < _length; y++)
        {
            for (var x = 0; x < _length; x++)
            {
                if (_map[y][x] == '#')
                {
                    TrenchArea++;
                }
            }
        }
    }

    private void FillArea(int x, int y)
    {
        var visited = new HashSet<(int, int)>();
        if (visited.Contains((x, y)))
        {
            return;
        }

        visited.Add((x, y));
        if (_map[y][x] == '.')
        {
            _map[y][x] = '#';
            if (x + 1 < _length && !visited.Contains((x + 1, y)))
            {
                FillArea(x + 1, y); // r
            }

            if (x - 1 >= 0 && !visited.Contains((x - 1, y)))
            {
                FillArea(x - 1, y); // l
            }

            if (y + 1 < _length && !visited.Contains((x, y + 1)))
            {
                FillArea(x, y + 1); // d
            }

            if (y - 1 >= 0 && !visited.Contains((x, y - 1)))
            {
                FillArea(x, y - 1); // u
            }
        }
    }

    public void CalculateArea2()
    {
        var currentX = _initialX;
        var currentY = _initialY;
        var mapRow = Enumerable.Range(0, MapMaximumLength).Select(p => new SortedList<int, (int Begin, int End)>()).ToArray();
        var inst = 0;
        foreach (var instruction in RealInstructions)
        {
            inst++;
            switch (instruction.Direction)
            {
                case 'R': // r
                    for (var index = currentX; index < currentX + instruction.Length; index++)
                    {
                        if (mapRow[index].Any(p => p.Value.Begin == currentY || p.Value.End == currentY))
                        {
                            continue;
                        }

                        mapRow[index].Add(currentY, (currentY, currentY));
                    }

                    currentX += instruction.Length;
                    break;

                case 'D': // d
                    mapRow[currentX].Add(currentY, (currentY, currentY + instruction.Length));
                    currentY += instruction.Length;
                    break;

                case 'L': // l
                    for (var index = currentX; index > currentX - instruction.Length; index--)
                    {
                        if (mapRow[index].Any(p => p.Value.Begin == currentY || p.Value.End == currentY))
                        {
                            continue;
                        }

                        mapRow[index].Add(currentY, (currentY, currentY));
                    }

                    currentX -= instruction.Length;
                    break;

                case 'U': // u
                    var previous = currentY - instruction.Length;
                    if (mapRow[currentX].ContainsKey(previous))
                    {
                        mapRow[currentX].TryAdd(previous, (previous, currentY));
                    }
                    else
                    {
                        mapRow[currentX].Add(previous, (previous, currentY));
                    }
                    currentY = previous;
                    break;
            }
        }

        var mapColumn = Enumerable.Range(0, MapMaximumLength).Select(p => new SortedList<int, (int Begin, int End)>()).ToArray();
        currentX = _initialX;
        currentY = _initialY;
        inst = 0;
        foreach (var instruction in RealInstructions)
        {
            inst++;
            switch (instruction.Direction)
            {
                case 'R': // r
                    mapColumn[currentY].Add(currentX, (currentX, currentX + instruction.Length));
                    currentX += instruction.Length;
                    break;

                case 'D': // d
                    for (var index = currentY; index < currentY + instruction.Length; index++)
                    {
                        if (mapColumn[index].Any(p => p.Value.Begin == currentX || p.Value.End == currentX))
                        {
                            continue;
                        }

                        mapColumn[index].Add(currentX, (currentX, currentX));
                    }

                    currentY += instruction.Length;
                    break;

                case 'L': // l
                    var previous = currentX - instruction.Length;
                    mapColumn[currentY].Add(previous, (previous, currentX));
                    currentX = previous;
                    break;

                case 'U': // u
                    for (var index = currentY; index > currentY - instruction.Length; index--)
                    {
                        if (mapColumn[index].Any(p => p.Value.Begin == currentX || p.Value.End == currentX))
                        {
                            continue;
                        }

                        mapColumn[index].Add(currentX, (currentX, currentX));
                    }
                    currentY -= instruction.Length;
                    break;
            }
        }

        var helperCoveredColumns = Enumerable.Range(0, MapMaximumLength).Select(p => new List<(int Begin, int End)>()).ToArray();
        for (var index = 0; index < mapRow.Length; index++)
        {
            var lastHole = -1;

            if (mapRow[index].Count > 0)
            {
                // process only points
                if (mapRow[index].Sum(p => p.Value.End - p.Value.Begin) == 0)
                {
                    var inside = false;
                    foreach (var block in mapRow[index])
                    {
                        if (!inside)
                        {
                            lastHole = block.Value.Begin;
                            inside = true;
                        }
                        else
                        {
                            helperCoveredColumns[index].Add((lastHole, block.Value.Begin));
                            lastHole = -1;
                            inside = false;
                        }
                    }
                }
            }
        }

        var t = helperCoveredColumns.Count(p => p.Count > 0);
        var accountedFor = new HashSet<int>();
        var coveredArea = Enumerable.Range(0, MapMaximumLength).Select(p => new List<(int Begin, int End)>()).ToArray();
        var uncoveredArea = Enumerable.Range(0, MapMaximumLength).Select(p => new List<(int Begin, int End)>()).ToArray();
        var dubious = new List<(int Y, int Begin, int End)>();
        for (var index = 0; index < mapColumn.Length; index++)
        {
            var area = 0L;
            var lastHole = -1;

            if (mapColumn[index].Count > 0)
            {
                // process only points
                if (mapColumn[index].Sum(p => p.Value.End - p.Value.Begin) == 0)
                {
                    accountedFor.Add(index);

                    var inside = false;
                    var lastEmptyStart = 0;
                    foreach (var block in mapColumn[index])
                    {
                        if (!inside)
                        {
                            lastHole = block.Value.Begin;
                            uncoveredArea[index].Add((lastEmptyStart, block.Value.Begin - 1));
                            inside = true;
                            lastEmptyStart = -1;
                        }
                        else
                        {
                            coveredArea[index].Add((lastHole, block.Value.Begin));
                            area += block.Value.Begin - lastHole + 1;
                            lastHole = -1;
                            inside = false;
                            lastEmptyStart = block.Value.Begin + 1;
                        }
                    }

                    if (lastEmptyStart != -1)
                    {
                        uncoveredArea[index].Add((lastEmptyStart, int.MaxValue));
                    }
                    else
                    {
                        System.Diagnostics.Debugger.Break();
                    }
                }
            }

            if (area != 0)
            {
                TrenchArea += area;
            }
        }

        for (var index = 0; index < mapColumn.Length; index++)
        {
            var area = 0;

            if (mapColumn[index].Count > 0)
            {
                if (accountedFor.Contains(index))
                {
                    continue;
                }

                if (mapColumn[index].Count == 1 && mapColumn[index].Values.Count == 1)
                {
                    var first = mapColumn[index].Single().Value;
                    accountedFor.Add(index);
                    coveredArea[index].Add((first.Begin, first.End));
                    area += first.End - first.Begin + 1;

                    uncoveredArea[index].Add((0, first.Begin - 1));
                    uncoveredArea[index].Add((first.End + 1, int.MaxValue));
                }

                if (area != 0)
                {
                    TrenchArea += area;
                }
            }
        }

        for (var index = 0; index < mapColumn.Length; index++)
        {
            var area = 0L;

            if (mapColumn[index].Count > 0)
            {
                if (accountedFor.Contains(index))
                {
                    continue;
                }

                accountedFor.Add(index);

                // 3134 no anda
                // 45.#iiiiiiiiiiiiiiiiii#oooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo#####oooooooooooooooooooooo#iiiiiiiii#ooooo#iiiiiii#.
                var inside = true;
                for (var subIndex = 0; subIndex < mapColumn[index].Count - 1; subIndex++)
                {
                    var first = mapColumn[index].ElementAt(subIndex);
                    var second = mapColumn[index].ElementAt(subIndex + 1);

                    if (inside)
                    {
                        coveredArea[index].Add((first.Value.Begin, first.Value.End));
                        area += first.Value.End - first.Value.Begin + 1;

                        coveredArea[index].Add((first.Value.End, second.Value.Begin));
                        area += second.Value.Begin - first.Value.End - 1;

                        coveredArea[index].Add((second.Value.Begin, second.Value.End));
                        area += second.Value.End - second.Value.Begin + 1;
                        inside = false;
                    }
                    else
                    {
                        dubious.Add((index, first.Value.End, second.Value.Begin));
                        inside = true;
                    }
                }

                if (inside)
                {
                    var last = mapColumn[index].Last();
                    if (last.Value.Begin != last.Value.End)
                    {
                        coveredArea[index].Add((last.Value.Begin, last.Value.End));
                        area += last.Value.End - last.Value.Begin + 1;
                    }
                }
            }

/*
            if (inside)
            {
                if (lineLastPoint != -1)
                {
                    coveredArea[index].Add((lineLastPoint, lastHole));
                    area += lastHole - lineLastPoint;
                    lineLastPoint = -1;
                }
            }*/

            if (area != 0)
            {
                TrenchArea += area;
            }
        }




        var extraArea = 0;
        foreach (var range in dubious)
        {
            var exists = false;
            if (coveredArea[range.Y - 1].Any(p => p.Begin <= range.Begin && p.End >= range.End))
            {
                exists = true;
            }
            else if (coveredArea[range.Y + 1].Any(p => p.Begin <= range.Begin && p.End >= range.End))
            {
                exists = true;
            }

            if (exists)
            {
                extraArea += range.End - range.Begin - 1;
                coveredArea[range.Y].Add((range.Begin, range.End));
            }
        }

        TrenchArea += extraArea;


/*
        var coveredArea = Enumerable.Range(0, MapMaximumLength).Select(p => new List<(int Begin, int End)>()).ToArray();
        var dubious = new List<(int Y, int Begin, int End)>();
        for (var index = 0; index < array.Length; index++)
        {
            var area = 0L;
            var inside = false;
            var lastHole = -1;
            var lineLastPoint = -1;
            var nextDubious = false;

            foreach (var block in array[index])
            {
                if (nextDubious)
                {
                    dubious.Add((index, lineLastPoint, block.Value.Begin));
                    nextDubious = false;
                    lineLastPoint = -1;
                }

                if (block.Value.Begin != block.Value.End)
                {
                    if (inside)
                    {
                        coveredArea[index].Add((lastHole, block.Value.Begin));
                        area += block.Value.Begin - lastHole;
                        lastHole = block.Value.End;
                        inside = false;
                        nextDubious = true;
                    }

                    coveredArea[index].Add((block.Value.Begin, block.Value.End));
                    area += block.Value.End - block.Value.Begin + 1;

                    if (lineLastPoint != -1)
                    {
                        dubious.Add((index, lineLastPoint, block.Value.Begin));
                    }
                    lineLastPoint = block.Value.End;
                }
                else
                {
                    if (!inside)
                    {
                        if (lineLastPoint != -1)
                        {
                            dubious.Add((index, lineLastPoint, block.Value.Begin));
                            lineLastPoint = -1;
                            coveredArea[index].Add((block.Value.Begin, block.Value.End));
                            area += 1;
                        }
                        else
                        {
                            lastHole = block.Value.Begin;
                            inside = true;
                        }
                    }
                    else
                    {
                        coveredArea[index].Add((lastHole, block.Value.Begin));
                        area += block.Value.Begin - lastHole + 1;
                        lastHole = -1;
                        inside = false;
                    }
                }
            }
//*
            if (inside)
            {
                if (lineLastPoint != -1)
                {
                    coveredArea[index].Add((lineLastPoint, lastHole));
                    area += lastHole - lineLastPoint;
                    lineLastPoint = -1;
                }
            }//

            if (area != 0)
            {
                TrenchArea += area;
            }
        }

        var extraArea = 0;
        foreach (var range in dubious)
        {
            var exists = false;
            if (coveredArea[range.Y - 1].Any(p => p.Begin <= range.Begin && p.End >= range.End))
            {
                exists = true;
            }
            else if (coveredArea[range.Y + 1].Any(p => p.Begin <= range.Begin && p.End >= range.End))
            {
                exists = true;
            }

            if (exists)
            {
                extraArea += range.End - range.Begin - 1;
                coveredArea[range.Y].Add((range.Begin, range.End));
            }
        }

        TrenchArea += extraArea;
*/

/*
        for (var index = 0; index < array.Length; index++)
        {
            var area = 0L;
            var inside = false;
            var lastHole = -1L;
            var lineLastPoint = -1;

            foreach (var block in array[index])
            {
                if (block.Value.Begin != block.Value.End)
                {
                    if (inside)
                    {
                        if (lastHole == -1)
                        {
                            System.Diagnostics.Debugger.Break();
                        }
                        area += block.Value.Begin - lastHole + 1;
                        lastHole = block.Value.End;
                    }

                    area += block.Value.End - block.Value.Begin + 1;
                    lineLastPoint = block.Value.End;
                }
                else
                {
                    if (block.Value.Begin == lineLastPoint)
                    {
                        continue;
                    }

                    if (!inside)
                    {
                        lastHole = block.Value.Begin;
                        inside = true;
                    }
                    else
                    {
                        if (lastHole == -1)
                        {
                            System.Diagnostics.Debugger.Break();
                        }
                        area += block.Value.Begin - lastHole + 1;
                        lastHole = -1;
                        inside = false;
                    }
                }
            }

            if (inside)
            {
                if (lineLastPoint == -1)
                {
                    System.Diagnostics.Debugger.Break();
                }
                area += lastHole - lineLastPoint;
            }

            TrenchArea += area;
        }
*/
    }
}


public class LavaductLagoon2
{
    private readonly string _input;
    private readonly string[] _lines;
    private readonly char[][] _map;
    private readonly int _length;

    public int DigPlanLength => _lines.Length;

    public int TrenchPerimeter { get; private set; }
    public long TrenchArea { get; private set; }
    public List<(char Direction, int Amount)> RealInstructions { get; }

    public LavaductLagoon2(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
        RealInstructions = new List<(char, int)>();
    }

    public void Decode()
    {
        var facing = 'U';
        foreach (var line in _lines)
        {
            var command = line.Split(" ");
            var hex = command[2][1..^1];
            switch (facing)
            {
                case 'U':
                    switch (hex[^1])
                    {
                        case 'R':
                            RealInstructions.Add(('R', -1));
                            RealInstructions.Add(('F', Convert.ToInt32(hex[1..^1], 16)));
                            facing = 'R';
                            break;

                        case 'L':
                            RealInstructions.Add(('L', -1));
                            RealInstructions.Add(('F', Convert.ToInt32(hex[1..^1], 16)));
                            facing = 'L';
                            break;

                        default:
                            throw new Exception();
                    }
                    break;

                case 'R':
                    switch (hex[^1])
                    {
                        case 'U':
                            RealInstructions.Add(('L', -1));
                            RealInstructions.Add(('F', Convert.ToInt32(hex[1..^1], 16)));
                            facing = 'U';
                            break;

                        case 'D':
                            RealInstructions.Add(('R', -1));
                            RealInstructions.Add(('F', Convert.ToInt32(hex[1..^1], 16)));
                            facing = 'D';
                            break;

                        default:
                            throw new Exception();
                    }
                    break;

                case 'D':
                    switch (hex[^1])
                    {
                        case 'L':
                            RealInstructions.Add(('R', -1));
                            RealInstructions.Add(('F', Convert.ToInt32(hex[1..^1], 16)));
                            facing = 'L';
                            break;

                        case 'R':
                            RealInstructions.Add(('L', -1));
                            RealInstructions.Add(('F', Convert.ToInt32(hex[1..^1], 16)));
                            facing = 'R';
                            break;

                        default:
                            throw new Exception();
                    }
                    break;

                case 'L':
                    switch (hex[^1])
                    {
                        case 'U':
                            RealInstructions.Add(('R', -1));
                            RealInstructions.Add(('F', Convert.ToInt32(hex[1..^1], 16)));
                            facing = 'U';
                            break;

                        case 'D':
                            RealInstructions.Add(('L', -1));
                            RealInstructions.Add(('F', Convert.ToInt32(hex[1..^1], 16)));
                            facing = 'L';
                            break;
                    }
                    break;
            }

            var length = Convert.ToInt32(hex[1..^1], 16);
        }
    }
}