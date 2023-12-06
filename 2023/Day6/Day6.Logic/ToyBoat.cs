
namespace Day6.Logic;
public class ToyBoat
{
    private readonly string _input;

    public int RaceCount { get; private set; } = 3;

    public ToyBoat(string input)
    {
        _input = input;
    }
}
