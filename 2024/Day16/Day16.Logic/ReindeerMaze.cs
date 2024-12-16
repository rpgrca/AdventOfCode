


namespace Day16.Logic;

public class ReindeerMaze
{
    private string _input;
    private string[] _lines;

    public int Size => _lines.Length;

    public (int X, int Y) StartPoint { get; private set; }
    public (int X, int Y) EndPoint { get; private set; }

    public ReindeerMaze(string input)
    {
        _input = input;
        _lines = _input.Split('\n');

        for (var y = 0; y < Size; y++)
        {
            for (var x = 0; x < Size; x++)
            {
                if (_lines[y][x] == 'S')
                {
                    StartPoint = (x, y);
                }
                else if (_lines[y][x] == 'E')
                {
                    EndPoint = (x, y);
                }
            }
        }
    }
}