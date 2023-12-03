
namespace Day3.Logic;

public class EngineSchematic
{
    private string _input;
    private readonly string[] _schematic;

    public int Width => _schematic.Length;
    public int Height => _schematic.Length;

    public EngineSchematic(string input)
    {
        _input = input;
        _schematic = _input.Split("\n");
    }

}
