



namespace Day9.Logic;
public class MirageMaintenance
{
    private readonly string _input;
    private readonly string[] _lines;

    public int HistoryCount { get; set; }
    public List<int[]> Histories { get; private set; }
    public List<List<int[]>> SequenceOfDifferences { get; private set; }

    public MirageMaintenance(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        HistoryCount = _lines.Length;
        Histories = new List<int[]>();
        SequenceOfDifferences = new List<List<int[]>>();

        foreach (var line in _lines)
        {
            var values = line.Split(" ").Select(int.Parse).ToArray();
            Histories.Add(values);
            SequenceOfDifferences.Add(new List<int[]>() { values });
        }
    }

    public void CalculateSequenceOfDifference()
    {
        var list = new List<int>();
        var sequence = SequenceOfDifferences[0].Last();
        for (var index = 0; index < sequence.Length - 1; index++)
        {
            list.Add(sequence[index + 1] - sequence[index]);
        }

        SequenceOfDifferences[0].Add(list.ToArray());
    }

    public void Calculate()
    {
        while (SequenceOfDifferences[0].Last().Any(q => q != 0))
        {
            CalculateSequenceOfDifference();
        }
    }
}