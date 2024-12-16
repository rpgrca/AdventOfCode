
namespace Day16.Logic;

public class ReindeerMaze
{
    private string _input;
    private string[] _lines;

    public int Size => _lines.Length;

    public ReindeerMaze(string input)
    {
        _input = input;
        _lines = _input.Split('\n');
    }
}