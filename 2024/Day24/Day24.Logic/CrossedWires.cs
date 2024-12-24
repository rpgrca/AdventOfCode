
namespace Day24.Logic;

public class CrossedWires
{
    private string _input;
    private string[] _wires;
    private string[] _gates;

    public int GatesCount => _gates.Length;
    public int WiresCount => _wires.Length;

    public CrossedWires(string input)
    {
        _input = input;
        var sections = _input.Split("\n\n");
        _wires = sections[0].Split('\n');
        _gates = sections[1].Split('\n');
    }

}
