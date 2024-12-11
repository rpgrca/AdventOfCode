

namespace Day11.Logic;

public class PlutonianPebbles
{
    private readonly string _input;
    private readonly List<long> _line;
    private readonly List<long> _pebbles;

    public int Count => _line.Count;

    public List<long> Pebbles => _pebbles;

    public PlutonianPebbles(string input)
    {
        _input = input;
        _line = _input.Split(' ').Select(long.Parse).ToList();
        _pebbles = new();
    }

    public void Blink()
    {
        _pebbles.Add(1);
    }
}
