
namespace Day18.Logic;

public class RamRun
{
    private readonly string _input;
    private readonly List<(int X, int Y)> _corruptedMemory;

    public int Count => _corruptedMemory.Count;

    public RamRun(string input)
    {
        _input = input;
        _corruptedMemory = _input.Split('\n')
            .Select(p => (int.Parse(p.Split(',')[0]), int.Parse(p.Split(',')[1])))
            .ToList();
    }
}
