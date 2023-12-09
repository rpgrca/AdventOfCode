

namespace Day9.Logic;
public class MirageMaintenance
{
    private readonly string _input;
    private readonly string[] _lines;

    public int HistoryCount { get; set; }
    public List<int[]> Histories { get; private set; }

    public MirageMaintenance(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        HistoryCount = _lines.Length;
        Histories = new List<int[]>();
        foreach (var line in _lines)
        {
            Histories.Add(line.Split(" ").Select(int.Parse).ToArray());
        }
    }
}
