
namespace Day15.Logic;
public class LensLibrary
{
    private readonly string _input;

    public LensLibrary(string input)
    {
        _input = input;
    }

    public int SequenceCount { get; private set; } = 11;
}
