

namespace Day20.Logic;

public class RaceCondition
{
    private readonly string _input;
    private readonly string[] _lines;
    private char[,] _map;

    public int Size => _lines.Length;

    public (int X, int Y) Start { get; set; }
    public (int X, int Y) End { get; set; }

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
}
