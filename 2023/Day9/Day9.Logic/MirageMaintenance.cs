




namespace Day9.Logic;
public class MirageMaintenance
{
    private readonly string _input;
    private readonly string[] _lines;

    public int HistoryCount { get; set; }
    public List<List<int>> Histories { get; private set; }
    public List<List<List<int>>> SequenceOfDifferences { get; private set; }

    public MirageMaintenance(string input)
    {
        _input = input;
        _lines = _input.Split("\n");

        HistoryCount = _lines.Length;
        Histories = new List<List<int>>();
        SequenceOfDifferences = new List<List<List<int>>>();

        foreach (var line in _lines)
        {
            var values = line.Split(" ").Select(int.Parse).ToList();
            Histories.Add(values);
            SequenceOfDifferences.Add(new List<List<int>>() { values });
        }
    }

    public void CalculateSequenceOfDifference(int id = 0)
    {
        var currentSequence = SequenceOfDifferences[id];
        var list = new List<int>();
        var sequence = currentSequence.Last();
        for (var index = 0; index < sequence.Count - 1; index++)
        {
            list.Add(sequence[index + 1] - sequence[index]);
        }

        currentSequence.Add(list.ToList());
    }

    public void Calculate()
    {
        for (var index = 0; index < HistoryCount; index++)
        {
            var sequence = SequenceOfDifferences[index];
            while (sequence.Last().Any(q => q != 0))
            {
                CalculateSequenceOfDifference(index);
            }
        }
    }
/*
    public void ExtendSequence()
    {
        var lastValue = 0;
        for (var index = 0; index < HistoryCount; index++)
        {
            foreach (var sequence in SequenceOfDifferences[index])
            {
                sequence.ad
            }


            while (sequence.Last().Any(q => q != 0))
            {
                CalculateSequenceOfDifference(index);
            }
        }

    }*/
}