
namespace Day9.Logic;
public class MirageMaintenance
{
    private readonly string _input;

    public int HistoryCount { get; set; }

    public MirageMaintenance(string input)
    {
        _input = input;
        HistoryCount = _input.Split("\n").Length;
    }
}
