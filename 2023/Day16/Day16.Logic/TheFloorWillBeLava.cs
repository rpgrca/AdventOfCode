
namespace Day16.Logic;
public class TheFloorWillBeLava
{
    private readonly string _input;
    private readonly string[] _lines;

    public int Width => _lines[0].Length;
    public int Height => _lines.Length;

    public TheFloorWillBeLava(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
    }

}
