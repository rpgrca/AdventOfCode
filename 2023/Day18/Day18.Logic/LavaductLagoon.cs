using System.Collections;
using System.Data;
using System.Runtime.ExceptionServices;

namespace Day18.Logic;

public class LavaductLagoon
{
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
        var array = Enumerable.Range(0, 5_000_000).Select(p => new SortedList<int, (int Begin, int End)>()).ToArray();
        var currentX = _initialX;
        var currentY = _initialY;

        foreach (var instruction in RealInstructions)
        {
            switch (instruction.Direction)
            {
                case 'R': // r
                    array[currentY].Add(currentX, (currentX, currentX + instruction.Length));
                    currentX += instruction.Length;
                    break;

                case 'D': // d
                    for (var index = currentY; index < currentY + instruction.Length; index++)
                    {
                        if (array[index].Any(p => p.Value.Begin == currentX || p.Value.End == currentX))
                        {
                            continue;
                        }

                        //if (!array[index].ContainsKey(currentX))
                        //{
                            array[index].Add(currentX, (currentX, currentX));
                        //}
                        //else
                        //{
                        //    System.Diagnostics.Debugger.Break();
                       // }
                    }
                    currentY += instruction.Length;
                    break;

                case 'L': // l
                    var previous = currentX - instruction.Length;
                    array[currentY].Add(previous, (previous, currentX));
                    currentX = previous;
                    break;

                case 'U': // u
                    for (var index = currentY; index > currentY - instruction.Length; index--)
                    {
                        if (array[index].Any(p => p.Value.Begin == currentX || p.Value.End == currentX))
                        {
                            continue;
                        }

                        array[index].Add(currentX, (currentX, currentX));
                        /*
                        if (!array[index].ContainsKey(currentX))
                        {
                            array[index].Add(currentX, (currentX, currentX));
                        }
                        else
                        {
                            System.Diagnostics.Debugger.Break();
                        }*/
                    }
                    currentY -= instruction.Length;
                    break;
            }
        }

        var accountedFor = new HashSet<int>();
        var coveredArea = Enumerable.Range(0, 5_000_000).Select(p => new List<(int Begin, int End)>()).ToArray();
        var dubious = new List<(int Y, int Begin, int End)>();
        for (var index = 0; index < array.Length; index++)
        {
            var area = 0L;
            var lastHole = -1;

            if (array[index].Count > 0)
            {
                // process only points
                if (array[index].Sum(p => p.Value.End - p.Value.Begin) == 0)
                {
                    accountedFor.Add(index);

                    var inside = false;
                    foreach (var block in array[index])
                    {
                        if (!inside)
                        {
                            lastHole = block.Value.Begin;
                            inside = true;
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
            }

            if (area != 0)
            {
                TrenchArea += area;
            }
        }


        for (var index = 0; index < array.Length; index++)
        {
            var area = 0;

            if (array[index].Count > 0)
            {
                if (accountedFor.Contains(index))
                {
                    continue;
                }

                if (array[index].Count == 1 && array[index].Values.Count == 1)
                {
                    var first = array[index].Single().Value;
                    accountedFor.Add(index);
                    coveredArea[index].Add((first.Begin, first.End));
                    area += first.End - first.Begin + 1;
                }

                if (area != 0)
                {
                    TrenchArea += area;
                }
            }
        }

        for (var index = 0; index < array.Length; index++)
        {
            var area = 0L;

            if (array[index].Count > 0)
            {
                if (accountedFor.Contains(index))
                {
                    continue;
                }

                accountedFor.Add(index);

                var inside = true;
                for (var subIndex = 0; subIndex < array[index].Count - 1; subIndex +=2)
                {
                    var first = array[index].ElementAt(subIndex);
                    var second = array[index].ElementAt(subIndex + 1);

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
        var coveredArea = Enumerable.Range(0, 5_000_000).Select(p => new List<(int Begin, int End)>()).ToArray();
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
