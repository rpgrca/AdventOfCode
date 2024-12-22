namespace Day21.Logic;

public class CombinedKeypadTyping : IKeypadTyping
{
    private readonly List<IKeypadTyping> _keypads;

    public CombinedKeypadTyping(List<IKeypadTyping> keypads)
    {
        _keypads = keypads;
    }

    public List<List<string>> CalculateShortestSequence(List<List<string>> sequenceToType)
    {
        var currentSequence = _keypads.First().CalculateShortestSequence(sequenceToType);
        foreach (var keypad in _keypads.Skip(1))
        {
            currentSequence = keypad.CalculateShortestSequence(currentSequence);
        }

        return currentSequence;
    }

    public string CalculateShortestSequence(string sequenceToType)
    {
        var sequences = CalculateShortestSequence(new List<List<string>> { new() { sequenceToType } });
        var result = string.Concat(sequences.Select(p => p.MinBy(p => p.Length)));
        return result;
    }
}