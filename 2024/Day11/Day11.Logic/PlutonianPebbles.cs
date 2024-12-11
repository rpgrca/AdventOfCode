namespace Day11.Logic;

public class PlutonianPebbles
{
    private readonly string _input;
    private List<long> _line;

    public int Count => _line.Count;

    public PlutonianPebbles(string input)
    {
        _input = input;
        _line = _input.Split(' ').Select(long.Parse).ToList();
    }
}
