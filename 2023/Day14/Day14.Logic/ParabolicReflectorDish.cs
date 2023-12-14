


namespace Day14.Logic;

public class ParabolicReflectorDish
{
    private readonly string _input;
    private readonly string[] _lines;

    public int Height { get; private set; }
    public int Width { get; private set; }
    public List<List<char>> CurrentMap { get; private set; }

    public ParabolicReflectorDish(string input)
    {
        _input = input;
        _lines = input.Split("\n");

        Height = _lines.Length;
        Width = _lines[0].Length;
        CurrentMap = new List<List<char>>();

        foreach (var line in _lines)
        {
            CurrentMap.Add(line.Select(c => c).ToList());
        }
    }

    public void TiltNorth()
    {
    }
}
