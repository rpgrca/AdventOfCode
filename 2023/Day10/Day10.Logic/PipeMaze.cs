
using System.Data;

namespace Day10.Logic;

public class PipeMaze
{
    private readonly string _input;
    private readonly string[] _lines;

    public PipeMaze(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        for (var y = 0; y < H; y++)
        {

            for (var x = 0; x < W; x++)
            {
                if (_lines[y][x] == 'S')
                {
                    X = x;
                    Y = y;
                    goto Found;
                }
            }
        }

        Found:;
        var p = new List<char>();

        if (X - 1 >= 0)
        {
            if (X + 1 < W)  // w & e
            {
                var d = new Dictionary<(char, char), char>
                {
                    { ('F', 'F'), 'x' },
                    { ('F', 'J'), '-' },
                    { ('F', 'L'), 'x' },
                    { ('F', '7'), '-' },
                    { ('F', '-'), '-' },
                    { ('F', '|'), 'x' },
                    { ('F', '.'), 'x' },
                    { ('J', 'F'), 'x' },
                    { ('J', 'J'), 'x' },
                    { ('J', 'L'), 'x' },
                    { ('J', '7'), 'x' },
                    { ('J', '-'), 'x' },
                    { ('J', '|'), 'x' },
                    { ('J', '.'), 'x' },
                    { ('L', 'F'), 'x' },
                    { ('L', 'J'), '-' },
                    { ('L', 'L'), 'x' },
                    { ('L', '7'), '-' },
                    { ('L', '-'), '-' },
                    { ('L', '|'), 'x' },
                    { ('L', '.'), 'x' },
                    { ('7', 'F'), 'x' },
                    { ('7', 'J'), 'x' },
                    { ('7', 'L'), 'x' },
                    { ('7', '7'), 'x' },
                    { ('7', '-'), 'x' },
                    { ('7', '|'), 'x' },
                    { ('7', '.'), 'x' },
                    { ('-', 'F'), 'x' },
                    { ('-', 'J'), '-' },
                    { ('-', 'L'), 'x' },
                    { ('-', '7'), '-' },
                    { ('-', '-'), '-' },
                    { ('-', '|'), 'x' },
                    { ('-', '.'), 'x' },
                    { ('|', 'F'), 'x' },
                    { ('|', 'J'), 'x' },
                    { ('|', 'L'), 'x' },
                    { ('|', '7'), 'x' },
                    { ('|', '-'), 'x' },
                    { ('|', '|'), 'x' },
                    { ('|', '.'), 'x' },
                    { ('.', 'F'), 'x' },
                    { ('.', 'J'), 'x' },
                    { ('.', 'L'), 'x' },
                    { ('.', '7'), 'x' },
                    { ('.', '-'), 'x' },
                    { ('.', '|'), 'x' },
                    { ('.', '.'), 'x' }
                };

                if (d.ContainsKey((_lines[Y][X-1], _lines[Y][X+1])))
                {
                    var x = d[(_lines[Y][X-1], _lines[Y][X+1])];
                    if (x != 'x')
                    {
                        p.Add(x);
                    }
                }
            }

            if (Y - 1 >= 0) // w & n
            {
                var d = new Dictionary<(char, char), char>
                {
                    { ('F', 'F'), 'J' },
                    { ('F', 'J'), 'x' },
                    { ('F', 'L'), 'x' },
                    { ('F', '7'), 'J' },
                    { ('F', '-'), 'x' },
                    { ('F', '|'), 'J' },
                    { ('F', '.'), 'x' },
                    { ('J', 'F'), 'x' },
                    { ('J', 'J'), 'x' },
                    { ('J', 'L'), 'x' },
                    { ('J', '7'), 'x' },
                    { ('J', '-'), 'x' },
                    { ('J', '|'), 'x' },
                    { ('J', '.'), 'x' },
                    { ('L', 'F'), 'J' },
                    { ('L', 'J'), 'x' },
                    { ('L', 'L'), 'x' },
                    { ('L', '7'), 'J' },
                    { ('L', '-'), 'x' },
                    { ('L', '|'), 'J' },
                    { ('L', '.'), 'x' },
                    { ('7', 'F'), 'x' },
                    { ('7', 'J'), 'x' },
                    { ('7', 'L'), 'x' },
                    { ('7', '7'), 'x' },
                    { ('7', '-'), 'x' },
                    { ('7', '|'), 'x' },
                    { ('7', '.'), 'x' },
                    { ('-', 'F'), 'J' },
                    { ('-', 'J'), 'x' },
                    { ('-', 'L'), 'x' },
                    { ('-', '7'), 'J' },
                    { ('-', '-'), 'x' },
                    { ('-', '|'), 'J' },
                    { ('-', '.'), 'x' },
                    { ('|', 'F'), 'x' },
                    { ('|', 'J'), 'x' },
                    { ('|', 'L'), 'x' },
                    { ('|', '7'), 'x' },
                    { ('|', '-'), 'x' },
                    { ('|', '|'), 'x' },
                    { ('|', '.'), 'x' },
                    { ('.', 'F'), 'x' },
                    { ('.', 'J'), 'x' },
                    { ('.', 'L'), 'x' },
                    { ('.', '7'), 'x' },
                    { ('.', '-'), 'x' },
                    { ('.', '|'), 'x' },
                    { ('.', '.'), 'x' }
                };

                if (d.ContainsKey((_lines[Y][X-1], _lines[Y-1][X])))
                {
                    char item = d[(_lines[Y][X - 1], _lines[Y - 1][X])];
                    if (item != 'x')
                    {
                        p.Add(item);
                    }
                }
            }

            if (Y + 1 < H)  // w & s
            {
                var d = new Dictionary<(char, char), char>
                {
                    { ('F', 'F'), 'x' },
                    { ('F', 'J'), '7' },
                    { ('F', 'L'), '7' },
                    { ('F', '7'), 'x' },
                    { ('F', '-'), 'x' },
                    { ('F', '|'), '7' },
                    { ('F', '.'), 'x' },
                    { ('J', 'F'), 'x' },
                    { ('J', 'J'), 'x' },
                    { ('J', 'L'), 'x' },
                    { ('J', '7'), 'x' },
                    { ('J', '-'), 'x' },
                    { ('J', '|'), 'x' },
                    { ('J', '.'), 'x' },
                    { ('L', 'F'), 'x' },
                    { ('L', 'J'), '7' },
                    { ('L', 'L'), '7' },
                    { ('L', '7'), 'x' },
                    { ('L', '-'), 'x' },
                    { ('L', '|'), '7' },
                    { ('L', '.'), 'x' },
                    { ('7', 'F'), 'x' },
                    { ('7', 'J'), 'x' },
                    { ('7', 'L'), 'x' },
                    { ('7', '7'), 'x' },
                    { ('7', '-'), 'x' },
                    { ('7', '|'), 'x' },
                    { ('7', '.'), 'x' },
                    { ('-', 'F'), 'x' },
                    { ('-', 'J'), '7' },
                    { ('-', 'L'), '7' },
                    { ('-', '7'), 'x' },
                    { ('-', '-'), 'x' },
                    { ('-', '|'), '7' },
                    { ('-', '.'), 'x' },
                    { ('|', 'F'), 'x' },
                    { ('|', 'J'), 'x' },
                    { ('|', 'L'), 'x' },
                    { ('|', '7'), 'x' },
                    { ('|', '-'), 'x' },
                    { ('|', '|'), 'x' },
                    { ('|', '.'), 'x' },
                    { ('.', 'F'), 'x' },
                    { ('.', 'J'), 'x' },
                    { ('.', 'L'), 'x' },
                    { ('.', '7'), 'x' },
                    { ('.', '-'), 'x' },
                    { ('.', '|'), 'x' },
                    { ('.', '.'), 'x' }
                };

                if (d.ContainsKey((_lines[Y][X-1], _lines[Y+1][X])))
                {
                    char item = d[(_lines[Y][X - 1], _lines[Y + 1][X])];
                    if (item != 'x')
                    {
                        p.Add(item);
                    }
                }
            }
        }

        if (X + 1 < W)
        {
            if (Y - 1 >= 0) // e & n
            {
                var d = new Dictionary<(char, char), char>
                {
                    { ('F', 'F'), 'x' },
                    { ('F', 'J'), 'x' },
                    { ('F', 'L'), 'x' },
                    { ('F', '7'), 'x' },
                    { ('F', '-'), 'x' },
                    { ('F', '|'), 'x' },
                    { ('F', '.'), 'x' },
                    { ('J', 'F'), 'L' },
                    { ('J', 'J'), 'x' },
                    { ('J', 'L'), 'x' },
                    { ('J', '7'), 'L' },
                    { ('J', '-'), 'x' },
                    { ('J', '|'), 'L' },
                    { ('J', '.'), 'x' },
                    { ('L', 'F'), 'x' },
                    { ('L', 'J'), 'x' },
                    { ('L', 'L'), 'x' },
                    { ('L', '7'), 'x' },
                    { ('L', '-'), 'x' },
                    { ('L', '|'), 'x' },
                    { ('L', '.'), 'x' },
                    { ('7', 'F'), 'L' },
                    { ('7', 'J'), 'x' },
                    { ('7', 'L'), 'x' },
                    { ('7', '7'), 'L' },
                    { ('7', '-'), 'x' },
                    { ('7', '|'), 'L' },
                    { ('7', '.'), 'x' },
                    { ('-', 'F'), 'L' },
                    { ('-', 'J'), 'x' },
                    { ('-', 'L'), 'x' },
                    { ('-', '7'), 'L' },
                    { ('-', '-'), 'x' },
                    { ('-', '|'), 'L' },
                    { ('-', '.'), 'x' },
                    { ('|', 'F'), 'x' },
                    { ('|', 'J'), 'x' },
                    { ('|', 'L'), 'x' },
                    { ('|', '7'), 'x' },
                    { ('|', '-'), 'x' },
                    { ('|', '|'), 'x' },
                    { ('|', '.'), 'x' },
                    { ('.', 'F'), 'x' },
                    { ('.', 'J'), 'x' },
                    { ('.', 'L'), 'x' },
                    { ('.', '7'), 'x' },
                    { ('.', '-'), 'x' },
                    { ('.', '|'), 'x' },
                    { ('.', '.'), 'x' }
                };

                if (d.ContainsKey((_lines[Y][X+1], _lines[Y-1][X])))
                {
                    char item = d[(_lines[Y][X+1], _lines[Y-1][X])];
                    if (item != 'x')
                    {
                        p.Add(item);
                    }
                }
            }

            if (Y + 1 < H)  // e & s
            {
                var d = new Dictionary<(char, char), char>
                {
                    { ('F', 'F'), 'x' },
                    { ('F', 'J'), 'x' },
                    { ('F', 'L'), 'x' },
                    { ('F', '7'), 'x' },
                    { ('F', '-'), 'x' },
                    { ('F', '|'), 'x' },
                    { ('F', '.'), 'x' },
                    { ('J', 'F'), 'x' },
                    { ('J', 'J'), 'F' },
                    { ('J', 'L'), 'F' },
                    { ('J', '7'), 'x' },
                    { ('J', '-'), 'x' },
                    { ('J', '|'), 'F' },
                    { ('J', '.'), 'x' },
                    { ('L', 'F'), 'x' },
                    { ('L', 'J'), 'x' },
                    { ('L', 'L'), 'x' },
                    { ('L', '7'), 'x' },
                    { ('L', '-'), 'x' },
                    { ('L', '|'), 'x' },
                    { ('L', '.'), 'x' },
                    { ('7', 'F'), 'x' },
                    { ('7', 'J'), 'F' },
                    { ('7', 'L'), 'F' },
                    { ('7', '7'), 'x' },
                    { ('7', '-'), 'x' },
                    { ('7', '|'), 'F' },
                    { ('7', '.'), 'x' },
                    { ('-', 'F'), 'x' },
                    { ('-', 'J'), 'F' },
                    { ('-', 'L'), 'F' },
                    { ('-', '7'), 'x' },
                    { ('-', '-'), 'x' },
                    { ('-', '|'), 'F' },
                    { ('-', '.'), 'x' },
                    { ('|', 'F'), 'x' },
                    { ('|', 'J'), 'x' },
                    { ('|', 'L'), 'x' },
                    { ('|', '7'), 'x' },
                    { ('|', '-'), 'x' },
                    { ('|', '|'), 'x' },
                    { ('|', '.'), 'x' },
                    { ('.', 'F'), 'x' },
                    { ('.', 'J'), 'x' },
                    { ('.', 'L'), 'x' },
                    { ('.', '7'), 'x' },
                    { ('.', '-'), 'x' },
                    { ('.', '|'), 'x' },
                    { ('.', '.'), 'x' }
                };

                if (d.ContainsKey((_lines[Y][X+1], _lines[Y+1][X])))
                {
                    char item = d[(_lines[Y][X + 1], _lines[Y + 1][X])];
                    if (item != 'x')
                    {
                        p.Add(item);
                    }
                }
            }
        }

        if (Y - 1 >= 0 && Y + 1 < H) // n & s
        {
            var d = new Dictionary<(char, char), char>
            {
                { ('F', 'F'), 'x' },
                { ('F', 'J'), '|' },
                { ('F', 'L'), '|' },
                { ('F', '7'), 'x' },
                { ('F', '-'), 'x' },
                { ('F', '|'), '|' },
                { ('F', '.'), 'x' },
                { ('J', 'F'), 'x' },
                { ('J', 'J'), 'x' },
                { ('J', 'L'), 'x' },
                { ('J', '7'), 'x' },
                { ('J', '-'), 'x' },
                { ('J', '|'), 'x' },
                { ('J', '.'), 'x' },
                { ('L', 'F'), 'x' },
                { ('L', 'J'), 'x' },
                { ('L', 'L'), 'x' },
                { ('L', '7'), 'x' },
                { ('L', '-'), 'x' },
                { ('L', '|'), 'x' },
                { ('L', '.'), 'x' },
                { ('7', 'F'), 'x' },
                { ('7', 'J'), '|' },
                { ('7', 'L'), '|' },
                { ('7', '7'), 'x' },
                { ('7', '-'), 'x' },
                { ('7', '|'), '|' },
                { ('7', '.'), 'x' },
                { ('-', 'F'), 'x' },
                { ('-', 'J'), 'x' },
                { ('-', 'L'), 'x' },
                { ('-', '7'), 'x' },
                { ('-', '-'), 'x' },
                { ('-', '|'), 'x' },
                { ('-', '.'), 'x' },
                { ('|', 'F'), 'x' },
                { ('|', 'J'), '|' },
                { ('|', 'L'), '|' },
                { ('|', '7'), 'x' },
                { ('|', '-'), 'x' },
                { ('|', '|'), '|' },
                { ('|', '.'), 'x' },
                { ('.', 'F'), 'x' },
                { ('.', 'J'), 'x' },
                { ('.', 'L'), 'x' },
                { ('.', '7'), 'x' },
                { ('.', '-'), 'x' },
                { ('.', '|'), 'x' },
                { ('.', '.'), 'x' }
            };

            if (d.ContainsKey((_lines[Y-1][X], _lines[Y+1][X])))
            {
                char item = d[(_lines[Y - 1][X], _lines[Y + 1][X])];
                if (item != 'x')
                {
                    p.Add(item);
                }
            }
        }

        StartingPipe = p.Single();

        var steps = 0;
        switch (StartingPipe)
        {
            case 'F': steps = Check('E', (X+1, Y), 1); break;
            case 'L': steps = Check('E', (X+1, Y), 1); break;
        }

        FarthestDistance = steps / 2;

        var expandedMap = new List<List<char>>();
        foreach (var line in _lines)
        {
            var currentLine = new List<char>();
            var newLine = new List<char>();
            foreach (var tile1 in line)
            {
                var tile = tile1;
                if (tile == 'S')
                {
                    tile = StartingPipe;
                }
                currentLine.Add(tile);
                currentLine.Add(tile switch {
                    'F' or 'L' or '-' => '-',
                    _ => 'o'
                });

                newLine.Add(tile switch {
                    'F' or '7' or '|' => '|',
                    _ => 'o'
                });
                newLine.Add('o');
            }

            expandedMap.Add(currentLine);
            expandedMap.Add(newLine);
        }

        FillOutsideTiles(expandedMap, 0, 0);

        OutsideTiles = 0;
        foreach (var line in expandedMap)
        {
            foreach (var tile in line)
            {
                if (tile == 'O')
                {
                    OutsideTiles++;
                }

                if (tile == '.')
                {
                    InsideTiles++;
                }
            }
        }
    }

