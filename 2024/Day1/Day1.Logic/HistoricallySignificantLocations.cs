
namespace Day1.Logic;

public class HistoricallySignificantLocations
{
    private string[] _input;

    public HistoricallySignificantLocations(string input)
    {
        _input = input.Split("\n");
        Length = _input.Length;
    }

    public int Length { get; private set; }
}
