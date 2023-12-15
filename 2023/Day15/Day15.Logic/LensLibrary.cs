
namespace Day15.Logic;
public class LensLibrary
{
    private readonly string _input;
    private readonly string[] _sequence;

    public LensLibrary(string input)
    {
        _input = input;
        _sequence = _input.Split(",");
    }

    public int SequenceCount => _sequence.Length;
}