    private void FillOutsideTiles(List<List<char>> expandedMap, int x, int y)
    {
        if (x < 0 || x >= W * 2 || y < 0 || y >= H * 2 || expandedMap[y][x] == 'O' || expandedMap[y][x] == 'X')
        {
            return;
        }

        if (expandedMap[y][x] == '.' || expandedMap[y][x] == 'o')
        {
            if (expandedMap[y][x] == '.')
            {
                expandedMap[y][x] = 'O';
            }

            if (expandedMap[y][x] == 'o')
            {
                expandedMap[y][x] = 'X';
            }

            FillOutsideTiles(expandedMap, x-1, y);
            FillOutsideTiles(expandedMap, x+1, y);
            FillOutsideTiles(expandedMap, x, y-1);
            FillOutsideTiles(expandedMap, x, y+1);
        }
    }

    private int Check(char from1, (int X, int Y) value1, int count)
    {
        if (value1.X == X && value1.Y == Y)
        {
            return count + 1;
        }

        switch (_lines[value1.Y][value1.X])
        {
            case 'F':
                if (from1 == 'N')
                {
                    return Check('E', (value1.X + 1, value1.Y), count+1);
                }
                else
                {
                    return Check('S', (value1.X, value1.Y+1), count+1);
                }
                break;

            case 'J':
                if (from1 == 'S')
                {
                    return Check('W', (value1.X-1, value1.Y), count+1);
                }
                else
                {
                    return Check('N', (value1.X, value1.Y-1), count+1);
                }
                break;

            case 'L':
                if (from1 == 'S')
                {
                    return Check('E', (value1.X+1, value1.Y), count+1);
                }
                else
                {
                    return Check('N', (value1.X, value1.Y-1), count+1);
                }
                break;

            case '7':
                if (from1 == 'N')
                {
                    return Check('W', (value1.X-1, value1.Y), count+1);
                }
                else
                {
                    return Check('S', (value1.X, value1.Y+1), count+1);
                }
                break;

            case '-':
                if (from1 == 'E')
                {
                    return Check('E', (value1.X+1, value1.Y), count+1);
                }
                else
                {
                    return Check('W', (value1.X-1, value1.Y), count+1);
                }
                break;

            case '|':
                if (from1 == 'N')
                {
                    return Check('N', (value1.X, value1.Y-1), count+1);
                }
                else
                {
                    return Check('S', (value1.X, value1.Y+1), count+1);
                }
                break;

            default:
                throw new Exception("Invalid state");
        }
    }

    public int W => _lines[0].Length;

    public int H => _lines.Length;

    public int X { get; set; }
    public int Y { get; set; }
    public char StartingPipe { get; set; }
    public int FarthestDistance { get; set; }
    public int OutsideTiles { get; set; }
    public int InsideTiles { get; set; }
}
