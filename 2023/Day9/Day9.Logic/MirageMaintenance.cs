





namespace Day9.Logic;
public class MirageMaintenance
{
    private readonly string _input;
    private readonly string[] _lines;

    public int HistoryCount { get; set; }
    public List<List<int>> Histories { get; private set; }
    public List<List<List<int>>> SequenceOfDifferences { get; private set; }
    public int SumOfExtrapolatedValues { get; private set; }

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

    public void ExtendSequence()
    {
        SumOfExtrapolatedValues = 0;

        for (var index = 0; index < HistoryCount; index++)
        {
            var lastValueToAdd = 0;

            for (var subIndex = SequenceOfDifferences[index].Count - 1; subIndex >= 0; subIndex--)
            {
                var sequence = SequenceOfDifferences[index][subIndex];
                var lastNumberInCurrentSequence = sequence.Last();
                lastValueToAdd += lastNumberInCurrentSequence;
                sequence.Add(lastValueToAdd);
            }

            SumOfExtrapolatedValues += lastValueToAdd;
        }
    }
}