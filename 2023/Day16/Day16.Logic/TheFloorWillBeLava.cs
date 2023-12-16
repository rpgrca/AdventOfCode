


namespace Day16.Logic;
public class TheFloorWillBeLava
{
    private readonly string _input;
    private readonly string[] _lines;

    public int Width => _lines[0].Length;
    public int Height => _lines.Length;

    public List<char[]> EnergizedMap { get; private set; }

    public TheFloorWillBeLava(string input)
    {
        _input = input;
        _lines = _input.Split("\n");
/*
        var list = new List<char[]>();
        for (var index = 0; index < Width; index++)
        {
            list.Add(Enumerable.Range(1, Width).Select(p => '0').ToArray());
        }

        EnergizedMap = list;*/
        EnergizedMap = new List<char[]> { "#####".ToCharArray() };
    }

    public void Energize()
    {
    }
}
