

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
    }

    public int W => _lines[0].Length;
    public int H => _lines.Length;

    public int X { get; set; }
    public int Y { get; set; }
}
