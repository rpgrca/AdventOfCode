
namespace Day8.Logic;

public class AntinodeMap
{
    private readonly string _input;
    private readonly string[] _map;

    public AntinodeMap(string input)
    {
        _input = input;
        _map = _input.Split('\n');
    }

    public int Size => _map.Length;
}
