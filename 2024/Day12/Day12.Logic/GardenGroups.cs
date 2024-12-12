
namespace Day12.Logic;

public class GardenGroups
{
    private string _input;
    private readonly string[] _lines;

    public GardenGroups(string input)
    {
        _input = input;
        _lines = input.Split('\n');
    }

    public int Size => _lines.Length;
}