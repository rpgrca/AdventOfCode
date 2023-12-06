

namespace Day6.Logic;
public class ToyBoat
{
    private readonly string _input;
    private int[] _times;
    private int[] _distances;

    public int RaceCount => _times.Length;

    public ToyBoat(string input)
    {
        _input = input;
        _times = Array.Empty<int>();
        _distances = Array.Empty<int>();

        Parse();
    }

    private void Parse()
    {
        var lines = _input.Split("\n");
        _times = lines[0].Split(":")[1].Split(" ").Where(p => !string.IsNullOrEmpty(p)).Select(int.Parse).ToArray();
        _distances = lines[1].Split(":")[1].Split(" ").Where(p => !string.IsNullOrEmpty(p)).Select(int.Parse).ToArray();
    }
}
