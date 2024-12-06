
namespace Day6.Logic;

public class GuardPatrolProtocol
{
    private readonly string _input;
    private readonly string[] _map;

    public GuardPatrolProtocol(string input)
    {
        _input = input;
        _map = _input.Split('\n');
    }

    public int Length => _map.Length;
}